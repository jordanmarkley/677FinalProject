/* Group 5 Final Project
 * 
 * Riley Flinn
 * Wyatt Gettler
 * Kurstin Guy
 * Michael Jackman
 * Jordan Markley-Kubias
 * 
 * Class: Login
 * 
 *      Class to keep track of the employee's employee id and password that is used to log in.
 *      Will secure the connection to the sql database in order to check employee's login credentials
 *      and what their title is so that they are logged into the appropriate form.
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _677FinalProject
{
    class Login
    {
        //Variables
        private string _empid;
        private string _pword;
        private SqlConnection _connection;

        //Constructor
        public Login(string employeeID, string password, SqlConnection cnn)
        {
            _empid = employeeID;
            _pword = password;
            _connection = cnn;
        }

        //Method that validates login credentials
        public int access()
        {
            SqlCommand Logincmd = new SqlCommand(@"SELECT Count(*) FROM EMPLOYEES 
                                        WHERE EMPLOYEE_ID=@empid and 
                                        PASSWORD=@pass", _connection);
            Logincmd.Parameters.AddWithValue("@empid", _empid);
            Logincmd.Parameters.AddWithValue("@pass", _pword);
            int result = (int)Logincmd.ExecuteScalar();
            return result;
        }

        //Method to check the title of the employee logging in and open the appropriate form
        public void findTitle()
        {
            string title;
            SqlCommand titleCmd = new SqlCommand("SELECT Title FROM EMPLOYEES WHERE EMPLOYEE_ID=@empid", _connection);
            titleCmd.Parameters.AddWithValue("@empid", _empid);
            title = titleCmd.ExecuteScalar().ToString();
            title = title.TrimEnd(' ');
            if (title == "Manager")
            {
                ManagerForm m = new ManagerForm();
                m.ShowDialog();
            }
            else if(title == "Supervisor")
            {
                SupervisorForm s = new SupervisorForm();
                s.ShowDialog();
            }
            else if(title == "HR Rep")
            {
                HRRepForm h = new HRRepForm();
                h.ShowDialog();
            }
        }

        public void pushData()
        {

        }
    }
}
