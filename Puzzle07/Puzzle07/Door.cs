using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Michael Capra
 * Door Class: Opens and Closes when a lever is pulled.
 * Milestone 3: 4/7/2017
 */
namespace Puzzle07
{
    class Door:GameObject
    {
        //fields
        private bool isOpen;

        public Door(int x, int y, int width, int height):base(x, y, width, height)
        {
            isOpen = false;
        }

        //accessor
        public bool IsOpen
        {
            get { return isOpen; }
        }

        public void OpenDoor(bool cmd)
        {
            if(cmd == true)
            {
                isOpen = true;
            }
            else
            {
                isOpen = false;
            }
        }


    }
}