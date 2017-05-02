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
    public partial class RequestForm : Form
    {
        //Variables
        private List<SoftwareHardware> itemList = new List<SoftwareHardware>();
        private int counter = 0;
        private int requestID;
        RequestItemsForm ri;

        public RequestForm(int id)
        {
            InitializeComponent();

            requestID = id;

            ri = new RequestItemsForm(requestID, this);

            FillList();
        }

        public int RequestID
        {
            get
            {
                return requestID;
            }
        }

        //Fill the List view with the updated information in the SOFTWAREHARDWARE table in the
        //database each time the form is loaded so that the most recent info can be loaded each time.
        public void FillList()
        {
            SqlConnection conn = new SqlConnection("Data Source=10.135.85.168;Initial Catalog=Group5;User ID=Group5;Password=Grp52116%");
            SqlCommand cmd = new SqlCommand("SELECT * FROM SOFTWAREHARDWARE", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["ITEM_ID"]);
                string descripotion = dr["DESCRIPTION"].ToString();
                double price = Convert.ToDouble(dr["UNIT_PRICE"]);

                SoftwareHardware item = new SoftwareHardware(id, descripotion, price);
                itemList.Add(item);
            }

            foreach(SoftwareHardware item in itemList)
            {
                int id = item.ItemID;
                string desc = item.Description;
                double price = item.Price;
                ListViewItem i = new ListViewItem(id.ToString());
                i.SubItems.Add(desc);
                i.SubItems.Add(price.ToString("C2"));
                requestListView.Items.Add(i);
            }

            
        }

        //Add an item to request items list view
        private void addItemButton_Click(object sender, EventArgs e)
        {
            if(requestListView.SelectedItems.Count == 1)
            {
                //ensures that a fresh, new form is loaded
                if (counter == 0)
                {
                    ri.Show();
                    counter++;
                }

                foreach (ListViewItem i in requestListView.SelectedItems)
                {
                    ri.RequestItemsListView.Items.Add((ListViewItem)i.Clone());
                }

                //update totals
                ri.updateTotals();
            }
            else
            {
                MessageBox.Show("Please Select an Item");
            }
        }

        public string EmployeeNameLabel
        {
            set
            {
                employeeNameLabel.Text = value;
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
