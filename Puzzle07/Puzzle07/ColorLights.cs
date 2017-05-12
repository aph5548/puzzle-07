using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Puzzle07
{
    class ColorLights : GameObject
    {
        bool state;
        Texture2D greenLight;
        Texture2D redlight;
        
        public ColorLights(int x, int y, int width, int height, Texture2D tex1, Texture2D tex2) : base(x, y, width, height)//constructor for colored lights
        {
            state = false;
            greenLight = tex1;
            redlight = tex2;
        }

        

        public void Changer(bool change)
        {
            if(change == true)
            {
                state = true;
            }

            if(change == false)
            {
                state = false;
            }
        }

        public bool State
        {
            get { return state; }
            set { state = value; }
        }

    }
}
