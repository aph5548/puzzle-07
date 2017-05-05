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

        public LeverRoomAustin(KeyboardState kState, Player plyer, Rectangle leverPos1, Rectangle leverPos2): base(kState, plyer)
        {
            lever1 = new Lever(leverPos1.X, leverPos1.Y, leverPos1.Width, leverPos1.Height);
            lever2 = new Lever(leverPos2.X, leverPos2.Y, leverPos2.Width, leverPos2.Height);
            lever1.OnOff = false;
            lever2.OnOff = false;


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
