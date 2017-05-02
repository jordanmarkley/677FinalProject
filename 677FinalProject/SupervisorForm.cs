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
    public partial class SupervisorForm : Form
    {
        //Variables
        int supID;

        public SupervisorForm(int id)
        {
            InitializeComponent();

            supID = id;

            FillNewRequestListView();

            FillCompletedRequestListView();
        }

        //Initially fill the New Requests Waiting for the supervisor
        private void FillNewRequestListView()
        {
            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand cmd = new SqlCommand("SELECT REQUEST_ID FROM REQUEST WHERE COUNTER = 1 AND SUPERVISOR = @supID", cnn);
            cmd.Parameters.AddWithValue("@supID", supID);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int requestId = Convert.ToInt32(dr["REQUEST_ID"]);
                ListViewItem i = new ListViewItem(requestId.ToString());
                newRequestListView.Items.Add(i);
            }
            database.close();
        }

        //Initially fill the completed request list view
        private void FillCompletedRequestListView()
        {
            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand cmd = new SqlCommand("SELECT REQUEST_ID FROM REQUEST WHERE COUNTER > 1 AND SUPERVISOR = @supID", cnn);
            cmd.Parameters.AddWithValue("@supID", supID);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int requestId = Convert.ToInt32(dr["REQUEST_ID"]);
                ListViewItem i = new ListViewItem(requestId.ToString());
                inPogressRequestListView.Items.Add(i);
            }
            database.close();
        }

        //Handler for the complete request button
        private void completeRequestButton_Click(object sender, EventArgs e)
        {
            int requestId = 0;
            int empId = 0;
            int supId = supID;
            string date = null;
            int status = 0;

            if (newRequestListView.SelectedItems.Count == 1)
            {
                foreach (ListViewItem i in newRequestListView.SelectedItems)
                {
                    requestId = Convert.ToInt32(i.SubItems[0].Text);
                }

                DialogResult result = MessageBox.Show("Are you sure you want to complete request #" + requestId.ToString() + "?", "Complete Request", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    SqlConnection cnn = new SqlConnection();
                    DBcnn database = new DBcnn(cnn);
                    database.connect(null);
                    database.open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM REQUEST WHERE REQUEST_ID=@requestId", cnn);
                    cmd.Parameters.AddWithValue("@requestId", requestId);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    database.close();
                    foreach (DataRow dr in dt.Rows)
                    {
                        empId = Convert.ToInt32(dr["EMPLOYEE_ID"]);
                        status = Convert.ToInt32(dr["COUNTER"]);
                        date = dr["EMPLOYEE_ID"].ToString();
                    }

                    Request request = new Request(requestId, supId, empId, 0, 0, 0, date);
                    RequestForm r = new RequestForm(requestId);
                    string employeeName = GetEmployeeName(empId);
                    r.EmployeeNameLabel = employeeName;

                    r.ShowDialog();

                    RefreshListViews();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Request.");
            }
        }

        //Handler for the view request button
        private void viewRequestButton_Click(object sender, EventArgs e)
        {
            SupervisorViewRequestForm viewRequestForm = new SupervisorViewRequestForm();
            List<LineItem> request = new List<LineItem>();
            List<int> idForDescription = new List<int>();
            List<string> descriptionList = new List<string>();
            int requestID = 0;
            int itemID = 0;
            int quantity = 0;
            string description = null;
            decimal price = 0;
            decimal lineTotal = 0;

            if(inPogressRequestListView.SelectedItems.Count == 1)
            {
                foreach(ListViewItem i in inPogressRequestListView.SelectedItems)
                {
                    requestID = Convert.ToInt32(i.SubItems[0].Text);
                }
                SqlConnection cnn = new SqlConnection();
                DBcnn database = new DBcnn(cnn);
                database.connect(null);
                database.open();
                SqlCommand cmd = new SqlCommand("SELECT QUANTITY, ITEM_ID, UNIT_PRICE, LINE_TOTAL FROM LINE_ORDER WHERE REQUEST_ID = @requestID", cnn);
                cmd.Parameters.AddWithValue("@requestID", requestID);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                database.close();
                foreach(DataRow dr in dt.Rows)
                {
                    quantity = Convert.ToInt32(dr["QUANTITY"]);
                    itemID = Convert.ToInt32(dr["ITEM_ID"]);
                    price = Convert.ToDecimal(dr["UNIT_PRICE"]);
                    lineTotal = Convert.ToDecimal(dr["LINE_TOTAL"]);

                    LineItem item = new LineItem(requestID, itemID, quantity, price, lineTotal);

                    request.Add(item);
                }

                foreach(LineItem item in request)
                {
                    idForDescription.Add(item.ItemID);
                }

                foreach(int id in idForDescription)
                {
                    database.connect(null);
                    database.open();
                    SqlCommand descriptionCmd = new SqlCommand("SELECT DESCRIPTION FROM SOFTWAREHARDWARE WHERE ITEM_ID = @id", cnn);
                    descriptionCmd.Parameters.AddWithValue("@id", id);
                    descriptionCmd.ExecuteNonQuery();
                    SqlDataAdapter descriptionda = new SqlDataAdapter(descriptionCmd);
                    DataTable descriptiondt = new DataTable();
                    descriptionda.Fill(descriptiondt);
                    database.close();
                    foreach(DataRow dr in descriptiondt.Rows)
                    {
                        description = dr["DESCRIPTION"].ToString().TrimEnd(' ');

                        descriptionList.Add(description);
                    }
                }

                for(int i = 0; i < request.Count; i++)
                {
                    ListViewItem item = new ListViewItem(request[i].Quantity.ToString());
                    item.SubItems.Add(descriptionList[i]);
                    item.SubItems.Add(request[i].ItemPrice.ToString("C2"));
                    item.SubItems.Add(request[i].LineTotal.ToString("C2"));

                    viewRequestForm.RequestListView.Items.Add(item);
                }
                viewRequestForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a Request.");
            }
        }

        //Retreives the employee's name based off of their employee ID
        private string GetEmployeeName(int eID)
        {
            string employeeName = null;

            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand cmd = new SqlCommand("SELECT FIRST_NAME, LAST_NAME FROM EMPLOYEES WHERE EMPLOYEE_ID=@eID", cnn);
            cmd.Parameters.AddWithValue("@eID", eID);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                employeeName = dr["FIRST_NAME"].ToString() + " " + dr["LAST_NAME"].ToString();
            }

            return employeeName;
        }

        //Refresh the listviews with items from the database
        private void RefreshListViews()
        {
            int requestID;

            newRequestListView.Items.Clear();
            inPogressRequestListView.Items.Clear();

            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand cmd = new SqlCommand("SELECT REQUEST_ID FROM REQUEST WHERE SUPERVISOR=@supID AND COUNTER = 1", cnn);
            cmd.Parameters.AddWithValue("@supID", supID);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                requestID = Convert.ToInt32(dr["REQUEST_ID"]);

                ListViewItem i = new ListViewItem(requestID.ToString());

                newRequestListView.Items.Add(i);
            }

            SqlCommand newCmd = new SqlCommand("SELECT REQUEST_ID FROM REQUEST WHERE SUPERVISOR=@supID AND COUNTER = 2", cnn);
            newCmd.Parameters.AddWithValue("@supID", supID);
            newCmd.ExecuteNonQuery();
            SqlDataAdapter newda = new SqlDataAdapter(newCmd);
            DataTable newdt = new DataTable();
            newda.Fill(newdt);
            database.close();
            foreach (DataRow dr in newdt.Rows)
            {
                requestID = Convert.ToInt32(dr["REQUEST_ID"]);

                ListViewItem i = new ListViewItem(requestID.ToString());

                inPogressRequestListView.Items.Add(i);
            }
        }

        //Handler for the log out button
        private void logOutButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you would like to log out?", "Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
