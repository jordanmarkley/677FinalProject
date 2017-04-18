using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _677FinalProject
{
    public partial class ManagerViewRequestForm : Form
    {
        public ManagerViewRequestForm()
        {
            InitializeComponent();
        }

        //Getter and setter for the supervisor label
        public string SupervisorLabelText
        {
            get
            {
                return this.requestSupLabel.Text;
            }

            set
            {
                this.requestSupLabel.Text = value;
            }
        }

        //Getter and setter for the employee label
        public string EmployeeLabelText
        {
            get
            {
                return this.employeeLabel.Text;
            }

            set
            {
                this.employeeLabel.Text = value;
            }
        }

        //Getter and setter for the quanity value in the list view
        public int ListViewQuantityText
        {
            get
            {
                return Convert.ToInt32(this.requestListView.Columns["quantity"].Text);
            }

            set
            {
                this.requestListView.Columns["quantity"].Text = value.ToString();
            }
        }

        //Getter and setter for the description value in the list view
        public string ListViewDescriptionText
        {
            get
            {
                return this.requestListView.Columns["description"].Text;
            }

            set
            {
                this.requestListView.Columns["description"].Text = value;
            }
        }

        //Getter and setter for the price value in the list view
        public decimal ListViewPriceText
        {
            get
            {
                return Convert.ToDecimal(this.requestListView.Columns["price"].Text);
            }

            set
            {
                this.requestListView.Columns["price"].Text = value.ToString();
            }
        }

        //Getter and setter for the line total value in the list view
        public decimal ListViewLineTotalText
        {
            get
            {
                return Convert.ToDecimal(this.requestListView.Columns["lineTotal"].Text);
            }

            set
            {
                this.requestListView.Columns["lineTotal"].Text = value.ToString();
            }
        }
    }
}
