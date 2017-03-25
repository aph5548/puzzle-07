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
    public partial class Pz_Main : Form
    {
        //attributes
        Form2 settings = new Form2();
        
        public Pz_Main()
        {
            settings.Enabled = false;
            InitializeComponent();
        }

        private void Pz_Main_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            settings.Visible = true;
            settings.Enabled = true;
            this.Enabled = false;
            this.Visible = false;
        }
    }
}
