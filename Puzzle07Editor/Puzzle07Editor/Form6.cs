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
    public partial class Form6 : Form
    {
        int[] nums;
        public Form6()
        {
            InitializeComponent();
        }

        private void bT_Next_Click(object sender, EventArgs e)
        {
            FormController.GetSingleton().changeRooms();
            this.Enabled = false;
            this.Visible = false;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            nums = new int[5];
            bT_Next.Enabled = false;
        }

        private bool AreEqual(int[] nums)
        {
            for(int s = 0; s < nums.Length; s++)
            {
                int currentNum = nums[s];
                for(int r = s + 1; r < nums.Length; r++)
                {
                    if (nums[s] == nums[r])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void bT_Validate_Click(object sender, EventArgs e)
        {
            bool parsed = int.TryParse(textBox3.Text, out nums[0]);
            parsed = int.TryParse(textBox2.Text, out nums[1]);
            parsed = int.TryParse(textBox1.Text, out nums[2]);
            parsed = int.TryParse(textBox5.Text, out nums[3]);
            parsed = int.TryParse(textBox4.Text, out nums[4]);

            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] < 0 || nums[i] > 5)
                {
                    label6.Visible = true;
                    return;
                }
            }

            if (AreEqual(nums) == true)
            {
                label6.Visible = true;
                return;
            }

            DataController.GetSingleton().populateSequence(nums[0], nums[1], nums[2], nums[3], nums[4]);
            bT_Next.Enabled = true;
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
        }
    }
}
