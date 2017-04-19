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
                    if (player.X > X - player.Width && (X - player.X) > 0 && player.Direction(3)) //From the right
                    {
                        player.X = X - player.Width;
                    }
                    else if (player.X - X < player.X - Width && player.Direction(1)) //From the left
                    {
                        player.X = X + Width;
                    }
                    else if (player.Y > Y - player.Height && (Y - player.Y) > 0 && player.Direction(2)) //From the top
                    {
                        player.Y = Y - player.Height;
                    }
                    else if (player.Y - Y < Y + Height && player.Direction(0)) //From the bottom
                    {
                        player.Y = Y + Height;
                    }
                
            }
        }
    }
}