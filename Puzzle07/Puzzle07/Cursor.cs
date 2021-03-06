﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

/*
 * Michael Capra
 * Cursor Class
 * IS a cursor for buttons, takes the mouses position as it's position (Is not accurately reflected by the mouse itself)
 */

namespace Puzzle07
{
    class Cursor:GameObject
    { 
        public Cursor(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        //Update method, takes a mousestate to update the position of the mouse.
        public void Update(MouseState mouse)
        {
            Position = new Rectangle(mouse.Position, new Point(Width, Height));
        }
    }
}
