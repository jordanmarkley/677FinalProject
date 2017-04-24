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
        public RequestForm()
        {
            InitializeComponent();

            FillList();
        }

        private RequestItemsForm ri = new RequestItemsForm();
        private List<SoftwareHardware> itemList = new List<SoftwareHardware>();

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
                i.SubItems.Add(price.ToString());
                requestListView.Items.Add(i);
            }

            
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {

            ri.Show();
            foreach(ListViewItem i in requestListView.SelectedItems)
            {
                ri.RequestItemsListView.Items.Add((ListViewItem)i.Clone());
            }
            this.Close();
        }
    }
}
