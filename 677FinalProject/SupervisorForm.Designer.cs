namespace _677FinalProject
{
    partial class SupervisorForm
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
            this.logOutButton = new System.Windows.Forms.Button();
            this.viewRequestButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.newRequestListView = new System.Windows.Forms.ListView();
            this.requestID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inPogressRequestListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.completeRequestButton = new System.Windows.Forms.Button();
            this.metricsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logOutButton
            // 
            this.logOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.Location = new System.Drawing.Point(283, 425);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(146, 40);
            this.logOutButton.TabIndex = 7;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // viewRequestButton
            // 
            this.viewRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewRequestButton.Location = new System.Drawing.Point(249, 312);
            this.viewRequestButton.Name = "viewRequestButton";
            this.viewRequestButton.Size = new System.Drawing.Size(119, 50);
            this.viewRequestButton.TabIndex = 6;
            this.viewRequestButton.Text = "View Request";
            this.viewRequestButton.UseVisualStyleBackColor = true;
            this.viewRequestButton.Click += new System.EventHandler(this.viewRequestButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, -32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Requests:";
            // 
            // newRequestListView
            // 
            this.newRequestListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.requestID});
            this.newRequestListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newRequestListView.FullRowSelect = true;
            this.newRequestListView.GridLines = true;
            this.newRequestListView.Location = new System.Drawing.Point(41, 64);
            this.newRequestListView.Name = "newRequestListView";
            this.newRequestListView.Size = new System.Drawing.Size(136, 242);
            this.newRequestListView.TabIndex = 4;
            this.newRequestListView.UseCompatibleStateImageBehavior = false;
            this.newRequestListView.View = System.Windows.Forms.View.Details;
            // 
            // requestID
            // 
            this.requestID.Text = "Request ID";
            this.requestID.Width = 113;
            // 
            // inPogressRequestListView
            // 
            this.inPogressRequestListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.inPogressRequestListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inPogressRequestListView.FullRowSelect = true;
            this.inPogressRequestListView.GridLines = true;
            this.inPogressRequestListView.Location = new System.Drawing.Point(239, 64);
            this.inPogressRequestListView.Name = "inPogressRequestListView";
            this.inPogressRequestListView.Size = new System.Drawing.Size(136, 242);
            this.inPogressRequestListView.TabIndex = 8;
            this.inPogressRequestListView.UseCompatibleStateImageBehavior = false;
            this.inPogressRequestListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Request ID";
            this.columnHeader1.Width = 113;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "New Requests:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(235, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "In Progress Requests:";
            // 
            // completeRequestButton
            // 
            this.completeRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeRequestButton.Location = new System.Drawing.Point(50, 312);
            this.completeRequestButton.Name = "completeRequestButton";
            this.completeRequestButton.Size = new System.Drawing.Size(120, 50);
            this.completeRequestButton.TabIndex = 11;
            this.completeRequestButton.Text = "Complete Request";
            this.completeRequestButton.UseVisualStyleBackColor = true;
            this.completeRequestButton.Click += new System.EventHandler(this.completeRequestButton_Click);
            // 
            // metricsButton
            // 
            this.metricsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metricsButton.Location = new System.Drawing.Point(283, 379);
            this.metricsButton.Name = "metricsButton";
            this.metricsButton.Size = new System.Drawing.Size(146, 40);
            this.metricsButton.TabIndex = 13;
            this.metricsButton.Text = "Metrics";
            this.metricsButton.UseVisualStyleBackColor = true;
            this.metricsButton.Click += new System.EventHandler(this.metricsButton_Click);
            // 
            // SupervisorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 478);
            this.Controls.Add(this.metricsButton);
            this.Controls.Add(this.completeRequestButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inPogressRequestListView);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.viewRequestButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newRequestListView);
            this.Name = "SupervisorForm";
            this.Text = "Supervisor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button viewRequestButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView newRequestListView;
        private System.Windows.Forms.ColumnHeader requestID;
        private System.Windows.Forms.ListView inPogressRequestListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button completeRequestButton;
        private System.Windows.Forms.Button metricsButton;
    }
}