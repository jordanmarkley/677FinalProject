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
    public partial class RequestForm : Form
    {
        public RequestForm()
        {
            InitializeComponent();

            FillList();
        }

        private List<SoftwareHardware> itemList = new List<SoftwareHardware>();

        public void FillList()
        {
            SqlConnection conn = new SqlConnection("Data Source=10.135.85.168;Initial Catalog=Group5;User ID=Group5;Password=Grp52116%");
            SqlCommand cmd = new SqlCommand("SELECT * FROM SOFTWAREHARDWARE", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int id = (int)dr["ITEM_ID"];
                string descripotion = dr["DESCRIPTION"].ToString();
                double price = (double)dr["UNIT_PRICE"];

                SoftwareHardware item = new SoftwareHardware(id, descripotion, price);
                itemList.Add(item);
            }
        }
    }
}
