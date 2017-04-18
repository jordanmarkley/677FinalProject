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
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handler for the click of the View Request Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewRequestButton_Click(object sender, EventArgs e)
        {
            //Create new Manager Request form and store the selected form's info
            ManagerViewRequestForm m = new ManagerViewRequestForm();
          //store info
            //m.SupervisorLabelText = INFO IN DATABASE
            //m.EmployeeLabelText = INFO IN DATABASE
            //m.ListViewQuantityText = INFO IN DB
            //m.ListViewDescriptionText = 
            //m.ListViewPriceText =
            //m.ListViewLineTotalText =

            //Display the form
            m.ShowDialog();
        }
    }
}
