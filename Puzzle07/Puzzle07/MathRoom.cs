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
 * This is our code for the math sequence room
 */
namespace Puzzle07
{
    class MathRoom : Room
    {
        // ALLLL of our many levers for this room, 4 for each row of questions
        Lever lever1;
        Lever lever2;
        Lever lever3;
        Lever lever4;
        Lever lever5;
        Lever lever6;
        Lever lever7;
        Lever lever8;
        Lever lever9;
        Lever lever10;
        Lever lever11;
        Lever lever12;

        // HOLY ACCESSORS BATMAN!
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

        public Lever Lever7
        {
            get
            {
                return lever7;
            }
        }

        public Lever Lever8
        {
            get
            {
                return lever8;
            }
        }

        public Lever Lever9
        {
            get
            {
                return lever9;
            }
        }

        public Lever Lever10
        {
            get
            {
                return lever10;
            }
        }

        public Lever Lever11
        {
            get
            {
                return lever11;
            }
        }

        public Lever Lever12
        {
            get
            {
                return lever12;
            }
        }


        // constructor
        public MathRoom(KeyboardState kState, Player plyer) : base(kState, plyer)
        {
            // bottom row of levers, first you will see
            lever1 = new Lever(100, 900, 64, 64);
            lever2 = new Lever(300, 900, 64, 64);
            lever3 = new Lever(500, 900, 64, 64);
            lever4 = new Lever(700, 900, 64, 64);

            // middle row of levers
            lever5 = new Lever(100, 500, 64, 64);
            lever6 = new Lever(300, 500, 64, 64);
            lever7 = new Lever(500, 500, 64, 64);
            lever8 = new Lever(700, 500, 64, 64);

            // last row of levers
            lever9 = new Lever(100, 100, 64, 64);
            lever10 = new Lever(300, 100, 64, 64);
            lever11 = new Lever(500, 100, 64, 64);
            lever12 = new Lever(700, 100, 64, 64);

            lever1.OnOff = false;
            lever2.OnOff = false;
            lever3.OnOff = false;
            lever4.OnOff = false;
            lever5.OnOff = false;
            lever6.OnOff = false;
            lever7.OnOff = false;
            lever8.OnOff = false;
            lever9.OnOff = false;
            lever10.OnOff = false;
            lever11.OnOff = false;
            lever12.OnOff = false;
        }

    }
}
