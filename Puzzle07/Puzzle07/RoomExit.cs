using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Michael Capra
 * RoomExit Class
 * If the player walks onto this and the room is complete, it changes the room
 */

namespace Puzzle07
{
    class RoomExit : GameObject
    {
        public RoomExit(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public bool ChangeRoom(Player player, bool complete)
        {
            if(Position.Intersects(player.Position) && complete == true)
            {
                return true;
            }

            return false;
        }
    }
}
