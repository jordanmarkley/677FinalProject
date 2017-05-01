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

        public ListView NewRequestListView
        {
            get
            {
                return newRequestListView;
            }

            set
            {
                newRequestListView = value;
            }
        }

        public ListView inProgressRequestListView
        {
            get
            {
                return inProgressRequestListView;
            }

            set
            {
                inProgressRequestListView = value;
            }
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

                    int rID = r.RequestID;

                    ListViewItem i = new ListViewItem(rID.ToString());
                    newRequestListView.Items.Remove(i);
                    inProgressRequestListView.Items.Add(i);
                }
            }
            else
            {
                MessageBox.Show("Please Select an Employee");
            }
        }

        private void viewRequestButton_Click(object sender, EventArgs e)
        {
            
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

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
