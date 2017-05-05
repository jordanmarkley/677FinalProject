namespace _677FinalProject
{
    partial class MetricsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.avgBuildTimeLabel = new System.Windows.Forms.Label();
            this.outstandingBuildsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Average Build Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of Outstanding Builds:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "(Days)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "(In progress requests that are over a week)";
            // 
            // avgBuildTimeLabel
            // 
            this.avgBuildTimeLabel.AutoSize = true;
            this.avgBuildTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgBuildTimeLabel.Location = new System.Drawing.Point(235, 25);
            this.avgBuildTimeLabel.Name = "avgBuildTimeLabel";
            this.avgBuildTimeLabel.Size = new System.Drawing.Size(43, 24);
            this.avgBuildTimeLabel.TabIndex = 4;
            this.avgBuildTimeLabel.Text = "Null";
            // 
            // outstandingBuildsLabel
            // 
            this.outstandingBuildsLabel.AutoSize = true;
            this.outstandingBuildsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outstandingBuildsLabel.Location = new System.Drawing.Point(323, 86);
            this.outstandingBuildsLabel.Name = "outstandingBuildsLabel";
            this.outstandingBuildsLabel.Size = new System.Drawing.Size(43, 24);
            this.outstandingBuildsLabel.TabIndex = 5;
            this.outstandingBuildsLabel.Text = "Null";
            // 
            // MetricsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 159);
            this.Controls.Add(this.outstandingBuildsLabel);
            this.Controls.Add(this.avgBuildTimeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MetricsForm";
            this.Text = "MetricsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label avgBuildTimeLabel;
        private System.Windows.Forms.Label outstandingBuildsLabel;
    }
}