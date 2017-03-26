using System;
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
    public partial class Form4 : Form
    {
        //value for use later
        int value;
        public Form4()
        {
            InitializeComponent();
        }

        private void opt2_CheckedChanged(object sender, EventArgs e)
        {
            //do nothing
        }

        private void bT_Next_Click(object sender, EventArgs e)
        {
            if(opt1.Checked)
            {
                value = 1;
            }
            else if (opt2.Checked)
            {
                value = 2;
            }
            else if(opt3.Checked)
            {
                value = 3;
            }

            DataController.GetSingleton().populateLever(value);

            FormController.GetSingleton().changeRooms();
            this.Enabled = false;
            this.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            value = 0;
        }

        private void opt1_CheckedChanged(object sender, EventArgs e)
        {
            //do nothing
        }
    }
}
