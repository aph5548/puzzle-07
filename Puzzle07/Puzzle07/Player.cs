using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Austin Stone
 * Section 2
 * Player Class
 */
namespace Puzzle07
{
    class Player : GameObject
    {
        // variables for texture and position


        // variables for score might be used later, commented out for now
        // int levelScore;
        //int totalScore;

        private bool[] wasd = { false, false, false, false }; //Was going to use an enum, but this implemented better.

        public Player(int x, int y, int width, int height) : base(x, y, width, height)
        {
            //levelScore = 0;
            //totalScore = 0;
        }
        //Acccesor
        public bool Direction(int i)
        {
            return wasd[i];
        }

        // accessors for score
        /* public int LevelScore
        {
            get
            {
                return levelScore;
            }

            set
            {
                levelScore = value;
            }
        }

        public int TotalScore
        {
            get
            {
                return totalScore;
            }

            set
            {
                totalScore = value;
            }
        }*/

        public void Move(KeyboardState kbState)
        {
            if (kbState.IsKeyDown(Keys.W))
            {
                wasd[0] = true;
                Position = new Rectangle(X, Y - 5, Width, Height);
                
            }

            else
            {
                wasd[0] = false;
            }

            if (kbState.IsKeyDown(Keys.A))
            {
                wasd[1] = true;
                Position = new Rectangle(X - 5, Y, Width, Height);
                
            }

            else
            {
                wasd[1] = false;
            }

            if (kbState.IsKeyDown(Keys.S))
            {
                wasd[2] = true;
                Position = new Rectangle(X, Y + 5, Width, Height);
            }

            else
            {
                wasd[2] = false;
            }

            if (kbState.IsKeyDown(Keys.D))
            {
                wasd[3] = true;
                Position = new Rectangle(X + 5, Y, Width, Height);
            }

            else
            {
                wasd[3] = false;
            }
        }
    }
}
