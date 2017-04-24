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
    public partial class RequestItemsForm : Form
    {
        public RequestItemsForm()
        {
            InitializeComponent();
        }

        //Getter and setter for List View
        public ListView RequestItemsListView
        {
            get
            {
                return requestItemsListView;
            }

            set
            {
                requestItemsListView = value;
            }
        }

        //Method to update the totals of the items selected and store into the labels
        public void updateTotals()
        {
            decimal subtotal = 0;
            const double TAX_RATE = .065;
            decimal total = 0;
            decimal salesTax = 0;

            foreach(ListViewItem i in requestItemsListView.Items)
            {
                subtotal += Convert.ToDecimal(i.SubItems[2].Text.ToString().TrimStart('$'));
                salesTax += (Convert.ToDecimal(TAX_RATE) * Convert.ToDecimal(i.SubItems[2].Text.ToString().TrimStart('$')));
            }

            total = subtotal + salesTax;

            subtotalLabel.Text = subtotal.ToString("C2");
            salesTaxLabel.Text = salesTax.ToString("C2");
            totalCostLabel.Text = total.ToString("C2");
        }

        //Remove an item from the list view
        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in RequestItemsListView.SelectedItems)
            {
                RequestItemsListView.Items.Remove(i);
            }

            //update the totals
            updateTotals();
        }
    }
}
