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
        Wall wall1; // left wall
        Wall wall2; // right wall
        Wall wall3; // bottom wall
        Wall wall4; // wall left of door
        Wall wall5; // wall right of door
        Door testDoor;
        RoomExit exit;

        public LeverRoomAustin(KeyboardState kState, Player plyer, Rectangle leverPos1, Rectangle leverPos2): base(kState, plyer)
        {
            lever1 = new Lever(leverPos1.X, leverPos1.Y, leverPos1.Width, leverPos1.Height);
            lever2 = new Lever(leverPos2.X, leverPos2.Y, leverPos2.Width, leverPos2.Height);
            lever1.OnOff = false;
            lever2.OnOff = false;

            // setting room defaults
            wall1 = new Wall(-10, 0, 20, 1024);
            wall2 = new Wall(1270, 0, 20, 1024);
            wall3 = new Wall(0, 1014, 1280, 20);
            wall4 = new Wall(0, 0, 448, 20);
            wall5 = new Wall(576, 0, 700, 20);
            exit = new RoomExit(448, -50, 128, 128);
            testDoor = new Door(448, -50, 128, 128);


        }

        public void Update(bool keyPressedE, GameTime gameTime)
        {
            bool isColliding1 = Lever1.CheckCollision(Player1);
            if (isColliding1 && keyPressedE && Lever1.OnOff == false)
            {
                Lever1.OnOff = true;
            }


            else if (isColliding1 && keyPressedE && Lever1.OnOff == true)
            {
                Lever1.OnOff = false;
            }

            bool isColliding2 = Lever2.CheckCollision(Player1);
            if (isColliding2 && keyPressedE && Lever2.OnOff == false)
            {
                Lever2.OnOff = true;
            }

            else if (isColliding2 && keyPressedE && Lever2.OnOff == true)
            {
                Lever2.OnOff = false;
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



    }
}
