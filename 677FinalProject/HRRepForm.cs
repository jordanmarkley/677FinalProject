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
    public partial class HRRepForm : Form
    {
        public HRRepForm()
        {
            InitializeComponent();

            fillListView();

            FillRequestListView();
        }

        //Variables
        private List<NewHire> newHireList = new List<NewHire>();

        //open the selected request
        private void viewRequestButton_Click(object sender, EventArgs e)
        {
            int requestId = 0;
            int counter = 0;
            string date = null;
            int supervisorId = 0;
            int employeeId = 0;
            string supervisorName = null;
            string employeeName = null;

            if (requestListView.SelectedItems.Count > 0 && requestListView.SelectedItems.Count < 2)
            {
                foreach (ListViewItem i in requestListView.SelectedItems)
                {
                    requestId = Convert.ToInt32(i.SubItems[0].Text);
                }

                SqlConnection cnn = new SqlConnection();
                DBcnn database = new DBcnn(cnn);
                database.connect(null);
                database.open();
                SqlCommand cmd = new SqlCommand(@"SELECT REQUEST_ID, COUNTER, DATE, SUPERVISOR, EMPLOYEE_ID FROM REQUEST 
                                        WHERE REQUEST_ID=@requestId", cnn);
                cmd.Parameters.AddWithValue("@requestId", requestId);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    counter = Convert.ToInt32(dr["COUNTER"]);
                    date = dr["DATE"].ToString();
                    supervisorId = Convert.ToInt32(dr["SUPERVISOR"]);
                    employeeId = Convert.ToInt32(dr["EMPLOYEE_ID"]);
                }

                SqlCommand supervisorCmd = new SqlCommand(@"SELECT FIRST_NAME, LAST_NAME FROM EMPLOYEES WHERE EMPLOYEE_ID=@supervisorId", cnn);
                supervisorCmd.Parameters.AddWithValue("@supervisorId", supervisorId);
                supervisorCmd.ExecuteNonQuery();
                SqlDataAdapter supDA = new SqlDataAdapter(supervisorCmd);
                DataTable supDT = new DataTable();
                supDA.Fill(supDT);
                foreach (DataRow dr in supDT.Rows)
                {
                    supervisorName = dr["FIRST_NAME"].ToString() + " " + dr["LAST_NAME"].ToString();
                }

                SqlCommand employeeCmd = new SqlCommand(@"SELECT FIRST_NAME, LAST_NAME FROM EMPLOYEES WHERE EMPLOYEE_ID=@employeeId", cnn);
                employeeCmd.Parameters.AddWithValue("@employeeId", employeeId);
                employeeCmd.ExecuteNonQuery();
                SqlDataAdapter empDA = new SqlDataAdapter(employeeCmd);
                DataTable empDT = new DataTable();
                empDA.Fill(empDT);
                database.close();
                foreach (DataRow dr in empDT.Rows)
                {
                    employeeName = dr["FIRST_NAME"].ToString() + " " + dr["LAST_NAME"].ToString();
                }

                HRViewRequestForm hrv = new HRViewRequestForm();

                hrv.RequestIDLabel = requestId.ToString();
                hrv.EmployeeLabel = employeeName;
                hrv.SupervisorLabel = supervisorName;
                hrv.RequestDateLabel = date;
                if (counter == 1)
                {
                    hrv.StatusLabel = "Awaiting Supervisor to choose Items";
                }
                else if (counter == 2)
                {
                    hrv.StatusLabel = "Awaiting Manager approval";
                }
                else if (counter == 3)
                {
                    hrv.StatusLabel = "Request Being Build";
                }
                else if (counter == 4)
                {
                    hrv.StatusLabel = "Request Complete";
                }

                hrv.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an employee");
            }
        }

        //Initially fill the listview with employees
        private void fillListView()
        {
            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand cmd = new SqlCommand("SELECT EMPLOYEE_ID, LAST_NAME, BACKGROUND FROM EMPLOYEES WHERE TITLE = 'New Hire'", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["EMPLOYEE_ID"]);
                string lastName = dr["LAST_NAME"].ToString().Trim(' ');
                string background = dr["BACKGROUND"].ToString().Trim(' ');

                NewHire newHire = new NewHire(id, lastName, background);
                newHireList.Add(newHire);
            }

            foreach (NewHire newHire in newHireList)
            {
                int id = newHire.ID;
                string lastName = newHire.LastName;
                string background = newHire.Background;
                ListViewItem i = new ListViewItem(id.ToString());
                i.SubItems.Add(lastName);
                i.SubItems.Add(background);
                employeeListView.Items.Add(i);
            }
        }

        //handle for an hr representative creating a new request
        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            string background = null;

            if(employeeListView.SelectedItems.Count > 0 && employeeListView.SelectedItems.Count < 2)
            {
                foreach(ListViewItem i in employeeListView.SelectedItems)
                {
                    id = Convert.ToInt32(i.SubItems[0].Text);
                }

                foreach (ListViewItem i in employeeListView.SelectedItems)
                {
                    background = i.SubItems[2].Text.ToString().Trim(' ');
                }

                if(background == "Failed")
                {
                    MessageBox.Show("You cannot create a request for this employee because they have not passed their background check.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to create a request for employee " + id.ToString() + "?", "Create Request", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        int supID = 0;
                        CheckSuperiorForm supForm = new CheckSuperiorForm();
                        supForm.ShowDialog();
                        supID = supForm.getSupervisorID();

                        //Create new request
                        Request r = new Request(id, supID);

                        SqlConnection cnn = new SqlConnection();
                        DBcnn database = new DBcnn(cnn);
                        database.connect(null);
                        database.open();
                        SqlCommand add = new SqlCommand("INSERT INTO REQUEST(REQUEST_ID, COUNTER, DATE, SUPERVISOR, EMPLOYEE_ID) VALUES(@requestID, @counter, @date, @supervisor, @employeeID)", cnn);
                        add.Parameters.Add(new SqlParameter("@requestID", r.RequestID));
                        add.Parameters.Add(new SqlParameter("@counter", r.Status));
                        add.Parameters.Add(new SqlParameter("@date", r.Date));
                        add.Parameters.Add(new SqlParameter("@supervisor", r.SupervisorID));
                        add.Parameters.Add(new SqlParameter("@employeeID", r.EmployeeID));
                        add.ExecuteNonQuery();
                        database.close();

                        ConcatenateListView();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to create a request for.");
            }
        }

        //initially fills the request list view on the form
        private void FillRequestListView()
        {

            List<Request> requestList = new List<Request>();

            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM REQUEST", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int rID = Convert.ToInt32(dr["REQUEST_ID"]);
                int sID = Convert.ToInt32(dr["SUPERVISOR"]);
                int status = Convert.ToInt32(dr["COUNTER"]);

                Request r = new Request(rID, sID, status);
                requestList.Add(r);
            }

            foreach (Request r in requestList)
            {
                int rID = r.RequestID;
                int sID = r.SupervisorID;
                int status = r.Status;
                ListViewItem i = new ListViewItem(rID.ToString());
                i.SubItems.Add(sID.ToString());
                if(status == 1)
                {
                    i.SubItems.Add("Awaiting Supervisor to choose Items");
                }
                else if (status == 2)
                {
                    i.SubItems.Add("Awaiting Manager approval");
                }
                else if (status == 3)
                {
                    i.SubItems.Add("Request Being Build");
                }
                else if (status == 4)
                {
                    i.SubItems.Add("Request Complete");
                }
                requestListView.Items.Add(i);
            }
        }

        //Adds on a new request that is created into the list view
        private void ConcatenateListView()
        {
            List<Request> requestList = new List<Request>();

            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM REQUEST", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int rID = Convert.ToInt32(dr["REQUEST_ID"]);
                int sID = Convert.ToInt32(dr["SUPERVISOR"]);
                int status = Convert.ToInt32(dr["COUNTER"]);

                Request r = new Request(rID, sID, status);
                requestList.Add(r);
            }

            Request lastItem = requestList[requestList.Count - 1];

            int reqID = lastItem.RequestID;
            int supID = lastItem.SupervisorID;
            int stat = lastItem.Status;
            ListViewItem i = new ListViewItem(reqID.ToString());
            i.SubItems.Add(supID.ToString());
            if (stat == 1)
            {
                i.SubItems.Add("Awaiting Supervisor to choose Items");
            }
            else if (stat == 2)
            {
                i.SubItems.Add("Awaiting Manager approval");
            }
            else if (stat == 3)
            {
                i.SubItems.Add("Request Being Build");
            }
            else if (stat == 4)
            {
                i.SubItems.Add("Request Complete");
            }
            requestListView.Items.Add(i);
        }

        //pulls employee's information and displays it
        private void viewEmployeeButton_Click(object sender, EventArgs e)
        {
            int id = 0;

            if (employeeListView.SelectedItems.Count > 0 && employeeListView.SelectedItems.Count < 2)
            {
                foreach (ListViewItem i in employeeListView.SelectedItems)
                {
                    id = Convert.ToInt32(i.SubItems[0].Text);
                }

                SqlConnection cnn = new SqlConnection();
                DBcnn database = new DBcnn(cnn);
                database.connect(null);
                database.open();
                SqlCommand cmd = new SqlCommand(@"SELECT EMPLOYEE_ID, FIRST_NAME, LAST_NAME, TITLE,  DATE_OF_BIRTH, BACKGROUND, GENDER FROM EMPLOYEES 
                                        WHERE EMPLOYEE_ID=@id", cnn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                database.close();

                string firstName = null;
                string lastName = null;
                string title = null;
                string dateOfBirth = null;
                string background = null;
                string gender = null;

                foreach (DataRow dr in dt.Rows)
                {
                    firstName = dr["FIRST_NAME"].ToString();
                    lastName = dr["LAST_NAME"].ToString();
                    title = dr["TITLE"].ToString();
                    dateOfBirth = dr["DATE_OF_BIRTH"].ToString();
                    background = dr["BACKGROUND"].ToString();
                    gender = dr["GENDER"].ToString();
                }

                ViewNewHireForm newHireForm = new ViewNewHireForm();

                newHireForm.EmployeeIDLabel = id.ToString();
                newHireForm.NameLabel = firstName.TrimEnd(' ') + " " + lastName.TrimEnd(' ');
                newHireForm.TitleLabel = title;
                newHireForm.DateOfBirthLabel = dateOfBirth;
                newHireForm.BackgroundStatusLabel = background;
                newHireForm.GenderLabel = gender;

                newHireForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an employee");
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you would like to log out?", "Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
