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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            bT_Next.Enabled = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //Don't do anything with this
        }

        private void bT_Next_Click(object sender, EventArgs e)
        {
            FormController.GetSingleton().changeRooms();
        }
    }
}
