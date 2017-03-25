using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
/*
 * Austin Stone
 * Section 2
 * This is our class for interactable objects in the world
 */
namespace Puzzle07
{
    class Interactable : GameObject
    {

        // variable for interactable item state
        bool active;

       

        // accessor for active
        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        // constructor
        public Interactable(int x, int y, int width, int height) : base(x, y, width, height)
        {
            active = true;
        }

        // collistion check to see if player is within range of interactable
        public bool CheckCollision(GameObject game)
        {
            if (Active)
            {
                return game.Position.Intersects(this.Position);
            }
            else
            {
                return false;
            }
        }

        // override for the GameObject Draw method
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            base.Draw(spriteBatch);
            
        }
    }
}
