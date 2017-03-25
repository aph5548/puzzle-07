using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Puzzle07Editor
{
    class DataController
    {
        //Attributes
        private int roomID; //Helps us plan the room.
        private string[] rooms = new string[4]; //Tells us the rooms.
        private string fileName;

        //Property
        public int RoomID
        {
            get { return roomID; }
        }

        private static DataController singleton;

        public static DataController GetSingleton()
        {
            if(singleton == null)
            {
                singleton = new DataController();
            }
            return singleton;
        }

        private DataController()
        {
            roomID = 0;
        }

        public void populateRooms(string name)
        {
            rooms[roomID] = name;
            roomID++;
        }

        public void formatTextDoc()
        {
            try
            {
                
                StreamWriter writer = new StreamWriter(fileName);

                writer.WriteLine(fileName);

                for(int i = 0; i < rooms.Length; i++)
                {
                    writer.WriteLine("room" + i + ": " + rooms[0].ToString());
                }

                writer.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void nameFile(string name)
        {
            fileName = "pZ07_" + name + ".txt";
        }

        public string getRoom(int roomNum)
        {
            return rooms[roomNum];
        }
    }
}
