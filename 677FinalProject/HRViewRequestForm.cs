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
    public partial class HRViewRequestForm : Form
    {
        public HRViewRequestForm()
        {
            InitializeComponent();
        }

        //Initializers for labels
        public string RequestIDLabel
        {
            set
            {
                requestIDLabel.Text = value;
            }
        }

        public string EmployeeLabel
        {
            set
            {
                employeeLabel.Text = value;
            }
        }

        public string SupervisorLabel
        {
            set
            {
                supervisorLabel.Text = value;
            }
        }

        public string RequestDateLabel
        {
            set
            {
                dateLabel.Text = value;
            }
        }

        public string StatusLabel
        {
            set
            {
                statusLabel.Text = value;
            }
        }
    }
}
