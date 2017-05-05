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
    public partial class MetricsForm : Form
    {
        public MetricsForm()
        {
            InitializeComponent();
        }

        public string OutstandingBuildsLabel
        {
            set
            {
                outstandingBuildsLabel.Text = value;
            }
        }

        public string AverageBuildTimeLabel
        {
            set
            {
                avgBuildTimeLabel.Text = value;
            }
        }
    }
}
