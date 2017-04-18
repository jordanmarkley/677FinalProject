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
    public partial class HRRepForm : Form
    {
        public HRRepForm()
        {
            InitializeComponent();
        }

        //open the selected request
        private void viewRequestButton_Click(object sender, EventArgs e)
        {
            HRViewRequestForm hrv = new HRViewRequestForm();
            hrv.ShowDialog();
        }
    }
}
