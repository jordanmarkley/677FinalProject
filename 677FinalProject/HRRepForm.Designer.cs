﻿namespace _677FinalProject
{
    partial class HRRepForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.requestID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.requestSupervisor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.requestStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewRequestButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.employeeID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.employeeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.background = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.viewEmployeeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Requests:";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.requestID,
            this.requestSupervisor,
            this.requestStatus});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(27, 57);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(379, 167);
            this.listView1.TabIndex = 2;
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
            // requestStatus
            // 
            this.requestStatus.Text = "Status";
            this.requestStatus.Width = 101;
            // 
            // viewRequestButton
            // 
            this.viewRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewRequestButton.Location = new System.Drawing.Point(260, 234);
            this.viewRequestButton.Name = "viewRequestButton";
            this.viewRequestButton.Size = new System.Drawing.Size(146, 40);
            this.viewRequestButton.TabIndex = 4;
            this.viewRequestButton.Text = "View Request";
            this.viewRequestButton.UseVisualStyleBackColor = true;
            this.viewRequestButton.Click += new System.EventHandler(this.viewRequestButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.Location = new System.Drawing.Point(260, 557);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(146, 40);
            this.logOutButton.TabIndex = 6;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.employeeID,
            this.employeeName,
            this.background});
            this.listView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(27, 314);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(379, 167);
            this.listView2.TabIndex = 7;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // employeeID
            // 
            this.employeeID.Text = "EmployeeID";
            this.employeeID.Width = 113;
            // 
            // employeeName
            // 
            this.employeeName.Text = "Employee";
            this.employeeName.Width = 156;
            // 
            // background
            // 
            this.background.Text = "Pass/Fail";
            this.background.Width = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Employees:";
            // 
            // viewEmployeeButton
            // 
            this.viewEmployeeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewEmployeeButton.Location = new System.Drawing.Point(229, 496);
            this.viewEmployeeButton.Name = "viewEmployeeButton";
            this.viewEmployeeButton.Size = new System.Drawing.Size(177, 40);
            this.viewEmployeeButton.TabIndex = 9;
            this.viewEmployeeButton.Text = "View Employee";
            this.viewEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(27, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 40);
            this.button1.TabIndex = 10;
            this.button1.Text = "Create Request";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // HRRepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 615);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.viewEmployeeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.viewRequestButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "HRRepForm";
            this.Text = "Human Resources";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader requestID;
        private System.Windows.Forms.ColumnHeader requestSupervisor;
        private System.Windows.Forms.ColumnHeader requestStatus;
        private System.Windows.Forms.Button viewRequestButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader employeeID;
        private System.Windows.Forms.ColumnHeader employeeName;
        private System.Windows.Forms.ColumnHeader background;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button viewEmployeeButton;
        private System.Windows.Forms.Button button1;
    }
}