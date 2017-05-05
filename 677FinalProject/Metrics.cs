using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace _677FinalProject
{
    class Metrics
    {
        //Variables
        private decimal averageBuildTime;
        private int numberOutstandingBuilds;

        public int OustandingBuilds
        {
            get
            {
                return numberOutstandingBuilds;
            }
        }

        public int GetOutstandingBuilds()
        {
            int requestID = 0;
            string startDate = null;
            DateTime endDate = DateTime.Now;
            List<int> outstandingList = new List<int>();

            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand cmd = new SqlCommand("SELECT REQUEST_ID, DATE FROM REQUEST WHERE COUNTER < 4", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            database.close();

            foreach (DataRow dr in dt.Rows)
            {
                int days = 0;
                DateTime convertedStartDate = new DateTime();
                var culture = new CultureInfo("en-US");

                requestID = Convert.ToInt32(dr["REQUEST_ID"]);
                startDate = dr["DATE"].ToString().TrimEnd(' ');
                startDate = startDate.Replace('.', '/');
                string month = startDate[3].ToString() + startDate[4].ToString();
                string day = startDate[0].ToString() + startDate[1].ToString();
                StringBuilder sb = new StringBuilder(startDate);
                sb.Remove(0, 2);
                sb.Insert(0, month);
                sb.Remove(3, 2);
                sb.Insert(3, day);
                startDate = sb.ToString();

                convertedStartDate = Convert.ToDateTime(startDate);

                days = Convert.ToInt32((endDate - convertedStartDate).TotalDays);
                
                if(days > 7)
                {
                    outstandingList.Add(requestID);
                }
            }

            numberOutstandingBuilds = outstandingList.Count;

            return numberOutstandingBuilds;
        }

        public decimal AverageBuildTime()
        {
            int requestID = 0;
            string startDate = null;
            string endDate = null;
            DateTime convertedStartDate = new DateTime();
            DateTime convertedEndDate = new DateTime();
            decimal counter = 0;
            decimal totalDays = 0;

            SqlConnection cnn = new SqlConnection();
            DBcnn database = new DBcnn(cnn);
            database.connect(null);
            database.open();
            SqlCommand cmd = new SqlCommand("SELECT REQUEST_ID, DATE, END_DATE FROM REQUEST WHERE COUNTER = 4", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            database.close();

            foreach(DataRow dr in dt.Rows)
            {
                requestID = Convert.ToInt32(dr["REQUEST_ID"]);
                startDate = dr["DATE"].ToString().TrimEnd(' ');
                startDate = startDate.Replace('.', '/');
                string month = startDate[3].ToString() + startDate[4].ToString();
                string day = startDate[0].ToString() + startDate[1].ToString();
                StringBuilder sb = new StringBuilder(startDate);
                sb.Remove(0, 2);
                sb.Insert(0, month);
                sb.Remove(3, 2);
                sb.Insert(3, day);
                startDate = sb.ToString();

                convertedStartDate = Convert.ToDateTime(startDate);

                endDate = dr["END_DATE"].ToString().TrimEnd(' ');
                endDate = endDate.Replace('.', '/');
                string emonth = endDate[3].ToString() + endDate[4].ToString();
                string eday = endDate[0].ToString() + endDate[1].ToString();
                StringBuilder esb = new StringBuilder(endDate);
                esb.Remove(0, 2);
                esb.Insert(0, emonth);
                esb.Remove(3, 2);
                esb.Insert(3, eday);
                endDate = esb.ToString();

                convertedEndDate = Convert.ToDateTime(endDate);

                decimal days = Convert.ToDecimal((convertedStartDate - convertedEndDate).TotalDays);

                totalDays += days;

                counter++;
            }

            averageBuildTime = (totalDays) / counter;

            return averageBuildTime;
        }
    }
}
