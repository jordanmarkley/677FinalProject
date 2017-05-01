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
    public partial class ManagerViewRequestForm : Form
    {

        private int requestID = 0;

        public ManagerViewRequestForm(int rID)
        {
            InitializeComponent();

            requestID = rID;

            FillForm();
        }

        //Populates form
        private void FillForm()
        {
            int counter;
            int supervisorID = 0;
            int employeeID = 0;
            string supervisorName = null;
            string employeeName = null;
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
            SqlCommand reqcmd = new SqlCommand("SELECT COUNTER, SUPERVISOR, EMPLOYEE_ID FROM REQUEST WHERE REQUEST_ID = @requestID", cnn);
            reqcmd.Parameters.AddWithValue("@requestID", requestID);
            reqcmd.ExecuteNonQuery();
            SqlDataAdapter reqda = new SqlDataAdapter(reqcmd);
            DataTable reqdt = new DataTable();
            reqda.Fill(reqdt);
            database.close();
            foreach(DataRow dr in reqdt.Rows)
            {
                counter = Convert.ToInt32(dr["COUNTER"]);
                supervisorID = Convert.ToInt32(dr["SUPERVISOR"]);
                employeeID = Convert.ToInt32(dr["EMPLOYEE_ID"]);
            }

            //Get supervisor Name
            database.open();
            SqlCommand supcmd = new SqlCommand("SELECT FIRST_NAME, LAST_NAME FROM EMPLOYEES WHERE EMPLOYEE_ID = @supervisorID", cnn);
            supcmd.Parameters.AddWithValue("@supervisorID", supervisorID);
            supcmd.ExecuteNonQuery();
            SqlDataAdapter supda = new SqlDataAdapter(supcmd);
            DataTable supdt = new DataTable();
            supda.Fill(supdt);
            database.close();
            foreach (DataRow dr in supdt.Rows)
            {
                supervisorName = dr["FIRST_NAME"].ToString().TrimEnd(' ') + " " + dr["LAST_NAME"].ToString().TrimEnd(' ');
            }

            //Get employee Name
            database.open();
            SqlCommand empcmd = new SqlCommand("SELECT FIRST_NAME, LAST_NAME FROM EMPLOYEES WHERE EMPLOYEE_ID = @employeeID", cnn);
            empcmd.Parameters.AddWithValue("@employeeID", employeeID);
            empcmd.ExecuteNonQuery();
            SqlDataAdapter empda = new SqlDataAdapter(empcmd);
            DataTable empdt = new DataTable();
            empda.Fill(empdt);
            database.close();
            foreach (DataRow dr in empdt.Rows)
            {
                employeeName = dr["FIRST_NAME"].ToString().TrimEnd(' ') + " " + dr["LAST_NAME"].ToString().TrimEnd(' ');
            }

            //Assign to labels
            requestSupLabel.Text = supervisorName;
            employeeLabel.Text = employeeName;

            //Get line items on request
            database.open();
            SqlCommand lineitemcmd = new SqlCommand("SELECT QUANTITY, ITEM_ID, UNIT_PRICE, LINE_TOTAL FROM LINE_ORDER WHERE REQUEST_ID = @requestID", cnn);
            lineitemcmd.Parameters.AddWithValue("@requestID", requestID);
            lineitemcmd.ExecuteNonQuery();
            SqlDataAdapter lineitemda = new SqlDataAdapter(lineitemcmd);
            DataTable lineitemdt = new DataTable();
            lineitemda.Fill(lineitemdt);
            database.close();
            foreach(DataRow dr in lineitemdt.Rows)
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
            for(int i = 0; i < request.Count; i++)
            {
                ListViewItem item = new ListViewItem(request[i].Quantity.ToString());
                item.SubItems.Add(descriptionList[i]);
                item.SubItems.Add(request[i].ItemPrice.ToString());
                item.SubItems.Add(request[i].LineTotal.ToString());

                requestListView.Items.Add(item);
            }
        }

        //Handler for cancel button
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Handler for accept button
        private void acceptButton_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand reqcmd = new SqlCommand("UPDATE REQUEST SET COUNTER = 3 WHERE REQUEST_ID = @requestID", cnn);
            reqcmd.Parameters.AddWithValue("@requestID", requestID);
            reqcmd.ExecuteNonQuery();

            this.Close();
        }

        //Handler for reject button
        private void rejectButton_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand reqcmd = new SqlCommand("UPDATE REQUEST SET COUNTER = 1 WHERE REQUEST_ID = @requestID", cnn);
            reqcmd.Parameters.AddWithValue("@requestID", requestID);
            reqcmd.ExecuteNonQuery();

            this.Close();
        }
    }
}
