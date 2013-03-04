namespace WindowsFormsApplication1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bt_TrgRfst = new System.Windows.Forms.Button();
            this.bt_TrgRfs = new System.Windows.Forms.Button();
            this.cb_TrgDB = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_TrgTab = new System.Windows.Forms.ComboBox();
            this.cb_TrgWinAuth = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_TrgServer = new System.Windows.Forms.TextBox();
            this.tb_TrgUname = new System.Windows.Forms.TextBox();
            this.tb_TrgPwd = new System.Windows.Forms.TextBox();
            this.dgv_Mappings = new System.Windows.Forms.DataGridView();
            this.bt_Compare = new System.Windows.Forms.Button();
            this.cb_DiffCols = new System.Windows.Forms.CheckBox();
            this.tb_SrcPwd = new System.Windows.Forms.TextBox();
            this.tb_SrcUname = new System.Windows.Forms.TextBox();
            this.tb_SrcServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_SrcWinAuth = new System.Windows.Forms.CheckBox();
            this.cb_SrcTab = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_SrcDB = new System.Windows.Forms.ComboBox();
            this.bt_SrcRfs = new System.Windows.Forms.Button();
            this.bt_SrcRfst = new System.Windows.Forms.Button();
            this.tb_Conn = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tb_SrcFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tb_TrgFilter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SourceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SelectedKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SourceColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mappings)).BeginInit();
            this.tb_Conn.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 270);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(841, 246);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.VirtualMode = true;
            // 
            // bt_TrgRfst
            // 
            this.bt_TrgRfst.Enabled = false;
            this.bt_TrgRfst.Location = new System.Drawing.Point(233, 137);
            this.bt_TrgRfst.Name = "bt_TrgRfst";
            this.bt_TrgRfst.Size = new System.Drawing.Size(19, 21);
            this.bt_TrgRfst.TabIndex = 17;
            this.bt_TrgRfst.UseVisualStyleBackColor = true;
            this.bt_TrgRfst.Click += new System.EventHandler(this.bt_TrgRfst_Click);
            // 
            // bt_TrgRfs
            // 
            this.bt_TrgRfs.Location = new System.Drawing.Point(233, 112);
            this.bt_TrgRfs.Name = "bt_TrgRfs";
            this.bt_TrgRfs.Size = new System.Drawing.Size(19, 21);
            this.bt_TrgRfs.TabIndex = 17;
            this.bt_TrgRfs.UseVisualStyleBackColor = true;
            this.bt_TrgRfs.Click += new System.EventHandler(this.bt_TrgRfs_Click);
            // 
            // cb_TrgDB
            // 
            this.cb_TrgDB.Enabled = false;
            this.cb_TrgDB.FormattingEnabled = true;
            this.cb_TrgDB.Location = new System.Drawing.Point(85, 112);
            this.cb_TrgDB.Name = "cb_TrgDB";
            this.cb_TrgDB.Size = new System.Drawing.Size(142, 20);
            this.cb_TrgDB.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 14;
            this.label12.Text = "Database";
            // 
            // cb_TrgTab
            // 
            this.cb_TrgTab.Enabled = false;
            this.cb_TrgTab.FormattingEnabled = true;
            this.cb_TrgTab.Location = new System.Drawing.Point(85, 137);
            this.cb_TrgTab.Name = "cb_TrgTab";
            this.cb_TrgTab.Size = new System.Drawing.Size(142, 20);
            this.cb_TrgTab.TabIndex = 12;
            this.cb_TrgTab.DropDown += new System.EventHandler(this.cb_TrgTab_DropDown);
            this.cb_TrgTab.SelectedIndexChanged += new System.EventHandler(this.cb_TrgTab_SelectedIndexChanged);
            // 
            // cb_TrgWinAuth
            // 
            this.cb_TrgWinAuth.AutoSize = true;
            this.cb_TrgWinAuth.Checked = true;
            this.cb_TrgWinAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_TrgWinAuth.Location = new System.Drawing.Point(85, 42);
            this.cb_TrgWinAuth.Name = "cb_TrgWinAuth";
            this.cb_TrgWinAuth.Size = new System.Drawing.Size(156, 16);
            this.cb_TrgWinAuth.TabIndex = 10;
            this.cb_TrgWinAuth.Text = "Windows Authentication";
            this.cb_TrgWinAuth.UseVisualStyleBackColor = true;
            this.cb_TrgWinAuth.CheckedChanged += new System.EventHandler(this.cb_TrgWinAuth_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "Table/View";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "User";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "Server";
            // 
            // tb_TrgServer
            // 
            this.tb_TrgServer.Location = new System.Drawing.Point(85, 18);
            this.tb_TrgServer.Name = "tb_TrgServer";
            this.tb_TrgServer.Size = new System.Drawing.Size(167, 21);
            this.tb_TrgServer.TabIndex = 2;
            this.tb_TrgServer.Text = "localhost\\MCSQL";
            // 
            // tb_TrgUname
            // 
            this.tb_TrgUname.Location = new System.Drawing.Point(85, 64);
            this.tb_TrgUname.Name = "tb_TrgUname";
            this.tb_TrgUname.Size = new System.Drawing.Size(167, 21);
            this.tb_TrgUname.TabIndex = 3;
            // 
            // tb_TrgPwd
            // 
            this.tb_TrgPwd.Location = new System.Drawing.Point(85, 88);
            this.tb_TrgPwd.Name = "tb_TrgPwd";
            this.tb_TrgPwd.PasswordChar = 'X';
            this.tb_TrgPwd.Size = new System.Drawing.Size(167, 21);
            this.tb_TrgPwd.TabIndex = 4;
            // 
            // dgv_Mappings
            // 
            this.dgv_Mappings.AllowUserToAddRows = false;
            this.dgv_Mappings.AllowUserToDeleteRows = false;
            this.dgv_Mappings.AllowUserToResizeRows = false;
            this.dgv_Mappings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Mappings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Mappings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Mappings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.SourceColumn,
            this.TargetColumn,
            this.SelectedKey,
            this.SourceColumnName});
            this.dgv_Mappings.Location = new System.Drawing.Point(314, 6);
            this.dgv_Mappings.Name = "dgv_Mappings";
            this.dgv_Mappings.RowHeadersVisible = false;
            this.dgv_Mappings.RowHeadersWidth = 4;
            this.dgv_Mappings.RowTemplate.Height = 23;
            this.dgv_Mappings.Size = new System.Drawing.Size(547, 224);
            this.dgv_Mappings.TabIndex = 8;
            // 
            // bt_Compare
            // 
            this.bt_Compare.Enabled = false;
            this.bt_Compare.Location = new System.Drawing.Point(20, 235);
            this.bt_Compare.Name = "bt_Compare";
            this.bt_Compare.Size = new System.Drawing.Size(109, 29);
            this.bt_Compare.TabIndex = 11;
            this.bt_Compare.Text = "Compare";
            this.bt_Compare.UseVisualStyleBackColor = true;
            this.bt_Compare.Click += new System.EventHandler(this.bt_Compare_Click);
            // 
            // cb_DiffCols
            // 
            this.cb_DiffCols.AutoSize = true;
            this.cb_DiffCols.Enabled = false;
            this.cb_DiffCols.Location = new System.Drawing.Point(160, 244);
            this.cb_DiffCols.Name = "cb_DiffCols";
            this.cb_DiffCols.Size = new System.Drawing.Size(156, 16);
            this.cb_DiffCols.TabIndex = 12;
            this.cb_DiffCols.Text = "Show Diff Columns Only";
            this.cb_DiffCols.UseVisualStyleBackColor = true;
            this.cb_DiffCols.CheckedChanged += new System.EventHandler(this.cb_DiffCols_CheckedChanged);
            // 
            // tb_SrcPwd
            // 
            this.tb_SrcPwd.Location = new System.Drawing.Point(85, 88);
            this.tb_SrcPwd.Name = "tb_SrcPwd";
            this.tb_SrcPwd.PasswordChar = 'X';
            this.tb_SrcPwd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tb_SrcPwd.Size = new System.Drawing.Size(167, 21);
            this.tb_SrcPwd.TabIndex = 4;
            // 
            // tb_SrcUname
            // 
            this.tb_SrcUname.Location = new System.Drawing.Point(85, 64);
            this.tb_SrcUname.Name = "tb_SrcUname";
            this.tb_SrcUname.Size = new System.Drawing.Size(167, 21);
            this.tb_SrcUname.TabIndex = 3;
            // 
            // tb_SrcServer
            // 
            this.tb_SrcServer.Location = new System.Drawing.Point(85, 18);
            this.tb_SrcServer.Name = "tb_SrcServer";
            this.tb_SrcServer.Size = new System.Drawing.Size(167, 21);
            this.tb_SrcServer.TabIndex = 2;
            this.tb_SrcServer.Text = "localhost\\MCSQL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Table/View";
            // 
            // cb_SrcWinAuth
            // 
            this.cb_SrcWinAuth.AutoSize = true;
            this.cb_SrcWinAuth.Checked = true;
            this.cb_SrcWinAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_SrcWinAuth.Location = new System.Drawing.Point(85, 42);
            this.cb_SrcWinAuth.Name = "cb_SrcWinAuth";
            this.cb_SrcWinAuth.Size = new System.Drawing.Size(156, 16);
            this.cb_SrcWinAuth.TabIndex = 10;
            this.cb_SrcWinAuth.Text = "Windows Authentication";
            this.cb_SrcWinAuth.UseVisualStyleBackColor = true;
            this.cb_SrcWinAuth.CheckedChanged += new System.EventHandler(this.cb_SrcWinAuth_CheckedChanged);
            // 
            // cb_SrcTab
            // 
            this.cb_SrcTab.AllowDrop = true;
            this.cb_SrcTab.Enabled = false;
            this.cb_SrcTab.FormattingEnabled = true;
            this.cb_SrcTab.Location = new System.Drawing.Point(85, 137);
            this.cb_SrcTab.Name = "cb_SrcTab";
            this.cb_SrcTab.Size = new System.Drawing.Size(142, 20);
            this.cb_SrcTab.TabIndex = 12;
            this.cb_SrcTab.UseWaitCursor = true;
            this.cb_SrcTab.DropDown += new System.EventHandler(this.cb_SrcTab_DropDown);
            this.cb_SrcTab.SelectedIndexChanged += new System.EventHandler(this.cb_SrcTab_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "Database";
            // 
            // cb_SrcDB
            // 
            this.cb_SrcDB.AllowDrop = true;
            this.cb_SrcDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SrcDB.Enabled = false;
            this.cb_SrcDB.FormattingEnabled = true;
            this.cb_SrcDB.Location = new System.Drawing.Point(85, 112);
            this.cb_SrcDB.Name = "cb_SrcDB";
            this.cb_SrcDB.Size = new System.Drawing.Size(142, 20);
            this.cb_SrcDB.TabIndex = 15;
            this.cb_SrcDB.UseWaitCursor = true;
            // 
            // bt_SrcRfs
            // 
            this.bt_SrcRfs.Location = new System.Drawing.Point(233, 112);
            this.bt_SrcRfs.Name = "bt_SrcRfs";
            this.bt_SrcRfs.Size = new System.Drawing.Size(19, 21);
            this.bt_SrcRfs.TabIndex = 16;
            this.bt_SrcRfs.UseVisualStyleBackColor = true;
            this.bt_SrcRfs.Click += new System.EventHandler(this.bt_SrcRfs_Click);
            // 
            // bt_SrcRfst
            // 
            this.bt_SrcRfst.Enabled = false;
            this.bt_SrcRfst.Location = new System.Drawing.Point(233, 137);
            this.bt_SrcRfst.Name = "bt_SrcRfst";
            this.bt_SrcRfst.Size = new System.Drawing.Size(19, 21);
            this.bt_SrcRfst.TabIndex = 16;
            this.bt_SrcRfst.UseVisualStyleBackColor = true;
            this.bt_SrcRfst.Click += new System.EventHandler(this.bt_SrcRfst_Click);
            // 
            // tb_Conn
            // 
            this.tb_Conn.Controls.Add(this.tabPage1);
            this.tb_Conn.Controls.Add(this.tabPage2);
            this.tb_Conn.ItemSize = new System.Drawing.Size(142, 18);
            this.tb_Conn.Location = new System.Drawing.Point(20, 6);
            this.tb_Conn.Name = "tb_Conn";
            this.tb_Conn.SelectedIndex = 0;
            this.tb_Conn.Size = new System.Drawing.Size(288, 224);
            this.tb_Conn.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tb_Conn.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tb_SrcFilter);
            this.tabPage1.Controls.Add(this.bt_SrcRfst);
            this.tabPage1.Controls.Add(this.cb_SrcWinAuth);
            this.tabPage1.Controls.Add(this.bt_SrcRfs);
            this.tabPage1.Controls.Add(this.tb_SrcPwd);
            this.tabPage1.Controls.Add(this.cb_SrcDB);
            this.tabPage1.Controls.Add(this.tb_SrcUname);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.tb_SrcServer);
            this.tabPage1.Controls.Add(this.cb_SrcTab);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(280, 198);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Source";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tb_SrcFilter
            // 
            this.tb_SrcFilter.Location = new System.Drawing.Point(85, 162);
            this.tb_SrcFilter.Multiline = true;
            this.tb_SrcFilter.Name = "tb_SrcFilter";
            this.tb_SrcFilter.Size = new System.Drawing.Size(167, 19);
            this.tb_SrcFilter.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Filter";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tb_TrgFilter);
            this.tabPage2.Controls.Add(this.bt_TrgRfst);
            this.tabPage2.Controls.Add(this.tb_TrgServer);
            this.tabPage2.Controls.Add(this.bt_TrgRfs);
            this.tabPage2.Controls.Add(this.tb_TrgPwd);
            this.tabPage2.Controls.Add(this.cb_TrgDB);
            this.tabPage2.Controls.Add(this.tb_TrgUname);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.cb_TrgTab);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.cb_TrgWinAuth);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(280, 198);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Target";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tb_TrgFilter
            // 
            this.tb_TrgFilter.Location = new System.Drawing.Point(85, 162);
            this.tb_TrgFilter.Multiline = true;
            this.tb_TrgFilter.Name = "tb_TrgFilter";
            this.tb_TrgFilter.Size = new System.Drawing.Size(167, 19);
            this.tb_TrgFilter.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "Filter";
            // 
            // Selected
            // 
            this.Selected.DataPropertyName = "Selected";
            this.Selected.HeaderText = "Selected";
            this.Selected.Name = "Selected";
            this.Selected.Width = 59;
            // 
            // SourceColumn
            // 
            this.SourceColumn.DataPropertyName = "SourceColumn";
            this.SourceColumn.HeaderText = "SourceColumn";
            this.SourceColumn.Name = "SourceColumn";
            this.SourceColumn.ReadOnly = true;
            this.SourceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SourceColumn.Width = 83;
            // 
            // TargetColumn
            // 
            this.TargetColumn.DataPropertyName = "TargetColumn";
            this.TargetColumn.HeaderText = "TargetColumn";
            this.TargetColumn.Name = "TargetColumn";
            this.TargetColumn.Width = 83;
            // 
            // SelectedKey
            // 
            this.SelectedKey.DataPropertyName = "Key";
            this.SelectedKey.HeaderText = "Is Key?";
            this.SelectedKey.Name = "SelectedKey";
            this.SelectedKey.Width = 53;
            // 
            // SourceColumnName
            // 
            this.SourceColumnName.HeaderText = "SourceColumnName";
            this.SourceColumnName.Name = "SourceColumnName";
            this.SourceColumnName.ReadOnly = true;
            this.SourceColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SourceColumnName.Visible = false;
            this.SourceColumnName.Width = 107;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 529);
            this.Controls.Add(this.tb_Conn);
            this.Controls.Add(this.cb_DiffCols);
            this.Controls.Add(this.bt_Compare);
            this.Controls.Add(this.dgv_Mappings);
            this.Controls.Add(this.dataGridView1);
            this.MinimumSize = new System.Drawing.Size(900, 556);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataCompare";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mappings)).EndInit();
            this.tb_Conn.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cb_TrgTab;
        private System.Windows.Forms.CheckBox cb_TrgWinAuth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_TrgServer;
        private System.Windows.Forms.TextBox tb_TrgUname;
        private System.Windows.Forms.TextBox tb_TrgPwd;
        private System.Windows.Forms.Button bt_TrgRfs;
        private System.Windows.Forms.ComboBox cb_TrgDB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgv_Mappings;
        private System.Windows.Forms.Button bt_Compare;
        private System.Windows.Forms.CheckBox cb_DiffCols;
        private System.Windows.Forms.Button bt_TrgRfst;
        private System.Windows.Forms.TextBox tb_SrcPwd;
        private System.Windows.Forms.TextBox tb_SrcUname;
        private System.Windows.Forms.TextBox tb_SrcServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_SrcWinAuth;
        private System.Windows.Forms.ComboBox cb_SrcTab;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cb_SrcDB;
        private System.Windows.Forms.Button bt_SrcRfs;
        private System.Windows.Forms.Button bt_SrcRfst;
        private System.Windows.Forms.TabControl tb_Conn;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_SrcFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_TrgFilter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn TargetColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectedKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceColumnName;
    }
}

