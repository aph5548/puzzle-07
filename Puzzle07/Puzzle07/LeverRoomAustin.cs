using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
/*
 * Austin Stone
 * New lever room code
 * lever room code for a WORKING lever room
 */
namespace Puzzle07
{
    class LeverRoomAustin:Room
    {
        Lever lever1;
        Lever lever2;
        Lever lever3;
        Lever lever4;
        Lever lever5;
        Lever lever6;
        Wall wall1; // left wall
        Wall wall2; // right wall
        Wall wall3; // bottom wall
        Wall wall4; // wall left of door
        Wall wall5; // wall right of door
        ColorLights light1;
        ColorLights light2;
        ColorLights light3;
        Door testDoor;
        RoomExit exit;

        public LeverRoomAustin(KeyboardState kState, Player plyer, Rectangle leverPos1, Rectangle leverPos2, Texture2D tex1, Texture2D tex2): base(kState, plyer)
        {
            lever1 = new Lever(leverPos1.X, leverPos1.Y, leverPos1.Width, leverPos1.Height);
            lever2 = new Lever(leverPos2.X, leverPos2.Y, leverPos2.Width, leverPos2.Height);
            lever3 = new Lever(600, 100, 64, 64);
            lever4 = new Lever(600, 200, 64, 64);
            lever5 = new Lever(600, 300, 64, 64);
            lever6 = new Lever(600, 400, 64, 64);
            lever1.OnOff = false;
            lever2.OnOff = false;
            lever3.OnOff = false;
            lever4.OnOff = false;
            lever5.OnOff = false;
            lever6.OnOff = false;

            // setting room defaults
            wall1 = new Wall(-10, 0, 20, 1024);
            wall2 = new Wall(1270, 0, 20, 1024);
            wall3 = new Wall(0, 1014, 1280, 20);
            wall4 = new Wall(0, 0, 448, 20);
            wall5 = new Wall(576, 0, 700, 20);
            exit = new RoomExit(448, -50, 128, 128);
            testDoor = new Door(448, -50, 128, 128);
            light1 = new ColorLights(400, 400, 32, 32, tex1, tex2);
            light2 = new ColorLights(400, 450, 32, 32, tex1, tex2);
            light3 = new ColorLights(400, 500, 32, 32, tex1, tex2);



        }

        public void Update(bool keyPressedE, GameTime gameTime)
        {
            bool isColliding1 = Lever1.CheckCollision(Player1);
            bool isColliding2 = Lever2.CheckCollision(Player1);
            bool col3 = lever3.CheckCollision(Player1);
            bool col4 = lever4.CheckCollision(Player1);
            bool col5 = lever5.CheckCollision(Player1);
            bool col6 = lever6.CheckCollision(Player1);
            //lvr1
            if (isColliding1 && keyPressedE && Lever1.OnOff == false)
            {
                Lever1.OnOff = true;
            }


            else if (isColliding1 && keyPressedE && Lever1.OnOff == true)
            {
                Lever1.OnOff = false;
            }

           //lvr 2
            if (isColliding2 && keyPressedE && Lever2.OnOff == false)
            {
                Lever2.OnOff = true;
                light1.Changer(true);
            }

            else if (isColliding2 && keyPressedE && Lever2.OnOff == true)
            {
                Lever2.OnOff = false;
                light1.Changer(false);
            }
            //lvr3
            if (col3 && keyPressedE && lever3.OnOff == false)
            {
                lever3.OnOff = true;
            }


            else if (col3 && keyPressedE && lever3.OnOff == true)
            {
                lever3.OnOff = false;
            }
            //lvr4
            if (col4 && keyPressedE && lever4.OnOff == false)
            {
                lever4.OnOff = true;
            }


            else if (col4 && keyPressedE && lever4.OnOff == true)
            {
                lever4.OnOff = false;
            }
            //lvr5
            if (col5 && keyPressedE && lever5.OnOff == false)
            {
                lever5.OnOff = true;
            }


            else if (col5 && keyPressedE && lever5.OnOff == true)
            {
                lever5.OnOff = false;
            }
            //lvr6
            if (col6 && keyPressedE && lever6.OnOff == false)
            {
                lever6.OnOff = true;
            }


            else if (col6 && keyPressedE && lever6.OnOff == true)
            {
                lever6.OnOff = false;
            }
        }
        public Lever Lever1
        {
            get
            {
                return lever1;
            }
        }

        public Lever Lever2
        {
            get
            {
                return lever2;
            }
        }

        public Lever Lever3
        {
            get
            {
                return lever3;
            }
        }

        public Lever Lever4
        {
            get
            {
                return lever4;
            }
        }
        public Lever Lever5
        {
            get
            {
                return lever5;
            }
        }
        public Lever Lever6
        {
            get
            {
                return lever6;
            }
        }



    }
}
