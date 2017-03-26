using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Puzzle07Editor
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            bT_Finish.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataController.GetSingleton().formatTextDoc();
            Random rgen = new Random();
            while(pBar.Value < pBar.Maximum)
            {
                Thread.Sleep(250);
                pBar.Value += 5;
            }

            bT_Finish.Enabled = true;
            button1.Enabled = false;
        }

        private void bT_Finish_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
