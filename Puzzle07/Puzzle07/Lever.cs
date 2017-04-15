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
 * Lever Class: levers that control doors, can have 1 or 2 doors associated. 
 * Milestone 3, 4/7/2017
 */
namespace Puzzle07
{
    class Lever:Interactable
    {
        //Attributes
        Door door1;
        Door door2; //This may or may not be used. 

        public Lever(int x, int y, int width, int height): base(x, y, width, height)
        {
            this.Active = false; //Starts off not active
            //Default constructor
        }

        public Lever(Door d1, int x, int y, int width, int height) : base(x, y, width, height) //Constructor for a single door.
        {
            door1 = d1;
            this.Active = false;
        }

        public Lever(Door d1, Door d2, int x, int y, int width, int height) : base(x, y, width, height)
        {
            door1 = d1;
            door2 = d2;
            this.Active = false;
        }

        public void StateChanged()
        {

        }

    }
}
