using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Michael Capra
 * Wall Class
 * Walls: Can't go through them
 */

namespace Puzzle07
{
    class Wall : GameObject
    {
        //Do this later, you gon be up tonight
        public Wall(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public void Update(Player player)
        {
            if (player.Position.Intersects(Position) == true)
            {
                if (player.X > X - player.Width && (X - player.X) > 0 && player.Direction(3)) //From the right
                {
                    player.X = X - player.Width;

                }
                else if (player.X - X < player.X - Width && player.Direction(1)) //From the left
                {
                    player.X = X + player.Width;

                }
                else if (player.Y >= Y - player.Height && player.Direction(0) && player.Direction(2)) //From the top
                {
                    player.Y = Y + player.Height;
                }
                else if (player.Y - Y <= Y + Height && player.Direction(2) && player.Direction(0)) //From the bottom
                {
                    player.Y = Y - player.Height;
                }

            }
        }
    }
}
