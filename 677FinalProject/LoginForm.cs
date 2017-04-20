/* Group 5 Final Project
 * 
 * Riley Flinn
 * Wyatt Gettler
 * Kurstin Guy
 * Michael Jackman
 * Jordan Markley-Kubias
 * 
 * Class: Login Form
 * 
 *      The login form handles all events that the user does to interact with the form.
 *      The form takes in a username and password from the user and a button that is to 
 *      log the employee into the system. Will handle events for successful or failed
 *      attempts by the user to log in.
 * 
 * */

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
using System.Threading;

namespace _677FinalProject
{
    public partial class LoginForm : Form
    {
        //Variables
        private string username;
        private string password;

        public LoginForm()
        {
            InitializeComponent();
        }

        //Handler for the click of the login button
        private void loginButton_Click(object sender, EventArgs e)
        {
            username = usernameTextbox.Text;
            password = passwordTextbox.Text;
            int attempts = 0;

            attempts++;

            //user has failed login 3 times then lock them out for 2 hours
            if (attempts >= 3)
            {
                MessageBox.Show("Failed 3 times, wait 2 hours and try again");
                usernameTextbox.Enabled = false;
                passwordTextbox.Enabled = false;
                Thread.Sleep(5000);
                attempts = 0;
                usernameTextbox.Enabled = true;
                passwordTextbox.Enabled = true;
            }
            else
            {
                try
                {
                    //Create new database connection and sql connection
                    SqlConnection cnn = new SqlConnection();
                    DBcnn database = new DBcnn(cnn);
                    database.connect(null);
                    username = usernameTextbox.Text;
                    password = passwordTextbox.Text;

                    database.open();
                    {
                        //Create new log in session and give access
                        Login session = new Login(username, password, cnn);
                        int result = session.access();
                        if (result > 0)
                        //Successful login so look up and open employee's title
                        {
                            session.findTitle();
                            this.Close();
                            database.close();
                        }
                        else
                            MessageBox.Show("Incorrect login");
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error:" + ex.Message);
                }
            }

            //this bit of the code will add the items in the json file retrieved from the AWS to our database

            //create the list that the newhires will be passed to
            List<Employee> newguys = new List<Employee>();

            //create a newhire to get the newhire information from then assigns the it to the newguys list of employees
            NewHire theHomies = new NewHire();
            newguys = theHomies.getJson();

            //ths establishes a connection to the database
            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);


            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestForm r = new RequestForm();
            r.ShowDialog();
        }
    }
}
