namespace WindowsFormsApplication1
{
    partial class ProgressBarFrom
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
            this.pb_Processed = new System.Windows.Forms.ProgressBar();
            this.lb_Percentage = new System.Windows.Forms.Label();
            this.lb_Count = new System.Windows.Forms.Label();
            this.bt_Finish = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_ProcessedTrg = new System.Windows.Forms.ProgressBar();
            this.lb_PercentageTrg = new System.Windows.Forms.Label();
            this.lb_CountTrg = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pb_Processed
            // 
            this.pb_Processed.Location = new System.Drawing.Point(88, 25);
            this.pb_Processed.Name = "pb_Processed";
            this.pb_Processed.Size = new System.Drawing.Size(366, 21);
            this.pb_Processed.TabIndex = 0;
            this.pb_Processed.UseWaitCursor = true;
            // 
            // lb_Percentage
            // 
            this.lb_Percentage.AutoSize = true;
            this.lb_Percentage.Location = new System.Drawing.Point(248, 9);
            this.lb_Percentage.Name = "lb_Percentage";
            this.lb_Percentage.Size = new System.Drawing.Size(21, 13);
            this.lb_Percentage.TabIndex = 1;
            this.lb_Percentage.Text = "0%";
            // 
            // lb_Count
            // 
            this.lb_Count.AutoSize = true;
            this.lb_Count.Location = new System.Drawing.Point(373, 9);
            this.lb_Count.Name = "lb_Count";
            this.lb_Count.Size = new System.Drawing.Size(54, 13);
            this.lb_Count.TabIndex = 2;
            this.lb_Count.Text = "0/100000";
            // 
            // bt_Finish
            // 
            this.bt_Finish.Location = new System.Drawing.Point(353, 106);
            this.bt_Finish.Name = "bt_Finish";
            this.bt_Finish.Size = new System.Drawing.Size(101, 23);
            this.bt_Finish.TabIndex = 3;
            this.bt_Finish.Text = "Cancel";
            this.bt_Finish.UseVisualStyleBackColor = true;
            this.bt_Finish.Click += new System.EventHandler(this.bt_Finish_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source Table:";
            // 
            // pb_ProcessedTrg
            // 
            this.pb_ProcessedTrg.Location = new System.Drawing.Point(88, 67);
            this.pb_ProcessedTrg.Name = "pb_ProcessedTrg";
            this.pb_ProcessedTrg.Size = new System.Drawing.Size(366, 21);
            this.pb_ProcessedTrg.TabIndex = 0;
            this.pb_ProcessedTrg.UseWaitCursor = true;
            // 
            // lb_PercentageTrg
            // 
            this.lb_PercentageTrg.AutoSize = true;
            this.lb_PercentageTrg.Location = new System.Drawing.Point(248, 51);
            this.lb_PercentageTrg.Name = "lb_PercentageTrg";
            this.lb_PercentageTrg.Size = new System.Drawing.Size(21, 13);
            this.lb_PercentageTrg.TabIndex = 1;
            this.lb_PercentageTrg.Text = "0%";
            // 
            // lb_CountTrg
            // 
            this.lb_CountTrg.AutoSize = true;
            this.lb_CountTrg.Location = new System.Drawing.Point(373, 51);
            this.lb_CountTrg.Name = "lb_CountTrg";
            this.lb_CountTrg.Size = new System.Drawing.Size(54, 13);
            this.lb_CountTrg.TabIndex = 2;
            this.lb_CountTrg.Text = "0/100000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Target Table:";
            // 
            // ProgressBarFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 141);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Finish);
            this.Controls.Add(this.lb_CountTrg);
            this.Controls.Add(this.lb_Count);
            this.Controls.Add(this.lb_PercentageTrg);
            this.Controls.Add(this.lb_Percentage);
            this.Controls.Add(this.pb_ProcessedTrg);
            this.Controls.Add(this.pb_Processed);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressBarFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProgressBarForm_FormClosed);
            this.Load += new System.EventHandler(this.ProgressBarForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_Processed;
        private System.Windows.Forms.Label lb_Percentage;
        private System.Windows.Forms.Label lb_Count;
        private System.Windows.Forms.Button bt_Finish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pb_ProcessedTrg;
        private System.Windows.Forms.Label lb_PercentageTrg;
        private System.Windows.Forms.Label lb_CountTrg;
        private System.Windows.Forms.Label label4;
    }
}