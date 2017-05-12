using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

/*
 * Michael Capra
 * WAiterContainer Class
 * It's a container that holds a certain amount of water, measured it cups
 */

namespace Puzzle07
{
    class WaterContainer:Interactable
    {
        //Attributes
        private int MAX; //This is a constant but it has to be set by the constructor
        private int amount; //Amount currently in the container

        //Constructor
        public WaterContainer(int max, int amnt, int x, int y, int width, int height):base(x, y, width, height)
        {
            MAX = max;
            amount = amnt;
        }

        //Accessors and Properties
        public int Max
        {
            get { return MAX;  }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        //update method to see if the container is picked up
        public void Update(GameTime gameTime, Player player)
        {
            if(OnOff == true)
            {
                if(player.Direction(3)) //To the right
                {
                    //Position = new Rectangle(player.X + player.Width, player.Y, Width, Height);
                    X = player.X + player.Width;
                    Y = player.Y + ((player.Height - Height) / 2);
                }
                else if(player.Direction(1)) //To the left
                {
                    //Position = new Rectangle(player.X - player.Width, player.Y, Width, Height);
                    X = player.X - (Width);
                    Y = player.Y + ((player.Height - Height) / 2);
                }
                else if(player.Direction(0)) //Up
                {
                    //Position = new Rectangle(player.X, player.Y - player.Height, Width, Height);
                    Y = player.Y - Height;
                    X = player.X + ((player.Width - Width) / 2);
                }
                else if(player.Direction(2)) //Down
                {
                    //Position = new Rectangle(player.X, player.Y + player.Height, Width, Height);
                    Y = player.Y + player.Height;
                    X = player.X + ((player.Width - Width) / 2);
                }
            }
        }
    }
}
