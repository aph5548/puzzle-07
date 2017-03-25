using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle07Editor
{
    class FormController
    {
        //attributes
        private string[] rooms;
        private int roomID;
        
        private static FormController singleton;

        public static FormController GetSingleton()
        {
            if(singleton == null)
            {
                singleton = new FormController();
            }
            return singleton;
        }
        private FormController()
        {
            rooms = new string[4];
            roomID = 0;
            for(int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = DataController.GetSingleton().getRoom(i);
            }
        }

        public void changeRooms()
        {
            if (rooms[roomID] == "WaterRoom")
            {
                Form3 WaterRoom = new Puzzle07Editor.Form3();
                WaterRoom.Enabled = true;
                WaterRoom.Visible = true;
            }
            else if (rooms[roomID] == "LeverRoom")
            {
                Form4 LeverRoom = new Puzzle07Editor.Form4();
                LeverRoom.Enabled = true;
                LeverRoom.Visible = true;
            }
            else if (rooms[roomID] == "LightRoom")
            {
                Form5 LightRoom = new Form5();
                LightRoom.Enabled = true;
                LightRoom.Visible = true;
            }
            else if (rooms[roomID] == "SequenceRoom")
            {
                Form6 SequenceRoom = new Puzzle07Editor.Form6();
                SequenceRoom.Enabled = true;
                SequenceRoom.Visible = true;
            }
            else if (rooms[roomID] == "StealthRoom")
            {
                Form7 StealthRoom = new Puzzle07Editor.Form7();
                StealthRoom.Enabled = true;
                StealthRoom.Visible = true;
            }

            roomID++; 
        }
    }
}
