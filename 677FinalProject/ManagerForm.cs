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
    public partial class ManagerForm : Form
    {
        //Variables
        private int reqID = 0;

        public ManagerForm()
        {
            InitializeComponent();

            FillListView();
        }

        /// <summary>
        /// Handler for the click of the View Request Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewRequestButton_Click(object sender, EventArgs e)
        {

            if(requestListView.SelectedItems.Count == 1)
            {
                foreach(ListViewItem i in requestListView.SelectedItems)
                {
                    reqID = Convert.ToInt32(i.Text);
                }

                ManagerViewRequestForm m = new ManagerViewRequestForm(reqID);
                m.ShowDialog();
                RefreshListViews();
            }
            else
            {
                MessageBox.Show("Please select a request to view.");
            }
        }

        //Initially fill the list view
        private void FillListView()
        {
            List<int> requestID = new List<int>();
            List<int> supervisorID = new List<int>();
            List<string> supervisorName = new List<string>();

            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand cmd = new SqlCommand("SELECT REQUEST_ID, SUPERVISOR FROM REQUEST WHERE COUNTER = 2", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            database.close();
            foreach(DataRow dr in dt.Rows)
            {
                requestID.Add(Convert.ToInt32(dr["REQUEST_ID"]));
                supervisorID.Add(Convert.ToInt32(dr["SUPERVISOR"]));
            }

            database.open();

            foreach (int id in supervisorID)
            {
                SqlCommand descCmd = new SqlCommand("SELECT FIRST_NAME, LAST_NAME FROM EMPLOYEES WHERE EMPLOYEE_ID=@id", cnn);
                descCmd.Parameters.AddWithValue("@id", id);
                descCmd.ExecuteNonQuery();
                SqlDataAdapter descda = new SqlDataAdapter(descCmd);
                DataTable descdt = new DataTable();
                descda.Fill(descdt);
                
                foreach(DataRow dr in descdt.Rows)
                {
                    supervisorName.Add(dr["FIRST_NAME"].ToString().TrimEnd(' ') + " " + dr["LAST_NAME"].ToString().TrimEnd(' '));
                }
            }

            database.close();

            for(int i = 0; i < requestID.Count; i++)
            {
                ListViewItem item = new ListViewItem(requestID[i].ToString());
                item.SubItems.Add(supervisorName[i]);
                requestListView.Items.Add(item);
            }
        }

        //Refreshes list view
        private void RefreshListViews()
        {
            requestListView.Items.Clear();

            List<int> requestID = new List<int>();
            List<int> supervisorID = new List<int>();
            List<string> supervisorName = new List<string>();

            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand cmd = new SqlCommand("SELECT REQUEST_ID, SUPERVISOR FROM REQUEST WHERE COUNTER = 2", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            database.close();
            foreach (DataRow dr in dt.Rows)
            {
                requestID.Add(Convert.ToInt32(dr["REQUEST_ID"]));
                supervisorID.Add(Convert.ToInt32(dr["SUPERVISOR"]));
            }

            database.open();

            foreach (int id in supervisorID)
            {
                SqlCommand descCmd = new SqlCommand("SELECT FIRST_NAME, LAST_NAME FROM EMPLOYEES WHERE EMPLOYEE_ID=@id", cnn);
                descCmd.Parameters.AddWithValue("@id", id);
                descCmd.ExecuteNonQuery();
                SqlDataAdapter descda = new SqlDataAdapter(descCmd);
                DataTable descdt = new DataTable();
                descda.Fill(descdt);

                foreach (DataRow dr in descdt.Rows)
                {
                    supervisorName.Add(dr["FIRST_NAME"].ToString().TrimEnd(' ') + " " + dr["LAST_NAME"].ToString().TrimEnd(' '));
                }
            }

            database.close();

            for (int i = 0; i < requestID.Count; i++)
            {
                ListViewItem item = new ListViewItem(requestID[i].ToString());
                item.SubItems.Add(supervisorName[i]);
                requestListView.Items.Add(item);
            }
        }

        //handler for the log out button
        private void logOutButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you would like to log out?", "Logout", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void metricsButton_Click(object sender, EventArgs e)
        {
            Metrics metrics = new Metrics();

            MetricsForm metricsForm = new MetricsForm();

            int numberOustandingBuilds = metrics.GetOutstandingBuilds();

            decimal averageBuildTime = metrics.AverageBuildTime();

            metricsForm.AverageBuildTimeLabel = averageBuildTime.ToString() + " Days";

            metricsForm.OutstandingBuildsLabel = numberOustandingBuilds.ToString();

            metricsForm.Show();
        }
    }
}
