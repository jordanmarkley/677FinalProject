namespace _677FinalProject
{
    partial class BuildTeam
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.requestID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.requestSupervisor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewRequestButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.requestID,
            this.requestSupervisor});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(28, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(275, 167);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // requestID
            // 
            this.requestID.Text = "Request ID";
            this.requestID.Width = 113;
            // 
            // requestSupervisor
            // 
            this.requestSupervisor.Text = "Supervisor";
            this.requestSupervisor.Width = 156;
            // 
            // viewRequestButton
            // 
            this.viewRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewRequestButton.Location = new System.Drawing.Point(157, 204);
            this.viewRequestButton.Name = "viewRequestButton";
            this.viewRequestButton.Size = new System.Drawing.Size(146, 40);
            this.viewRequestButton.TabIndex = 5;
            this.viewRequestButton.Text = "View Request";
            this.viewRequestButton.UseVisualStyleBackColor = true;
            // 
            // logOutButton
            // 
            this.logOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.Location = new System.Drawing.Point(157, 250);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(146, 40);
            this.logOutButton.TabIndex = 6;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            // 
            // BuildTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 315);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.viewRequestButton);
            this.Controls.Add(this.listView1);
            this.Name = "BuildTeam";
            this.Text = "BuildTeam";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader requestID;
        private System.Windows.Forms.ColumnHeader requestSupervisor;
        private System.Windows.Forms.Button viewRequestButton;
        private System.Windows.Forms.Button logOutButton;
    }
}