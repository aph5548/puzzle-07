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
 * 5/3/17
 * This is our code for the red light green light room
 */
namespace Puzzle07
{
    class RedLightRoom : Room
    {
        // lever objects to pull in the room
        Lever lever1;
        Lever lever2;
        Lever lever3;

        // accessors
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
        // rectangle that moves around and acts as detection radius
        GameObject detection;

        public GameObject Detection
        {
            get
            {
                return detection;
            }
            set
            {
                detection = value;
            }
        }

        // constructor
        public RedLightRoom(KeyboardState kState, Player plyer, Rectangle leverPos1, Rectangle leverPos2, Rectangle leverPos3) : base(kState, plyer)
        {
            lever1 = new Lever(leverPos1.X, leverPos1.Y, leverPos1.Width, leverPos1.Height);
            lever2 = new Lever(leverPos2.X, leverPos2.Y, leverPos2.Width, leverPos2.Height);
            lever3 = new Lever(leverPos3.X, leverPos3.Y, leverPos3.Width, leverPos3.Height);
            detection = new GameObject(300, 300, 300, 300);
            lever1.OnOff = false;
            lever2.OnOff = false;
            lever3.OnOff = false;
        }

        // method to return true if the player is within the detection rectangle and moving at the time
        public bool IsDetected(KeyboardState kState, Player plyer, Rectangle detect)
        {
            if(detection.Position.Contains(plyer.Position) && (kState.IsKeyDown(Keys.W) || kState.IsKeyDown(Keys.A) || kState.IsKeyDown(Keys.D) || kState.IsKeyDown(Keys.S)))
            {
                return true;
            }

            return false;
        }
    }
}
