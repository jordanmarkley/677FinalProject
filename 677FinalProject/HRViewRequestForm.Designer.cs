namespace _677FinalProject
{
    partial class HRViewRequestForm
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
            this.exitButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.requestItemsListView = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.desription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(503, 425);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(82, 32);
            this.exitButton.TabIndex = 17;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(248, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "Null";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(248, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "Null";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Employee:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Requesting Supervisor:";
            // 
            // requestItemsListView
            // 
            this.requestItemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.desription,
            this.price});
            this.requestItemsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestItemsListView.FullRowSelect = true;
            this.requestItemsListView.GridLines = true;
            this.requestItemsListView.Location = new System.Drawing.Point(27, 105);
            this.requestItemsListView.Name = "requestItemsListView";
            this.requestItemsListView.Size = new System.Drawing.Size(558, 305);
            this.requestItemsListView.TabIndex = 18;
            this.requestItemsListView.UseCompatibleStateImageBehavior = false;
            this.requestItemsListView.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 83;
            // 
            // desription
            // 
            this.desription.Text = "Description";
            this.desription.Width = 350;
            // 
            // price
            // 
            this.price.Text = "Price";
            this.price.Width = 83;
            // 
            // HRViewRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 482);
            this.Controls.Add(this.requestItemsListView);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HRViewRequestForm";
            this.Text = "View Request";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView requestItemsListView;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader desription;
        private System.Windows.Forms.ColumnHeader price;
    }
}