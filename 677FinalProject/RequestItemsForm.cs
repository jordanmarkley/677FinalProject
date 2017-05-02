using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _677FinalProject
{
    public partial class RequestItemsForm : Form
    {
        //Variables
        private int requestID;
        private RequestForm requestForm;

        public RequestItemsForm(int id, RequestForm rForm)
        {
            InitializeComponent();

            requestID = id;

            requestForm = rForm;
        }

        //Accessor for ID
        public int RequestID
        {
            get
            {
                return requestID;
            }
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

        //Handler for submit button
        private void submitButton_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();

            List<int> itemIDList = new List<int>();
            List<int> tempItemIDList = new List<int>();
            List<LineItem> request = new List<LineItem>();

            foreach(ListViewItem i in requestItemsListView.Items)
            {
                itemIDList.Add(Convert.ToInt32(i.Text));
            }

            foreach(int i in itemIDList)
            {

                if (!(tempItemIDList.Contains(i)))
                {
                    int itemID = i;
                    string description = null;
                    decimal price = 0;

                    SqlCommand cmd = new SqlCommand("SELECT ITEM_ID, DESCRIPTION, UNIT_PRICE FROM SOFTWAREHARDWARE WHERE ITEM_ID=@i", cnn);
                    cmd.Parameters.AddWithValue("@i", i);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        description = dr["DESCRIPTION"].ToString();
                        price = Convert.ToDecimal(dr["UNIT_PRICE"]);
                    }

                    LineItem lineItem = new LineItem(requestID, itemID, 1, price, price);

                    request.Add(lineItem);
                    tempItemIDList.Add(i);
                }
                else
                {
                    foreach(LineItem item in request)
                    {
                        if (item.ItemID == i)
                        {
                            item.Quantity++;
                            item.LineTotal = item.Quantity * item.ItemPrice;
                        }
                    }
                }
            }

            foreach (LineItem item in request)
            {
                SqlCommand addCmd = new SqlCommand("INSERT INTO LINE_ORDER(REQUEST_ID, ITEM_ID, QUANTITY, UNIT_PRICE, LINE_TOTAL, LINE_ITEM_ID) VALUES(@requestID, @itemID, @quantity, @unitPrice, @lineTotal, @lineItemID)", cnn);
                addCmd.Parameters.Add(new SqlParameter("@requestID", item.RequestID));
                addCmd.Parameters.Add(new SqlParameter("@itemID", item.ItemID));
                addCmd.Parameters.Add(new SqlParameter("@quantity", item.Quantity));
                addCmd.Parameters.Add(new SqlParameter("@unitPrice", item.ItemPrice));
                addCmd.Parameters.Add(new SqlParameter("@lineTotal", item.LineTotal));
                addCmd.Parameters.Add(new SqlParameter("@lineItemID", item.LineItemID));
                addCmd.ExecuteNonQuery();
            }

            SqlCommand updateRequestCmd = new SqlCommand("SELECT COUNTER FROM REQUEST WHERE REQUEST_ID = @reqID", cnn);
            updateRequestCmd.Parameters.AddWithValue("@reqID", requestID);
            updateRequestCmd.ExecuteNonQuery();
            SqlDataAdapter updateDA = new SqlDataAdapter(updateRequestCmd);
            DataTable updateDT = new DataTable();
            updateDA.Fill(updateDT);

            int counter = 0;
            decimal subtotal = Convert.ToDecimal(subtotalLabel.Text.ToString().TrimStart('$'));
            decimal salesTax = Convert.ToDecimal(salesTaxLabel.Text.ToString().TrimStart('$'));
            decimal totalPrice = Convert.ToDecimal(totalCostLabel.Text.ToString().TrimStart('$'));

            foreach (DataRow dr in updateDT.Rows)
            {
                counter = Convert.ToInt32(dr["COUNTER"]);
                counter++;
            }

            SqlCommand insertNewDataCmd = new SqlCommand("UPDATE REQUEST SET COUNTER = @counter, SUBTOTAL = @subtotal, SALES_TAX = @salesTax, TOTAL_PRICE = @totalPrice WHERE REQUEST_ID = @reqID", cnn);
            insertNewDataCmd.Parameters.AddWithValue("@counter", counter);
            insertNewDataCmd.Parameters.AddWithValue("@subtotal", subtotal);
            insertNewDataCmd.Parameters.AddWithValue("@salesTax", salesTax);
            insertNewDataCmd.Parameters.AddWithValue("@totalPrice", totalPrice);
            insertNewDataCmd.Parameters.AddWithValue("@reqID", requestID);
            insertNewDataCmd.ExecuteNonQuery();

            requestForm.Close();
            this.Close();
        }
    }
}
