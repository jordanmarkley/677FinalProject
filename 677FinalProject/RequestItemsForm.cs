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
    public partial class RequestItemsForm : Form
    {
        public RequestItemsForm()
        {
            InitializeComponent();
        }

        public ListView RequestItemsListView
        {
            get
            {
                return requestItemsListView;
            }

            set
            {
                requestItemsListView = value;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            RequestForm r = new RequestForm();
            r.Show();
        }
    }
}
