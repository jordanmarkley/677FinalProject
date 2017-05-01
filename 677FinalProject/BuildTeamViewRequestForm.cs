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
    public partial class BuildTeamViewRequestForm : Form
    {
        private int requestID = 0;
        private int buttonCounter = 0;

        public BuildTeamViewRequestForm(int rID)
        {
            InitializeComponent();

            requestID = rID;

            FillListView();
        }

        private void FillListView()
        {
            int quantity = 0;
            decimal unitPrice = 0;
            decimal lineTotal = 0;
            List<int> itemIDList = new List<int>();
            List<string> descriptionList = new List<string>();
            List<LineItem> request = new List<LineItem>();

            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand lineitemcmd = new SqlCommand("SELECT QUANTITY, ITEM_ID, UNIT_PRICE, LINE_TOTAL FROM LINE_ORDER WHERE REQUEST_ID = @requestID", cnn);
            lineitemcmd.Parameters.AddWithValue("@requestID", requestID);
            lineitemcmd.ExecuteNonQuery();
            SqlDataAdapter lineitemda = new SqlDataAdapter(lineitemcmd);
            DataTable lineitemdt = new DataTable();
            lineitemda.Fill(lineitemdt);
            database.close();
            foreach (DataRow dr in lineitemdt.Rows)
            {
                quantity = Convert.ToInt32(dr["QUANTITY"]);
                itemIDList.Add(Convert.ToInt32(dr["ITEM_ID"]));
                unitPrice = Convert.ToDecimal(dr["UNIT_PRICE"]);
                lineTotal = Convert.ToDecimal(dr["LINE_TOTAL"]);

                LineItem item = new LineItem(requestID, Convert.ToInt32(dr["ITEM_ID"]), quantity, unitPrice, lineTotal);

                request.Add(item);
            }

            database.open();
            foreach (int id in itemIDList)
            {
                SqlCommand descrCmd = new SqlCommand("SELECT DESCRIPTION FROM SOFTWAREHARDWARE WHERE ITEM_ID = @id", cnn);
                descrCmd.Parameters.AddWithValue("@id", id);
                descrCmd.ExecuteNonQuery();
                SqlDataAdapter descrda = new SqlDataAdapter(descrCmd);
                DataTable descrdt = new DataTable();
                descrda.Fill(descrdt);
                foreach (DataRow dr in descrdt.Rows)
                {
                    descriptionList.Add(dr["DESCRIPTION"].ToString());
                }
            }
            database.close();

            //Fill list view
            for (int i = 0; i < request.Count; i++)
            {
                ListViewItem item = new ListViewItem(" ");
                item.SubItems.Add(request[i].ItemID.ToString());
                item.SubItems.Add(descriptionList[i]);
                item.SubItems.Add(request[i].LineTotal.ToString());

                itemsListView.Items.Add(item);
            }
        }

        private void buildItemButton_Click(object sender, EventArgs e)
        {

            foreach(ListViewItem i in itemsListView.SelectedItems)
            {
                i.SubItems[0].Text = "X";
                buttonCounter++;
            }

            if(buttonCounter == itemsListView.Items.Count)
            {
                confirmRequestButton.Enabled = true;
                buildItemButton.Enabled = false;
            }
        }

        private void confirmRequestButton_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand reqcmd = new SqlCommand("UPDATE REQUEST SET COUNTER = 4 WHERE REQUEST_ID = @requestID", cnn);
            reqcmd.Parameters.AddWithValue("@requestID", requestID);
            reqcmd.ExecuteNonQuery();

            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
