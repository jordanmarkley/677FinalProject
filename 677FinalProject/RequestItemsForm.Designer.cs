namespace _677FinalProject
{
    partial class RequestItemsForm
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
            this.requestItemsListView = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.desription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.salesTaxLabel = new System.Windows.Forms.Label();
            this.totalCostLabel = new System.Windows.Forms.Label();
            this.subtotalLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.requestItemsListView.Location = new System.Drawing.Point(30, 22);
            this.requestItemsListView.Name = "requestItemsListView";
            this.requestItemsListView.Size = new System.Drawing.Size(541, 305);
            this.requestItemsListView.TabIndex = 3;
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
            // salesTaxLabel
            // 
            this.salesTaxLabel.AutoSize = true;
            this.salesTaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesTaxLabel.Location = new System.Drawing.Point(506, 372);
            this.salesTaxLabel.Name = "salesTaxLabel";
            this.salesTaxLabel.Size = new System.Drawing.Size(65, 24);
            this.salesTaxLabel.TabIndex = 16;
            this.salesTaxLabel.Text = "###.##";
            // 
            // totalCostLabel
            // 
            this.totalCostLabel.AutoSize = true;
            this.totalCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCostLabel.Location = new System.Drawing.Point(506, 404);
            this.totalCostLabel.Name = "totalCostLabel";
            this.totalCostLabel.Size = new System.Drawing.Size(65, 24);
            this.totalCostLabel.TabIndex = 15;
            this.totalCostLabel.Text = "###.##";
            // 
            // subtotalLabel
            // 
            this.subtotalLabel.AutoSize = true;
            this.subtotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalLabel.Location = new System.Drawing.Point(506, 341);
            this.subtotalLabel.Name = "subtotalLabel";
            this.subtotalLabel.Size = new System.Drawing.Size(65, 24);
            this.subtotalLabel.TabIndex = 14;
            this.subtotalLabel.Text = "###.##";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(387, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(387, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Sales Tax";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(387, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Subtotal";
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(425, 444);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(146, 40);
            this.submitButton.TabIndex = 17;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(30, 341);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(146, 40);
            this.removeButton.TabIndex = 18;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // RequestItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 496);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.salesTaxLabel);
            this.Controls.Add(this.totalCostLabel);
            this.Controls.Add(this.subtotalLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.requestItemsListView);
            this.Name = "RequestItemsForm";
            this.Text = "RequestItemsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView requestItemsListView;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader desription;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.Label salesTaxLabel;
        private System.Windows.Forms.Label totalCostLabel;
        private System.Windows.Forms.Label subtotalLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button removeButton;
    }
}