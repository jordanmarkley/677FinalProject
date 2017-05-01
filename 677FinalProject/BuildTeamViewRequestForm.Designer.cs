namespace _677FinalProject
{
    partial class BuildTeamViewRequestForm
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
            this.itemsListView = new System.Windows.Forms.ListView();
            this.Complete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.desription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buildItemButton = new System.Windows.Forms.Button();
            this.confirmRequestButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemsListView
            // 
            this.itemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Complete,
            this.id,
            this.desription,
            this.price});
            this.itemsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsListView.FullRowSelect = true;
            this.itemsListView.GridLines = true;
            this.itemsListView.Location = new System.Drawing.Point(12, 23);
            this.itemsListView.Name = "itemsListView";
            this.itemsListView.Size = new System.Drawing.Size(629, 305);
            this.itemsListView.TabIndex = 4;
            this.itemsListView.UseCompatibleStateImageBehavior = false;
            this.itemsListView.View = System.Windows.Forms.View.Details;
            // 
            // Complete
            // 
            this.Complete.Text = "Complete";
            this.Complete.Width = 91;
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
            this.price.Width = 100;
            // 
            // buildItemButton
            // 
            this.buildItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildItemButton.Location = new System.Drawing.Point(495, 342);
            this.buildItemButton.Name = "buildItemButton";
            this.buildItemButton.Size = new System.Drawing.Size(146, 40);
            this.buildItemButton.TabIndex = 18;
            this.buildItemButton.Text = "Build Item";
            this.buildItemButton.UseVisualStyleBackColor = true;
            this.buildItemButton.Click += new System.EventHandler(this.buildItemButton_Click);
            // 
            // confirmRequestButton
            // 
            this.confirmRequestButton.Enabled = false;
            this.confirmRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmRequestButton.Location = new System.Drawing.Point(418, 388);
            this.confirmRequestButton.Name = "confirmRequestButton";
            this.confirmRequestButton.Size = new System.Drawing.Size(223, 40);
            this.confirmRequestButton.TabIndex = 19;
            this.confirmRequestButton.Text = "Confirm Request Build";
            this.confirmRequestButton.UseVisualStyleBackColor = true;
            this.confirmRequestButton.Click += new System.EventHandler(this.confirmRequestButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(495, 434);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(146, 40);
            this.closeButton.TabIndex = 20;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // BuildTeamViewRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 486);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.confirmRequestButton);
            this.Controls.Add(this.buildItemButton);
            this.Controls.Add(this.itemsListView);
            this.Name = "BuildTeamViewRequestForm";
            this.Text = "BuildTeamViewRequestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView itemsListView;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader desription;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.Button buildItemButton;
        private System.Windows.Forms.Button confirmRequestButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ColumnHeader Complete;
    }
}