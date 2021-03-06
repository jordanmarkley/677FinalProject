﻿using System;
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
    public partial class SupervisorViewRequestForm : Form
    {
        public SupervisorViewRequestForm()
        {
            InitializeComponent();
        }

        //Accessor for the list view
        public ListView RequestListView
        {
            get
            {
                return requestListView;
            }
            set
            {
                requestListView = value;
            }
        }

        //Handler for exit button
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
