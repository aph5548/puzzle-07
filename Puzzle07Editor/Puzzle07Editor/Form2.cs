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
    
    public partial class Form2 : Form
    {

        public Form2()
        {
            
            InitializeComponent();
            
        }

        private void Pz_Settings_Load(object sender, EventArgs e)
        {
            bT_Next.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Don't do anything with this
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bT_Next.Enabled = true;
        }

        private void bT_Water_Click(object sender, EventArgs e)
        {
            DataController.GetSingleton().populateRooms("WaterRoom");
            

            if(DataController.GetSingleton().RoomID == 4)
            {
                bT_Light.Enabled = false;
                bT_Sequence.Enabled = false;
                bT_Stealth.Enabled = false;
                bT_Lever.Enabled = false;
                lb_Room.Text = "Done";
            }
            else
            {
                int roomNumber = DataController.GetSingleton().RoomID + 1;
                lb_Room.Text = "Choose Room " + roomNumber;
            }

            bT_Water.Enabled = false;
        }

        private void bT_Stealth_Click(object sender, EventArgs e)
        {
            DataController.GetSingleton().populateRooms("StealthRoom");


            if (DataController.GetSingleton().RoomID == 4)
            {
                bT_Light.Enabled = false;
                bT_Sequence.Enabled = false;
                bT_Water.Enabled = false;
                bT_Lever.Enabled = false;
                lb_Room.Text = "Done";
            }
            else
            {
                lb_Room.Text = "Choose Room " + DataController.GetSingleton().RoomID;
            }

            bT_Stealth.Enabled = false;
        }

        private void bT_Lever_Click(object sender, EventArgs e)
        {
            DataController.GetSingleton().populateRooms("LeverRoom");


            if (DataController.GetSingleton().RoomID == 4)
            {
                bT_Light.Enabled = false;
                bT_Sequence.Enabled = false;
                bT_Stealth.Enabled = false;
                bT_Water.Enabled = false;
                lb_Room.Text = "Done";
            }
            else
            {
                lb_Room.Text = "Choose Room " + DataController.GetSingleton().RoomID;
            }

            bT_Lever.Enabled = false;
        }

        private void bT_Sequence_Click(object sender, EventArgs e)
        {
            DataController.GetSingleton().populateRooms("SequenceRoom");


            if (DataController.GetSingleton().RoomID == 4)
            {
                bT_Light.Enabled = false;
                bT_Water.Enabled = false;
                bT_Stealth.Enabled = false;
                bT_Lever.Enabled = false;
                lb_Room.Text = "Done";
            }
            else
            {
                lb_Room.Text = "Choose Room " + DataController.GetSingleton().RoomID;
            }

            bT_Sequence.Enabled = false;
        }

        private void bT_Light_Click(object sender, EventArgs e)
        {
            DataController.GetSingleton().populateRooms("LightRoom");


            if (DataController.GetSingleton().RoomID == 4)
            {
                bT_Water.Enabled = false;
                bT_Sequence.Enabled = false;
                bT_Stealth.Enabled = false;
                bT_Lever.Enabled = false;
                lb_Room.Text = "Done";
            }
            else
            {
                lb_Room.Text = "Choose Room " + DataController.GetSingleton().RoomID;
            }

            bT_Light.Enabled = false;
        }

        private void bT_Next_Click(object sender, EventArgs e)
        {
            DataController.GetSingleton().nameFile(textBox1.Text);
            FormController.GetSingleton().changeRooms();
            this.Enabled = false;
            this.Visible = false;
        }
    }
}
