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
        }

        //open the selected request
        private void viewRequestButton_Click(object sender, EventArgs e)
        {
            HRViewRequestForm hrv = new HRViewRequestForm();
            hrv.ShowDialog();
        }

        //Variables
        private List<NewHire> newHireList = new List<NewHire>();

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

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            if(employeeListView.SelectedItems.Count > 0 && employeeListView.SelectedItems.Count < 2)
            {
                foreach(ListViewItem i in employeeListView.SelectedItems)
                {
                    id = Convert.ToInt32(i.SubItems[0].Text);
                }

                DialogResult result = MessageBox.Show("Are you sure you want to create a request for employee " + id.ToString() + "?", "Create Request", MessageBoxButtons.YesNo);

                if(result == DialogResult.Yes)
                {
                    int supID = 0;
                    CheckSuperiorForm supForm = new CheckSuperiorForm();
                    supForm.ShowDialog();
                    supID = supForm.getSupervisorID();
                    //Create new request
                    Request r = new Request();
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to create a request for.");
            }
        }
    }
}
