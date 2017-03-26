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
        //attributes
        int num1;
        int num2;
        int num3;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            bT_Next.Enabled = false;
            num1 = 0;
            num2 = 0;
            num3 = 0;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //Don't do anything with this
        }

        private void bT_Next_Click(object sender, EventArgs e)
        {
            FormController.GetSingleton().changeRooms();
            this.Enabled = false;
            this.Visible = false;
        }

        private void bT_Validate_Click(object sender, EventArgs e)
        {
            //Checks for mp + nq = k, where n < m, m > k, n & m are reletively prime.
            bool parsed = int.TryParse(tB_Int1.Text, out num1);
            parsed = int.TryParse(tB_Int2.Text, out num2);
            parsed = int.TryParse(tB_Int3.Text, out num3);





            if((findGCD(num1, num2) > 1) || (num2 > num1 || num3 > num1))
            {
                lb_Error.Visible = true;
            }
            else if ((num1 > 10 || num1 < 0) || (num2 > 10 || num2 < 0) || (num3 > 10 || num3 < 0))
            {
                lb_Error.Visible = true;
            }
            else
            {
                DataController.GetSingleton().populateWaterInt(num1, num2, num3);
                bT_Next.Enabled = true;
            }

        }

        private int findGCD(int v1, int v2) //Finds GCD, if it's greater than 1, the two numbers aren't relatively prime.
        {
            while(v1 != 0 && v2 != 0)
            {
                if(v1 > v2)
                {
                    v1 %= v2;
                }
                else
                {
                    v2 %= v1;
                }
            }

            return Math.Max(v1, v2);
        }

        private void tB_Int3_TextChanged(object sender, EventArgs e)
        {
            lb_Error.Visible = false;
        }

        private void tB_Int2_TextChanged(object sender, EventArgs e)
        {
            lb_Error.Visible = false;
        }

        private void tB_Int1_TextChanged(object sender, EventArgs e)
        {
            lb_Error.Visible = false;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
