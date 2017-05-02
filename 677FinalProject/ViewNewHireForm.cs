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
    public partial class ViewNewHireForm : Form
    {
        public ViewNewHireForm()
        {
            InitializeComponent();
        }

        //Accessors for labels
        public string EmployeeIDLabel
        {
            set
            {
                employeeIDLabel.Text = value;
            }
        }

        public string NameLabel
        {
            set
            {
                nameLabel.Text = value;
            }
        }

        public string DateOfBirthLabel
        {
            set
            {
                dateOfBirthLabel.Text = value;
            }
        }
        public string BackgroundStatusLabel
        {
            set
            {
                backgroundStatusLabel.Text = value;
            }
        }

        public string TitleLabel
        {
            set
            {
                titleLabel.Text = value;
            }
        }

        public string GenderLabel
        {
            set
            {
                genderLabel.Text = value;
            }
        }
    }
}
