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
    public partial class BuildTeamViewRequestForm : Form
    {
        public BuildTeamViewRequestForm()
        {
            InitializeComponent();
        }

        private void buildItemButton_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem i in itemsListView.SelectedItems)
            {
                i.SubItems[0].Text = "X";
            }
        }
    }
}
