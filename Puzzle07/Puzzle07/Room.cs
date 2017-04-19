using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

/*
 * Michael Capra
 * Room Class
 * Represents a generic room, will be inherited by other rooms
 */

namespace Puzzle07
{
    class Room
    {
        //attributes
        KeyboardState kbState;
        Player player;

        //Constructor
        public Room(KeyboardState kState, Player plyr)
        {
            kbState = kState;
            player = plyr;
        }

        //Update method: Handles any relevant updates:
        public void Update(GameTime gameTime)
        {
            player.Move(kbState);
        }

        //Generic draw method
        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
}
