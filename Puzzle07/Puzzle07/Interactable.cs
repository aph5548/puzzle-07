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
        private bool active;
        private bool onOff; //If on, value is true, false if off
       
        //Accesor for onOff
        public bool OnOff
        {
            get { return onOff; }
            set { onOff = value; }
        }

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
            onOff = false;
        }

        // collistion check to see if player is within range of interactable
        public bool CheckCollision(GameObject game) //Michael: Making a change for this method to work probably. Currently it looks for active being true, which it shouldn't.
        {
            if (active == true) //Added new onOff bool, the collision will now set onOff instead of active, active meaning the object is interactable. - Michael
            {
                if (game.Position.Intersects(this.Position))
                {
                    return true;

                }
                else
                {
                    return false;
                }
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

