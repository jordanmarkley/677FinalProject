namespace _677FinalProject
{
    partial class SupervisorViewRequestForm
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
            this.requestListView = new System.Windows.Forms.ListView();
            this.qantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.desription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lineTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(506, 349);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(82, 32);
            this.exitButton.TabIndex = 19;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // requestListView
            // 
            this.requestListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.qantity,
            this.desription,
            this.price,
            this.lineTotal});
            this.requestListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestListView.GridLines = true;
            this.requestListView.Location = new System.Drawing.Point(30, 35);
            this.requestListView.Name = "requestListView";
            this.requestListView.Size = new System.Drawing.Size(558, 305);
            this.requestListView.TabIndex = 18;
            this.requestListView.UseCompatibleStateImageBehavior = false;
            this.requestListView.View = System.Windows.Forms.View.Details;
            // 
            // qantity
            // 
            this.qantity.Text = "Quantity";
            this.qantity.Width = 79;
            // 
            // desription
            // 
            this.desription.Text = "Description";
            this.desription.Width = 293;
            // 
            // price
            // 
            this.price.Text = "Price";
            this.price.Width = 83;
            // 
            // lineTotal
            // 
            this.lineTotal.Text = "Line Total";
            this.lineTotal.Width = 98;
            // 
            // SupervisorViewRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 409);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.requestListView);
            this.Name = "SupervisorViewRequestForm";
            this.Text = "SupervisorViewRequestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ListView requestListView;
        private System.Windows.Forms.ColumnHeader qantity;
        private System.Windows.Forms.ColumnHeader desription;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader lineTotal;
    }
}