using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Puzzle07
{
    class Button
    {
        Texture2D texture;
        Rectangle location;

        public Button()
        {
            texture = null;
            location = new Rectangle(0, 0, 10, 10);
        }

        public Button(Texture2D t, Rectangle r)
        {
            texture = t;
            location = r;
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public Rectangle Location
        {
            get { return location; }
            set { location = value; }
        }

        public bool Collides(Rectangle obj)
        {
            if (obj.Intersects(location))
                return true;
            else
                return false;
        }
    }
}
