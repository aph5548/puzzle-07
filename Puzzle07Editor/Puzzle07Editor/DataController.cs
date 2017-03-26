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
        private string[] rooms; //Tells us the rooms.
        private string fileName;
        private int[] waterInts;
        private int[] sequence;
        int stealth;
        int lever;
        int light;

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
            rooms = new string[4];
            waterInts = new int[3];
            sequence = new int[5];
            stealth = 0;
            lever = 0;
            light = 0;
        }

        public void populateRooms(string name)
        {
            rooms[roomID] = name;
            roomID++;
        }

        public void populateWaterInt(int a, int b, int c)
        {
            waterInts[0] = a;
            waterInts[1] = b;
            waterInts[2] = c;
        }

        public void populateSequence(int a, int b, int c, int d, int e)
        {
            sequence[0] = a;
            sequence[1] = b;
            sequence[2] = c;
            sequence[3] = d;
            sequence[4] = e;
        }

        public void populateStealth(int v)
        {
            stealth = v;
        }

        public void populateLight(int v)
        {
            light = v;
        }

        public void populateLever(int v)
        {
            lever = v;
        }

        public void formatTextDoc()
        {
            try
            {
                
                StreamWriter writer = new StreamWriter(fileName);

                writer.WriteLine(fileName);

                for(int i = 0; i < rooms.Length; i++)
                {
                    if(rooms[i] == "WaterRoom")
                    {
                        writer.WriteLine(rooms[i]);

                        for(int j = 0; j < waterInts.Length; j++)
                        {
                            writer.Write(waterInts[j]);
                        }

                        writer.WriteLine(" ");
                    }
                    else if(rooms[i] == "StealthRoom")
                    {
                        writer.WriteLine(rooms[i]);
                        writer.WriteLine(stealth);
                    }
                    else if(rooms[i] == "SequenceRoom")
                    {
                        writer.WriteLine(rooms[i]);
                        for(int j = 0; j < sequence.Length; j++)
                        {
                            writer.Write(sequence[j]);
                        }
                        writer.WriteLine(" ");
                    }
                    else if(rooms[i] == "LeverRoom")
                    {
                        writer.WriteLine(rooms[i]);
                        writer.WriteLine(lever);
                    }
                    else if(rooms[i] == "LightRoom")
                    {
                        writer.WriteLine(rooms[i]);
                        writer.WriteLine(light);
                    }
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
