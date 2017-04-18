using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Michael
 * FailTile: If the player steps on this tile, they "failed" the course, sends them back to start of the room.
 * 4/18/17
 */

namespace Puzzle07
{
    class FailTile : GameObject
    {
        //Attributes
        private int roomStartX;
        private int roomStartY;

        //Constructor
        public FailTile(int sX, int sY, int x, int y, int width, int height) : base(x, y, width, height)
        {
            roomStartX = sX;
            roomStartY = sY;
        }

        //Method to detect collision
        public bool Fail(Player player)
        {
            if(player.Position.Intersects(Position))
            {
                player.X = roomStartX;
                player.Y = roomStartY;
                //Will be added after when rooms are done, make sure to deduct a life from the room.
                return true;
            }

            return false;
        }
    }
}
