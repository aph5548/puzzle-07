﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle07Editor
{
    public partial class Form5 : Form
    {
        int value;
        public Form5()
        {
            InitializeComponent();
        }

        private void bT_Next_Click(object sender, EventArgs e)
        {
            if (opt1.Checked)
            {
                value = 1;
            }
            else if (opt2.Checked)
            {
                value = 2;
            }
            else if (opt3.Checked)
            {
                value = 3;
            }

            DataController.GetSingleton().populateLight(value);

            FormController.GetSingleton().changeRooms();
            this.Enabled = false;
            this.Visible = false;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            value = 0;
        }
    }
}
