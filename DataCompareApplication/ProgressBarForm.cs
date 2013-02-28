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

        public bool Cancelled
        {
            get { return IsCancelled; }
        } 

        public ProgressBarFrom(int minimumSrc, int maximumSrc, int minimumTrg, int maximumTrg)
        {
            InitializeComponent();
            pb_Processed.Maximum = maximumSrc;
            pb_Processed.Value = pb_Processed.Minimum = minimumSrc;
            pb_ProcessedTrg.Maximum = maximumTrg;
            pb_ProcessedTrg.Value = pb_Processed.Minimum = minimumTrg;

        }

        public void setPosSrc(int value)
        {
            if (value <= pb_Processed.Maximum)
            {
                pb_Processed.Value = value;
                lb_Percentage.Text = (value * 100 / pb_Processed.Maximum).ToString() + "%";
                lb_Count.Text = value.ToString() + "/" + pb_Processed.Maximum.ToString();
            }

            if (value == pb_Processed.Maximum)
                this.SrcFinished = true;

            if (this.SrcFinished && this.TrgFinished)
                bt_Finish.Text = "Finish";

            Application.DoEvents();
        }

        public void setPosTrg(int value)
        {
            if (value <= pb_ProcessedTrg.Maximum)
            {
                pb_ProcessedTrg.Value = value;
                lb_PercentageTrg.Text = (value * 100 / pb_ProcessedTrg.Maximum).ToString() + "%";
                lb_CountTrg.Text = value.ToString() + "/" + pb_ProcessedTrg.Maximum.ToString();
            }

            if (value == pb_ProcessedTrg.Maximum)
                this.TrgFinished = true;

            if (this.SrcFinished && this.TrgFinished)
                bt_Finish.Text = "Finish";

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
