using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
/*
 * Austin Stone
 * Water Room Class
 * This class will be where we generate the water room
 */
namespace Puzzle07
{
    class WaterRoom : Room
    {
        Wall wall1; // left wall
        Wall wall2; // right wall
        Wall wall3; // bottom wall
        Wall wall4; // wall left of door
        Wall wall5; // wall right of door
        Door testDoor;
        RoomExit exit;
        Interactable sink;
        WaterContainer finalContainer;
        WaterContainer waterContainer1;
        WaterContainer waterContainer2;
        Interactable drain;
        int goalAmount;

        // constructor
        public WaterRoom(KeyboardState kState, Player plyer, Rectangle sinkPos, Rectangle finalContPos, Rectangle waterContPos1, Rectangle waterContPos2, int contMax1, int contMax2, Rectangle drainPos, int goal): base(kState, plyer)
        {
            sink = new Interactable(sinkPos.X, sinkPos.Y, sinkPos.Width, sinkPos.Height);
            drain = new Interactable(drainPos.X, drainPos.Y, drainPos.Width, drainPos.Height);
            finalContainer = new WaterContainer(goalAmount, 0, finalContPos.X, finalContPos.Y, finalContPos.Width, finalContPos.Height);
            waterContainer1 = new WaterContainer(contMax1, 0, waterContPos1.X, waterContPos1.Y, waterContPos1.Width, waterContPos1.Height);
            waterContainer2 = new WaterContainer(contMax2, 0, waterContPos2.X, waterContPos2.Y, waterContPos2.Width, waterContPos2.Height);
            goalAmount = goal;

            // setting room defaults
            wall1 = new Wall(-10, 0, 20, 1024);
            wall2 = new Wall(1270, 0, 20, 1024);
            wall3 = new Wall(0, 1014, 1280, 20);
            wall4 = new Wall(0, 0, 448, 20);
            wall5 = new Wall(576, 0, 700, 20);
            exit = new RoomExit(448, -50, 128, 128);
            testDoor = new Door(448, -50, 128, 128);



            
            
        }

        public void Update(bool keyPressedE, bool keyPressedQ, GameTime gameTime)
        {
            
            bool isColliding1 = WaterContainer1.CheckCollision(Player1);        //Checks for water containers colliding with the player
            bool isColliding2 = WaterContainer2.CheckCollision(Player1);

            if (isColliding1 && keyPressedE && WaterContainer2.OnOff == false)  //Pick up container 1 if container 2 isn't held
            {
                WaterContainer1.OnOff = true;
            }

            if (isColliding2 && keyPressedE && WaterContainer1.OnOff == false)  //Pick up container 2
            {
                WaterContainer2.OnOff = true;
            }

            if (WaterContainer1.CheckCollision(Sink) && keyPressedE && WaterContainer1.OnOff == true)    //Fill container 1
            {
                Fill();
            }

            if (WaterContainer2.CheckCollision(Sink) && keyPressedE && WaterContainer2.OnOff == true)    //Fill container 2
            {
                Fill();
            }

            else if (WaterContainer1.CheckCollision(FinalContainer) && keyPressedE && WaterContainer1.OnOff == true) //Empty Container 1 into Final container
            {
                FinalContainerCondition(WaterContainer1);
            }

            else if (WaterContainer2.CheckCollision(FinalContainer) && keyPressedE && WaterContainer2.OnOff == true) //Pour container 2 into final container
            {
                FinalContainerCondition(WaterContainer2);
            }

            else if (WaterContainer1.CheckCollision(Drain) && keyPressedE && WaterContainer1.OnOff == true)  //Drain container 1
            {
                DrainCup();
            }

            else if (WaterContainer2.CheckCollision(Drain) && keyPressedE && WaterContainer2.OnOff == true)  //Drain container 2
            {
                DrainCup();
            }

            if (WaterContainer1.OnOff == true && keyPressedQ && WaterContainer1.CheckCollision(WaterContainer2) == false && WaterContainer1.CheckCollision(FinalContainer) == false &&
                WaterContainer1.CheckCollision(Sink) == false && WaterContainer1.CheckCollision(Drain) == false)   //Drop container 1
            {
                WaterContainer1.OnOff = false;
            }

            if (WaterContainer2.OnOff == true && keyPressedQ && WaterContainer2.CheckCollision(WaterContainer1) == false && WaterContainer2.CheckCollision(FinalContainer) == false &&
                WaterContainer2.CheckCollision(Sink) == false && WaterContainer2.CheckCollision(Drain) == false)   //Drop container 2
            {
                WaterContainer2.OnOff = false;
            }

            if(WaterContainer1.OnOff && WaterContainer1.CheckCollision(WaterContainer2) && keyPressedE)        //Pour from 1 to 2
            {
                if(WaterContainer2.Amount + WaterContainer1.Amount <= WaterContainer2.Max)
                {
                    WaterContainer2.Amount += WaterContainer1.Amount;
                    WaterContainer1.Amount = 0;
                }
                else if(WaterContainer2.Amount + WaterContainer1.Amount > WaterContainer2.Max)
                {
                    WaterContainer1.Amount -= (WaterContainer2.Max - WaterContainer2.Amount);
                    WaterContainer2.Amount = WaterContainer2.Max;
                }
            }

            if (WaterContainer2.OnOff && WaterContainer2.CheckCollision(WaterContainer1) && keyPressedE)        //Pour from 2 to 1
            {
                if (WaterContainer1.Amount + WaterContainer2.Amount <= WaterContainer1.Max)
                {
                    WaterContainer1.Amount += WaterContainer2.Amount;
                    WaterContainer2.Amount = 0;
                }
                else if (WaterContainer1.Amount + WaterContainer2.Amount > WaterContainer1.Max)
                {
                    WaterContainer2.Amount -= (WaterContainer1.Max - WaterContainer1.Amount);
                    WaterContainer1.Amount = WaterContainer1.Max;
                }
            }


        }

        // accessors
        public Interactable Sink
        {
            get
            {
                return sink;
            }
        }

        public int GoalAmount
        {
            get { return goalAmount; }
            set { goalAmount = value; }
        }

        public Interactable Drain
        {
            get
            {
                return drain;
            }
        }

        public WaterContainer FinalContainer
        {
            get
            {
                return finalContainer;
            }
        }

        public WaterContainer WaterContainer1
        {
            get
            {
                return waterContainer1;
            }
        }

        public WaterContainer WaterContainer2
        {
            get
            {
                return waterContainer2;
            }
        }
        // method to cover all possible interactions with the final container
        public void FinalContainerCondition(WaterContainer container)
        {
            if(container.Amount == goalAmount)
            {
                FinalContainer.Amount = container.Amount;
                DrainCup();
                Complete = true;
            }
        }

        // method to cover sink filling of containers
        public void Fill()
        {
            if (waterContainer1.OnOff)
            {
                waterContainer1.Amount = waterContainer1.Max;
            }

            else if (waterContainer2.OnOff)
            {
                waterContainer2.Amount = waterContainer2.Max;
            }
        }

        // method for using the drain
        public void DrainCup()
        {
            if (waterContainer1.OnOff)
            {
                waterContainer1.Amount = 0;
            }

            else if (waterContainer2.OnOff)
            {
                waterContainer2.Amount = 0;
            }
        }

    }
}
