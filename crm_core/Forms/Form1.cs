﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm_core
{
    public partial class Form1 : Form
    {
        private Users _user;
        private ListForm list_form;
        public Users User { set { _user = value; } }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var auth = new AuthForm();
            auth.ShowDialog(this);            
        }

        public void child_ready()
        {
            if(!list_form.Visible)
                list_form.ShowDialog();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            list_form = new ListForm(this);
            list_form.State = ListForm.CLIENTS;
        }
    }
}
