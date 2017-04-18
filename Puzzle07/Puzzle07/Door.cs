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

        public void Collision(Player player)
        {
            if(player.Position.Intersects(Position) == true && isOpen == false)
            {
                if(X - player.X > Width - player.Width)
                {
                    player.X = Width - player.Width;
                }
                else if(player.X + X < Width)
                {
                    player.X = Width;
                }

                if (Y - player.Y > Height - player.Height)
                {
                    player.Y = player.Height - Height;
                }
                else if(player.Y + Y < Height)
                {
                    player.Y = Height;
                }
            }
        }
    }
}