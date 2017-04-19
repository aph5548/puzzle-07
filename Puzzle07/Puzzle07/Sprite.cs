using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


/*
 * Michael Capra (With help from Emily Turner)
 * Sprite Class
 * Sprite Class: Makes an animated sprite for an object using a sprite sheet.
 */

namespace Puzzle07
{
    class Sprite
    {
        //Attributes
        private Texture2D spriteSheet;
        private int numFrames; 
        private int timeSinceLastFrame;
        private int frameDelay; //Time between frames
        private Point currentFrame;
        private Vector2 position;
        private int width;
        private int height;
        private int frame; //Current frame you're on

        //Accessors
        public int FrameDelay
        {
            set { frameDelay = value; }
        }

        public int Xloc
        {
            get { return (int)position.X; }
            set { position.X = value; }
        }

        public int Yloc
        {
            get { return (int)position.Y; }
            set { position.Y = value; } 
        }

        public Texture2D Image
        {
            get { return spriteSheet; }
            set { spriteSheet = value; }
        }

        //Constructor
        public Sprite(int h, int w, int delay, int frames, Vector2 pos)
        {
            position = pos;
            height = h;
            width = w;
            frameDelay = delay;
            numFrames = frames;
            currentFrame.X = 0;
            currentFrame.Y = 0;
            frame = 0;
        }

        //update the current frame
        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if(timeSinceLastFrame >= frameDelay)
            {
                if(frame  == numFrames)
                {
                    frame = 0;
                }
                else
                {
                    currentFrame.X = (width * frame); 
                    frame++;
                    timeSinceLastFrame = 0;
                }
            }
        }

        //Draw le sprite
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, position, new Rectangle(currentFrame.X, currentFrame.Y, width, height), Color.White);
        }
    }
}
