using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _677FinalProject
{
    class Request
    {
        private int reqID;
        private int supID;
        private int empID;
        private int status;
        private decimal subtotal;
        private decimal salesTax;
        private decimal totalPrice;
        private string date;

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
    }
}
