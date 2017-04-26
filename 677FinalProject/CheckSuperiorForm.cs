using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _677FinalProject
{
    public partial class CheckSuperiorForm : Form
    {
        public CheckSuperiorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int getSupervisorID()
        {
            int id = Convert.ToInt32(idTextBox.Text);
            return id;
        }
    }
}
