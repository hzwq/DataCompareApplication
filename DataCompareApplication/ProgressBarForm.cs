using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ProgressBarFrom : Form
    {

        bool SrcFinished = false;
        bool TrgFinished = false;
        bool IsCancelled = false;

        const string ESTIMATING = "Estimating...";
        const string COMPARING = "Comparing...";
        const string DONE = "Done";
        const string FINISH = "Finish";
        const string FETCH = "Fetching data...";

        public bool Cancelled
        {
            get { return IsCancelled; }
        }

        public ProgressBarFrom()
            : this(0, 0, 0, 0)
        {
            SwitchTitle(ESTIMATING);
        }

        public ProgressBarFrom(int minimumSrc, int maximumSrc, int minimumTrg, int maximumTrg)
        {
            InitializeComponent();
            pb_Processed.Maximum = maximumSrc;
            pb_Processed.Value = pb_Processed.Minimum = minimumSrc;
            pb_ProcessedTrg.Maximum = maximumTrg;
            pb_ProcessedTrg.Value = pb_Processed.Minimum = minimumTrg;
            this.Refresh();
        }

        public void SetMaximum(int maximumSrc, int maximumTrg)
        {
            pb_Processed.Maximum = maximumSrc;
            pb_ProcessedTrg.Maximum = maximumTrg;
            lb_CountTrg.Text = "0/" + pb_ProcessedTrg.Maximum.ToString();
            lb_Count.Text = "0/" + pb_Processed.Maximum.ToString();
            SwitchTitle(FETCH);
        }

        private void SwitchTitle(string title)
        {
            this.Text = title;
            this.Refresh();
        }

        public void StartCompare()
        {
            SwitchTitle(COMPARING);
        }

        public void setPosSrc(int value)
        {
            if (value <= pb_Processed.Maximum)
            {
                pb_Processed.Value = value;
                lb_Percentage.Text = pb_Processed.Maximum == 0 ? "100%" : (value * 100 / pb_Processed.Maximum).ToString() + "%";
                lb_Count.Text = value.ToString() + "/" + pb_Processed.Maximum.ToString();
            }

            if (value == pb_Processed.Maximum)
                this.SrcFinished = true;

            if (this.SrcFinished && this.TrgFinished)
            {
                bt_Finish.Text = FINISH;
                this.Text = DONE;
            }

            Application.DoEvents();
        }

        public void setPosTrg(int value)
        {
            if (value <= pb_ProcessedTrg.Maximum)
            {
                pb_ProcessedTrg.Value = value;
                lb_PercentageTrg.Text = pb_ProcessedTrg.Maximum == 0 ? "100%" : (value * 100 / pb_ProcessedTrg.Maximum).ToString() + "%";
                lb_CountTrg.Text = value.ToString() + "/" + pb_ProcessedTrg.Maximum.ToString();
            }

            if (value == pb_ProcessedTrg.Maximum)
                this.TrgFinished = true;

            if (this.SrcFinished && this.TrgFinished)
            {
                bt_Finish.Text = FINISH;
                this.Text = DONE;
            }
                
            Application.DoEvents();
        }


        private void ProgressBarForm_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }

        private void ProgressBarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
  
        }

        private void bt_Finish_Click(object sender, EventArgs e)
        {
            if (bt_Finish.Text == "Cancel")
                IsCancelled = true;
            this.Close();
        }

    }
}
