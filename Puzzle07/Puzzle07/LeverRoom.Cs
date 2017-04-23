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
 * Lever Room Class
 * Is the class that deals with our lever room, currently just a proof of concept.
 */

namespace Puzzle07
{
    class LeverRoom:Room
    {
        //Attributes
        Lever lever1, lever2, lever3;
        Door door1, door2, door3;
        Wall wall1, wall2, wall3, wall4, wall5, wall6;
        RoomExit exit;

        public LeverRoom(Texture2D leverImage, Texture2D doorImage, Texture2D exitImage, Texture2D wallImage, KeyboardState kState, Player plyr) : base(kState, plyr)
        {
            exit = new RoomExit(1120, 512, 128, 128);

            wall1 = new Puzzle07.Wall(320, 0, 64, 384);
            wall2 = new Puzzle07.Wall(640, 0, 64, 384);
            wall3 = new Puzzle07.Wall(960, 0, 64, 384);
            wall4 = new Puzzle07.Wall(320, 640, 64, 384);
            wall5 = new Puzzle07.Wall(640, 640, 64, 384);
            wall6 = new Puzzle07.Wall(960, 640, 64, 384);

            door1 = new Door(320, 384, 16, 256);
            door2 = new Door(640, 384, 16, 256);
            door3 = new Door(960, 384, 16, 256);

            lever1 = new Lever(door1, 128, 128, 32, 32);
            lever2 = new Lever(door2, 448, 128, 32, 32);
            lever3 = new Lever(door3, 768, 128, 32, 32);

            wall1.Texture = wallImage;
            wall2.Texture = wallImage;
            wall3.Texture = wallImage;
            wall4.Texture = wallImage;
            wall5.Texture = wallImage;
            wall6.Texture = wallImage;

            lever1.Texture = leverImage;
            lever2.Texture = leverImage;
            lever3.Texture = leverImage;

            exit.Texture = exitImage;

        }

        //Updates everything in the lever room.
        public void Update(GameTime gameTime, bool ePressed)
        {
            base.Update(gameTime);

            if(lever1.CheckCollision(this.Player1) && ePressed)
            {
                lever1.OnOff = !lever1.OnOff;
                lever1.StateChanged();
            }

            if (lever2.CheckCollision(this.Player1) && ePressed)
            {
                lever2.OnOff = !lever1.OnOff;
                lever2.StateChanged();
            }

            if (lever3.CheckCollision(this.Player1) && ePressed)
            {
                lever3.OnOff = !lever1.OnOff;
                lever3.StateChanged();
            }

            wall1.Update(this.Player1);
            wall2.Update(this.Player1);
            wall3.Update(this.Player1);
            wall4.Update(this.Player1);
            wall5.Update(this.Player1);
            wall6.Update(this.Player1);

            door1.Collision(this.Player1);
            door2.Collision(this.Player1);
            door3.Collision(this.Player1);

            if(door3.IsOpen)
            {
                this.Complete = true;
            }

            exit.ChangeRoom(this.Player1, this.Complete);
        }

        //Draw method for everything
        public void Draw(SpriteBatch spriteBatch, bool comp)
        {
            wall1.Draw(spriteBatch);
            wall2.Draw(spriteBatch);
            wall3.Draw(spriteBatch);
            wall4.Draw(spriteBatch);
            wall5.Draw(spriteBatch);
            wall6.Draw(spriteBatch);

            door1.Draw(spriteBatch);
            door2.Draw(spriteBatch);
            door3.Draw(spriteBatch);

            lever1.Draw(spriteBatch);
            lever2.Draw(spriteBatch);
            lever3.Draw(spriteBatch);

            if(this.Complete)
            {
                exit.Draw(spriteBatch);
            }


            base.Draw(spriteBatch);
        }
    }
}
