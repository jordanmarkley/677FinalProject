using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _677FinalProject
{
    class Request
    {
        //Variables
        private int reqID;
        private int supID;
        private int empID;
        private int status;
        private decimal subtotal;
        private decimal salesTax;
        private decimal totalPrice;
        private string date;

        //Constructor
        public Request(int sID, int eID, decimal sub, decimal tax, decimal price, string d)
        {
            SqlConnection cnn = new SqlConnection();
            DBcnn db = new DBcnn(cnn);
            db.connect(null);
            db.open();

            SqlCommand getID = new SqlCommand(@"SELECT MAX(REQUEST) FROM REQUEST", cnn);
            reqID = Convert.ToInt32(getID.ToString()) + 1;
            db.close();
            supID = sID;
            empID = eID;
            status = 1;
            subtotal = sub;
            salesTax = tax;
            totalPrice = price;
            date = d;
        }

        //Constructor - 2 parameters
        public Request(int eID, int sID)
        {
            SqlConnection cnn = new SqlConnection();
            DBcnn db = new DBcnn(cnn);
            db.connect(null);
            db.open();
            
            SqlCommand getID = new SqlCommand(@"SELECT MAX(REQUEST_ID) FROM REQUEST", cnn);
            using (SqlDataReader reader = getID.ExecuteReader())
            {
                while (reader.Read())
                {
                    reqID = Convert.ToInt32(reader[0].ToString());
                }
            }
            db.close();
            reqID++;

            empID = eID;
            supID = sID;
            status = 1;
            date = DateTime.Now.ToString("dd.MM.yyy");
        }

        //Constructor - 3 parameters
        public Request(int rID, int sID, int s)
        {
            reqID = rID;
            supID = sID;
            status = s;
        }

        //Constructor - 7 parameters
        public Request(int rID, int sID, int eID, decimal sub, decimal tax, decimal price, string d)
        {
            reqID = rID;
            supID = sID;
            empID = eID;
            status = 1;
            subtotal = sub;
            salesTax = tax;
            totalPrice = price;
            date = d;
        }

        //Getters and setters for variables
        public int RequestID
        {
            get
            {
                return reqID;
            }

            set
            {
                reqID = value;
            }
        }

        public int SupervisorID
        {
            get
            {
                return supID;
            }

            set
            {
                supID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return empID;
            }

            set
            {
                empID = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return subtotal;
            }

            set
            {
                subtotal = value;
            }
        }

        public decimal SalesTax
        {
            get
            {
                return salesTax;
            }

            set
            {
                salesTax = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }

            set
            {
                totalPrice = value;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }
    }
}
