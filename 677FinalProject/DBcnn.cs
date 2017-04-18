/* Group 5 Final Project
 * 
 * Riley Flinn
 * Wyatt Gettler
 * Kurstin Guy
 * Michael Jackman
 * Jordan Markley-Kubias
 * 
 * Class: DBcnn
 * 
 *      Class to establish our database connection as well as open and close the connection.
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
    class DBcnn
    {
        //Variables
        private SqlConnection _connection;

        //Constructor
        public DBcnn(SqlConnection cnn)
        {
            _connection = cnn;
        }

        //Method to make database connection
        public void connect(string connectionString)
        {
            connectionString = "Data Source=10.135.85.168;Initial Catalog=Group5;User ID=Group5;Password=Grp52116%";
            _connection.ConnectionString = connectionString;
        }

        //method to open the connection
        public void open()
        {
            _connection.Open();
        }

        //method to close the connection
        public void close()
        {
            _connection.Close();
        }
    }
}
