using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Threading;

namespace WindowsFormsApplication1
{
    public enum ConnType
    {
        Source = 0,
        Target = 1,
        Other = 99,
    }

    public partial class MainForm : Form
    {

        #region Global
        const string CONN_STRING_SSPI = @"server={0};Integrated Security=SSPI";
        const string CONN_STRING = @"server={0};user id={1};pwd={2}";
        const string CONN_DB = ";database={0}";
        const string RETRIEVE_TABLES_SQL = "SELECT u.name + '.' + o.name as Name FROM SysObjects o, SysUsers u Where o.uid = u.uid AND o.XType IN ('U','V') ORDER BY o.XType,o.Name";
        const string RETRIEVE_DATABASES_SQL = "SELECT Name FROM Master..SysDatabases ORDER BY Name";
        const string RETRIEVE_COLUMNS_SQL = "SELECT c.name + ' [' + t.name + '(' + cast(c.length as varchar) + ')]' AS Name, c.name AS Col FROM SysColumns c, SysTypes t  WHERE c.xtype = t.xtype AND t.status = 0  AND c.id = OBJECT_ID('{0}')";
        const string SRC_DBLIST_TABLE = "SrcDBList";
        const string TRG_DBLIST_TABLE = "TrgDBList";
        const string SRC_TABLIST_TABLE = "SrcTabList";
        const string TRG_TABLIST_TABLE = "TrgTabList";
        const string COL_NAME = "Name";
        const string TABLE = "Table";
        const string DB = "DB";

        SqlConnection[] connections = new SqlConnection[2];

        DataSet dsGlobal = new DataSet();
        DataTable dtResult = new DataTable("ResultTable");

        int columnCount = 0;
        bool[] diffColIndex = null;
        bool allDiff = false;

        List<Control> srcControls = new List<Control>();
        List<Control> trgControls = new List<Control>();
        List<Control> compControls = new List<Control>();

        int srcStatus = 0;
        int trgStatus = 0;

        bool refreshed = false;

        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            CollectControls();
            SetLayout(ConnType.Source, 0);
            SetLayout(ConnType.Target, 0);
        }
        
        #endregion

        #region Database

        private DataTable ExecuteSQL(string sql, ConnType connType)
        {
            DataSet ds = new DataSet();
            ExecuteSQL(sql, connType, ds, "tmp");
            return ds.Tables[0];
        }

        private void ExecuteSQL(string sql, ConnType connType, DataSet ds, string tabname)
        {
            if (sql == null || sql.Length == 0 || connections[(int)connType] == null || connections[(int)connType].State != ConnectionState.Open || ds == null || tabname == null || tabname.Length == 0)
                return;


            if (ds.Tables.Contains(tabname))
            {
                DataRelation dr;
                for(int i = 0; i < ds.Relations.Count;)
                {
                    dr = ds.Relations[i];
                    if (tabname.Equals(dr.ParentTable.TableName) || tabname.Equals(dr.ChildTable.TableName))
                    {
                        ds.Relations.Remove(dr);
                        continue;
                    }
                    i++;
                }
                ds.Tables.Remove(tabname);
            }

            SqlDataAdapter daSource = GetDataAdapter(sql, connType);
            daSource.Fill(ds, tabname);
        }

        private SqlDataAdapter GetDataAdapter(string sql, ConnType connType)
        {
            SqlCommand comm = new SqlCommand(sql, connections[(int)connType]);
            comm.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            return da;
        }

        private SqlDataReader GetDataReader(string sql, ConnType connType)
        {
            SqlCommand comm = new SqlCommand(sql, connections[(int)connType]);
            comm.CommandTimeout = 0;
            SqlDataReader dr = comm.ExecuteReader();
            return dr;
        }

        private void NewConnection(ConnType type, string connStr)
        {
            SqlConnection conn = connections[(int)type];
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn = new SqlConnection(connStr);
            connections[(int)type] = conn;
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string BuildConnectionString(string server, bool isWinAuth, string username, string password, string database)
        {
            string connStr = "";

            if (isWinAuth)
            {
                connStr = String.Format(CONN_STRING_SSPI, server.Trim());
            }
            else
            {
                connStr = String.Format(CONN_STRING, server.Trim(), username.Trim(), password.Trim());
            }

            return connStr + ((database == null) ? "" : String.Format(CONN_DB, database.Trim()));
        }

        private void CloseConnections()
        {
            CloseConnection(ConnType.Source);
            CloseConnection(ConnType.Target);
        }

        private void CloseConnection(ConnType connType)
        {
            if (connections[(int)connType] != null && connections[(int)connType].State == ConnectionState.Open)
                connections[(int)connType].Close();
        }

        #endregion

        #region DataSet

        private int getTrgRowCount()
        {
            string sql = "SELECT COUNT(1) FROM " + cb_TrgTab.SelectedValue + " WHERE " + (tb_TrgFilter.Text.Trim().Length == 0 ? "1=1" : tb_TrgFilter.Text.Trim());
            DataTable result = ExecuteSQL(sql, ConnType.Target);
            return (int)result.Rows[0][0];
        }

        private int getSrcRowCount()
        {
            string sql = "SELECT COUNT(1) FROM " + cb_SrcTab.SelectedValue + " WHERE " + (tb_SrcFilter.Text.Trim().Length == 0 ? "1=1" : tb_SrcFilter.Text.Trim());
            DataTable result = ExecuteSQL(sql, ConnType.Source);
            return (int)result.Rows[0][0];
        }

        private void InsertRow(SqlDataReader left, SqlDataReader right)
        {
            DataRow newRow = dtResult.NewRow();
            for (int i = 0; i < columnCount; i++)
            {
                newRow[i] = (left == null) ? DBNull.Value : left[i];
                if (left == null)
                    diffColIndex[i] = true;
            }
            for (int i = 0; i < columnCount; i++)
            {
                newRow[i + columnCount] = (right == null) ? DBNull.Value : right[i];
                if (right == null)
                    diffColIndex[i + columnCount] = true;
            }
            dtResult.Rows.Add(newRow);
        }

        private void DataRowCompare(SqlDataReader left, SqlDataReader right)
        {
            bool diff = false;

            if (left == null || right == null)
            {
                diff = true;
                if (!allDiff)
                {
                    ArrayList.Repeat(true, diffColIndex.Length).CopyTo(diffColIndex);
                    allDiff = true;
                }
            }
            else
            {
                for (int i = 0; i < columnCount; i++)
                {
                    if (string.Compare(left[i].ToString(), right[i].ToString()) != 0)
                    {
                        diff = true;
                        diffColIndex[i] = true;
                        diffColIndex[i + columnCount] = true;
                    }
                }
            }

            if (diff)
            {
                InsertRow(left, right);
            }
        }

        private void MappingColumns()
        {
            DataTable dtSrc = dsGlobal.Tables["SrcCols"];
            DataTable dtTrg = dsGlobal.Tables["TrgCols"];

            DataTable mapping = new DataTable("Mapping");
            mapping.Columns.Add("Selected", System.Type.GetType("System.Boolean"));
            mapping.Columns.Add("SourceColumns", System.Type.GetType("System.String"));
            mapping.Columns.Add("TargetColumns", System.Type.GetType("System.String"));
            mapping.Columns.Add("Keys", System.Type.GetType("System.Boolean"));
            mapping.Columns.Add("SourceColumnName", System.Type.GetType("System.String"));

            if (dsGlobal.Tables.Contains("Mapping"))
                dsGlobal.Tables.Remove("Mapping");
            dsGlobal.Tables.Add(mapping);
            DataRelation dr = new DataRelation("ColumnName", dtSrc.Columns["col"], dtTrg.Columns["col"], false);
            dsGlobal.Relations.Add(dr);

            mapping.BeginLoadData();
            foreach (DataRow row in dtSrc.Rows)
            {
                DataRow newRow = mapping.NewRow();
                newRow[0] = false;
                newRow[1] = row["name"];
                newRow[3] = false;
                newRow[4] = row["col"];

                foreach (DataRow childRow in row.GetChildRows(dr))
                {
                    if (childRow != null)
                    {
                        newRow[2] = childRow["col"];
                        newRow[0] = true;
                    }
                }
                mapping.Rows.Add(newRow);
                dgv_Mappings.Rows.Add(newRow[0], newRow[1], newRow[2], newRow[3], newRow[4]);
            }

            mapping.EndLoadData();

        }

        private int CompareKeys(SqlDataReader drLeft, SqlDataReader drRight, int[] keyIndex)
        {
            if (drLeft == null)
                return 1;

            if (drRight == null)
                return -1;

            int compare = 0;

            foreach (int i in keyIndex)
            {
                compare = string.Compare(drLeft[i].ToString(), drRight[i].ToString());
                if (compare != 0)
                    break;
            }

            return compare;
        }

        private void BuildSql(ref string sqlSrc, ref string sqlTrg, ref int[] keyIndex, ref string sqlColSrc, ref string sqlColTrg)
        {
            List<int> lstKeysIndex = new List<int>();
            sqlSrc = "SELECT ";
            sqlTrg = "SELECT ";
            string sqlSrcOrder = " ORDER BY ";
            string sqlTrgOrder = " ORDER BY ";
            string srcCol = "";
            string trgCol = "";

            int selectedCount = 0;

            foreach (DataGridViewRow row in dgv_Mappings.Rows)
            {
                if ((bool)row.Cells[0].Value != true)
                    continue;

                //Get selected source column name and target column name.
                srcCol = ((string)row.Cells[4].Value).Trim();
                trgCol = ((string)row.Cells[2].Value).Trim();

                //Prepare for the select SQL.
                sqlSrc += srcCol + ", ";
                sqlTrg += trgCol + ", ";

                //Prepare for the order by SQL.
                if ((bool)row.Cells[3].Value == true)
                {
                    lstKeysIndex.Add(selectedCount);
                    sqlSrcOrder += (selectedCount + 1) + ", ";
                    sqlTrgOrder += (selectedCount + 1) + ", ";
                }
                selectedCount++;
            }

            sqlSrc = sqlSrc.Remove(sqlSrc.Length - 2);
            sqlTrg = sqlTrg.Remove(sqlTrg.Length - 2);
            sqlSrcOrder = sqlSrcOrder.Remove(sqlSrcOrder.Length - 2);
            sqlTrgOrder = sqlTrgOrder.Remove(sqlTrgOrder.Length - 2);

            sqlSrc += " FROM " + cb_SrcTab.SelectedValue;
            sqlTrg += " FROM " + cb_TrgTab.SelectedValue;

            sqlColSrc = sqlSrc + " WHERE 1=2";
            sqlColTrg = sqlTrg + " WHERE 1=2";

            sqlSrc += " WHERE " + (tb_SrcFilter.Text.Trim().Length == 0 ? "1=1" : tb_SrcFilter.Text.Trim()) + sqlSrcOrder;
            sqlTrg += " WHERE " + (tb_TrgFilter.Text.Trim().Length == 0 ? "1=1" : tb_TrgFilter.Text.Trim()) + sqlTrgOrder;

            keyIndex = lstKeysIndex.ToArray();
        }

        private void HighlightCells()
        {
            DataGridViewCellStyle highlight = new DataGridViewCellStyle();
            highlight.ForeColor = Color.Red;

            int colCount = dataGridView1.ColumnCount;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < colCount / 2; i++)
                {
                    if (row.Cells[0].Value == null)
                    {
                        row.Cells[i].Style.BackColor = Color.LightGreen;
                        continue;
                    }
                    if (row.Cells[colCount / 2].Value == null)
                    {
                        row.Cells[colCount / 2 + i].Style.BackColor = Color.LightGreen;
                        continue;
                    }
                    if ((row.Cells[i].Value == null && row.Cells[colCount / 2 + i].Value != null) || (row.Cells[i].Value != null && !row.Cells[i].Value.Equals(row.Cells[colCount / 2 + i].Value)))
                    {
                        row.Cells[i].Style.BackColor = Color.LightPink;
                        row.Cells[colCount / 2 + i].Style.BackColor = Color.LightPink;
                    }
                }
            }
        }

        private void DoColumnsMapping()
        {
            dgv_Mappings.Rows.Clear();

            string sqlSrc = String.Format(RETRIEVE_COLUMNS_SQL, cb_SrcTab.SelectedValue);
            string sqlTrg = String.Format(RETRIEVE_COLUMNS_SQL, cb_TrgTab.SelectedValue);

            DataSet ds = new DataSet();

            ExecuteSQL(sqlSrc, ConnType.Source, dsGlobal, "SrcCols");
            ExecuteSQL(sqlTrg, ConnType.Target, dsGlobal, "TrgCols");

            ((DataGridViewComboBoxColumn)dgv_Mappings.Columns[2]).DataSource = dsGlobal.Tables["TrgCols"];
            ((DataGridViewComboBoxColumn)dgv_Mappings.Columns[2]).DisplayMember = "name";
            ((DataGridViewComboBoxColumn)dgv_Mappings.Columns[2]).ValueMember = "col";

            MappingColumns();

            SetLayout(ConnType.Other, 5);

        }

        private void Reset()
        {
            columnCount = 0;
            diffColIndex = null;
            allDiff = false;
            //dsGlobal.Tables.Clear();
            cb_DiffCols.Checked = false;
        }

        #endregion

        #region Form

        public void AutoSizeComboBoxItem(object sender)
        {
            if (sender is ComboBox)
            {
                Graphics grap = Graphics.FromHwnd((sender as ComboBox).Handle);
                grap.PageUnit = GraphicsUnit.Pixel;
                StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
                SizeF size;
                int i = 0;
                int extraWidth = 5;
                bool resize = false;
                float maxSize = 0f;
                if ((sender as ComboBox).MaxDropDownItems < (sender as ComboBox).Items.Count)
                {
                    extraWidth += 18;
                }

                while (i < (sender as ComboBox).Items.Count)
                {
                    DataRowView tmpRow = (DataRowView)(sender as ComboBox).Items[i];
                    string test = (string)tmpRow["Name"];

                    size = grap.MeasureString(test, (sender as ComboBox).Font, 500, sf);
                    maxSize = Math.Max(size.Width, maxSize);
                    if (size.Width > (sender as ComboBox).DropDownWidth - extraWidth)
                    {
                        (sender as ComboBox).DropDownWidth = System.Convert.ToInt32(size.Width) + extraWidth;
                        resize = true;

                    }

                    i++;

                }
                if (!resize)
                {
                    (sender as ComboBox).DropDownWidth = (int)maxSize + extraWidth;

                }

                grap.Dispose();
                sf.Dispose();
            }

        }

        private void CollectControls()
        {
            srcControls.Add(tb_SrcServer);
            srcControls.Add(cb_SrcWinAuth);
            srcControls.Add(tb_SrcUname);
            srcControls.Add(tb_SrcPwd);
            srcControls.Add(cb_SrcDB);
            srcControls.Add(bt_SrcRfs);
            srcControls.Add(cb_SrcTab);
            srcControls.Add(bt_SrcRfst);
            srcControls.Add(tb_SrcFilter);

            trgControls.Add(tb_TrgServer);
            trgControls.Add(cb_TrgWinAuth);
            trgControls.Add(tb_TrgUname);
            trgControls.Add(tb_TrgPwd);
            trgControls.Add(cb_TrgDB);
            trgControls.Add(bt_TrgRfs);
            trgControls.Add(cb_TrgTab);
            trgControls.Add(bt_TrgRfst);
            trgControls.Add(tb_TrgFilter);

            compControls.Add(bt_Compare);
            compControls.Add(cb_DiffCols);
        }

        private void SetLayout(ConnType connType, int status)
        {
            List<Control> oper = null;

            if (connType == ConnType.Source)
            {
                oper = srcControls;
                srcStatus = status;
            }
            else if (connType == ConnType.Target)
            {
                oper = trgControls;
                trgStatus = status;
            }
            else
            {
                oper = compControls;
            }

            switch (status)
            {
                case 0:
                    oper[0].Enabled = true;
                    oper[1].Enabled = true;
                    oper[2].Enabled = !((CheckBox)oper[1]).Checked;
                    oper[3].Enabled = !((CheckBox)oper[1]).Checked;
                    oper[4].Enabled = false;
                    oper[5].Enabled = true;
                    oper[6].Enabled = false;
                    oper[7].Enabled = false;
                    oper[8].Enabled = false;
                    compControls[0].Enabled = false;
                    compControls[1].Enabled = false;
                    break;
                case 1:
                    oper[0].Enabled = false;
                    oper[1].Enabled = false;
                    oper[2].Enabled = false;
                    oper[3].Enabled = false;
                    oper[4].Enabled = true;
                    oper[5].Enabled = true;
                    oper[6].Enabled = false;
                    oper[7].Enabled = true;
                    oper[8].Enabled = false;
                    compControls[0].Enabled = false;
                    compControls[1].Enabled = false;
                    break;
                case 2:
                    oper[0].Enabled = false;
                    oper[1].Enabled = false;
                    oper[2].Enabled = false;
                    oper[3].Enabled = false;
                    oper[4].Enabled = false;
                    oper[5].Enabled = false;
                    oper[6].Enabled = true;
                    oper[7].Enabled = true;
                    oper[8].Enabled = true;
                    compControls[0].Enabled = false;
                    compControls[1].Enabled = false;
                    break;
                case 5:
                    oper[0].Enabled = true;
                    //srcControls[6].Enabled = false;
                    //srcControls[7].Enabled = false;
                    //srcControls[8].Enabled = false;
                    //trgControls[6].Enabled = false;
                    //trgControls[7].Enabled = false;
                    //trgControls[8].Enabled = false;
                    break;
                case 6:
                    oper[1].Enabled = true;
                    break;
                default:
                    break;
            }

            if (srcStatus == 2 && trgStatus == 2)
            {
                compControls[0].Enabled = true;
            }
            else
            {
                compControls[0].Enabled = false;
            }
        }

        private void BindDataSource(ComboBox comboBoxBind, ConnType connType, string type)
        {
            string target_table = "";
            string sql = (type == DB) ? RETRIEVE_DATABASES_SQL : RETRIEVE_TABLES_SQL;

            if (connType == ConnType.Source)
            {
                target_table = (type == DB) ? SRC_DBLIST_TABLE : SRC_TABLIST_TABLE;
            }
            else if (connType == ConnType.Target)
            {
                target_table = (type == DB) ? TRG_DBLIST_TABLE : TRG_TABLIST_TABLE;
            }
            ExecuteSQL(sql, connType, dsGlobal, target_table);
            comboBoxBind.DisplayMember = COL_NAME;
            comboBoxBind.ValueMember = COL_NAME;

            comboBoxBind.DataSource = dsGlobal.Tables[target_table];
        }

        private void DoRefresh()
        {
            while (true)
            {
                Thread.Sleep(1000);
                refreshed = false;
            }
        }

        #endregion

        #region Event

        private void cb_SrcWinAuth_CheckedChanged(object sender, EventArgs e)
        {
            SetLayout(ConnType.Source, 0);
        }

        private void cb_TrgWinAuth_CheckedChanged(object sender, EventArgs e)
        {
            SetLayout(ConnType.Target, 0);
        }

        private void bt_SrcRfs_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_SrcDB.DataSource == null)
                {
                    string connStr = BuildConnectionString(tb_SrcServer.Text, cb_SrcWinAuth.Checked, tb_SrcUname.Text, tb_SrcPwd.Text, null);

                    NewConnection(ConnType.Source, connStr);

                    BindDataSource(cb_SrcDB, ConnType.Source, DB);

                    SetLayout(ConnType.Source, 1);
                }
                else
                {
                    cb_SrcDB.DataSource = null;
                    SetLayout(ConnType.Source, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_TrgRfs_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_TrgDB.DataSource == null)
                {
                    string connStr = BuildConnectionString(tb_TrgServer.Text, cb_TrgWinAuth.Checked, tb_TrgUname.Text, tb_TrgPwd.Text, null);
                    NewConnection(ConnType.Target, connStr);
                    BindDataSource(cb_TrgDB, ConnType.Target, DB);
                    SetLayout(ConnType.Target, 1);
                }
                else
                {
                    cb_TrgDB.DataSource = null;
                    SetLayout(ConnType.Target, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bt_SrcRfst_Click(object sender, EventArgs e)
        {
            if (cb_SrcTab.DataSource == null)
            {

                try
                {
                    string connStr = BuildConnectionString(tb_SrcServer.Text, cb_SrcWinAuth.Checked, tb_SrcUname.Text, tb_SrcPwd.Text, (string)cb_SrcDB.SelectedValue);
                    NewConnection(ConnType.Source, connStr);

                    SetLayout(ConnType.Source, 2);

                    BindDataSource(cb_SrcTab, ConnType.Source, TABLE);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                cb_SrcTab.DataSource = null;
                SetLayout(ConnType.Source, 1);
            }
        }

        private void bt_TrgRfst_Click(object sender, EventArgs e)
        {
            if (cb_TrgTab.DataSource == null)
            {

                try
                {
                    string connStr = BuildConnectionString(tb_TrgServer.Text, cb_TrgWinAuth.Checked, tb_TrgUname.Text, tb_TrgPwd.Text, (string)cb_TrgDB.SelectedValue);
                    NewConnection(ConnType.Target, connStr);

                    SetLayout(ConnType.Target, 2);

                    BindDataSource(cb_TrgTab, ConnType.Target, TABLE);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
            else
            {
                cb_TrgTab.DataSource = null;
                SetLayout(ConnType.Target, 1);
            }
        }

        private void bt_Compare_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;

            if (!ValidateColumnMapping())
            {
                MessageBox.Show("Invalid or incompleted column mapping.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Reset();

            dtResult = new DataTable("ResultTable");

            string sqlSource = "";
            string sqlTarget = "";

            string sqlColSource = "";
            string sqlColTarget = "";

            int[] keyIndex = null;

            BuildSql(ref sqlSource, ref sqlTarget, ref keyIndex, ref sqlColSource, ref sqlColTarget);

            int srcRowCount = 0;
            int trgRowCount = 0;

            try
            {
                srcRowCount = getSrcRowCount();
                trgRowCount = getTrgRowCount();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);              
                return;
            }

            DataTable dtSource = ExecuteSQL(sqlColSource, ConnType.Source);
            DataTable dtTarget = ExecuteSQL(sqlColTarget, ConnType.Target);

            SqlDataReader drSource = GetDataReader(sqlSource, ConnType.Source);
            SqlDataReader drTarget = GetDataReader(sqlTarget, ConnType.Target);

            columnCount = InitResultTable(dtResult);

            bool isNotSrcEof = true;
            bool isNotTrgEof = true;

            diffColIndex = new bool[dtResult.Columns.Count];

            ProgressBarFrom fm = new ProgressBarFrom(0, srcRowCount, 0, trgRowCount);

            fm.Show(this);

            dtResult.Clear();
            dtResult.BeginLoadData();

            isNotSrcEof = drSource.Read();
            isNotTrgEof = drTarget.Read();

            int processedCountSrc = 0;
            int processedCountTrg = 0;

            Thread th = new Thread(new ThreadStart(this.DoRefresh)); 
            th.Start();

            while (isNotSrcEof || isNotTrgEof)
            {

                int flag = CompareKeys(isNotSrcEof ? drSource : null, isNotTrgEof ? drTarget : null, keyIndex);

                DataRowCompare((flag <= 0) ? drSource : null, (flag >= 0) ? drTarget : null);

                if (flag <= 0)
                {
                    isNotSrcEof = drSource.Read();
                    processedCountSrc++;
                }

                if (flag >= 0)
                {
                    isNotTrgEof = drTarget.Read();
                    processedCountTrg++;
                }

                if (!refreshed)
                {
                    fm.setPosSrc(processedCountSrc);
                    fm.setPosTrg(processedCountTrg);
                    refreshed = true;
                }

                if (fm.Cancelled)
                {
                    th.Abort();
                    dtResult.EndLoadData();
                    drSource.Close();
                    drTarget.Close();
                    return;
                }
            }

            th.Abort();

            fm.setPosSrc(processedCountSrc);
            fm.setPosTrg(processedCountTrg);

            dtResult.EndLoadData();
            drSource.Close();
            drTarget.Close();

            //Set key column always visiable
            foreach (int i in keyIndex)
            {
                diffColIndex[i] = true;
                diffColIndex[i + columnCount] = true;
            }

            dataGridView1.DataSource = dtResult;

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //dataGridView1.Refresh();
            HighlightCells();

            //this.Cursor = Cursors.Default;
            SetLayout(ConnType.Other, 6);

        }

        private int InitResultTable(DataTable dtResult)
        {
            int columnCount = 0;

            foreach (DataGridViewRow row in dgv_Mappings.Rows)
            {
                if ((bool)row.Cells[0].Value != true)
                    continue;

                dtResult.Columns.Add("src." + ((string)row.Cells[1].Value).Split('[')[0].Trim(), dtSource.Columns[((string)row.Cells[1].Value).Split('[')[0].Trim()].DataType);
                columnCount++;
            }

            foreach (DataGridViewRow row in dgv_Mappings.Rows)
            {
                if ((bool)row.Cells[0].Value != true)
                    continue;

                dtResult.Columns.Add("trg." + ((string)row.Cells[2].Value).Split('[')[0].Trim(), dtTarget.Columns[((string)row.Cells[2].Value).Split('[')[0].Trim()].DataType);
            }

            return columnCount;
        }


        private bool ValidateColumnMapping()
        {
            int keyCount = 0;
            foreach (DataGridViewRow row in dgv_Mappings.Rows)
            {
                if ((bool)row.Cells[3].Value == true && (bool)row.Cells[0].Value == false)
                    return false;

                if ((bool)row.Cells[3].Value == true){
                    if ((bool)row.Cells[0].Value == false)
                        return false;
                    keyCount++;
                }

                if ((bool)row.Cells[0].Value == true &&
                    (row.Cells[1].Value.ToString().Trim() == "" || row.Cells[2].Value.ToString().Trim() == ""))
                    return false;
            }

            if (keyCount == 0)
                return false;

            return true;
        }

        private void cb_DiffCols_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_DiffCols.Checked)
            {
                for (int i = 0; i < diffColIndex.Length; i++)
                {
                    dataGridView1.Columns[i].Visible = diffColIndex[i];
                }
            }
            else
            {
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.Visible = true;
                }
            }

        }

        private void cb_TrgTab_DropDown(object sender, EventArgs e)
        {
            AutoSizeComboBoxItem(sender);
        }

        private void cb_SrcTab_DropDown(object sender, EventArgs e)
        {
            AutoSizeComboBoxItem(sender);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseConnections();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            dgv_Mappings.Width = this.Width - 351;
            dataGridView1.Width = this.Width - 59;
            dataGridView1.Height = this.Height - 333;
        }

        private void cb_SrcTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trgStatus == 2 && srcStatus == 2)
            {
                DoColumnsMapping();
            }
        }

        private void cb_TrgTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (srcStatus == 2 && trgStatus == 2)
            {
                DoColumnsMapping();
            }
        }

        #endregion

        
    }
}
