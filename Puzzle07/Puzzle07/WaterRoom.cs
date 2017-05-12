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

        // constructor
        public WaterRoom(KeyboardState kState, Player plyer, Rectangle sinkPos, Rectangle finalContPos, Rectangle waterContPos1, Rectangle waterContPos2, int contMax1, int contMax2, Rectangle drainPos): base(kState, plyer)
        {
            sink = new Interactable(sinkPos.X, sinkPos.Y, sinkPos.Width, sinkPos.Height);
            drain = new Interactable(drainPos.X, drainPos.Y, drainPos.Width, drainPos.Height);
            finalContainer = new WaterContainer(contMax1 + contMax2, 0, finalContPos.X, finalContPos.Y, finalContPos.Width, finalContPos.Height);
            waterContainer1 = new WaterContainer(contMax1, 0, waterContPos1.X, waterContPos1.Y, waterContPos1.Width, waterContPos1.Height);
            waterContainer2 = new WaterContainer(contMax2, 0, waterContPos2.X, waterContPos2.Y, waterContPos2.Width, waterContPos2.Height);

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



            bool isColliding1 = WaterContainer1.CheckCollision(Player1);
            if (isColliding1 && keyPressedE && WaterContainer2.OnOff == false)
            {
                WaterContainer1.OnOff = true;

            }
            if (WaterContainer1.CheckCollision(Sink) && keyPressedE)
            {
                Fill();
            }
            else if (WaterContainer1.CheckCollision(FinalContainer) && keyPressedE)
            {
                FinalContainerCondition();
            }

            else if (WaterContainer1.CheckCollision(Drain) && keyPressedE)
            {
                DrainCup();
            }

            if (WaterContainer1.OnOff == true && keyPressedQ)
            {
                WaterContainer1.OnOff = false;
            }

            bool isColliding2 = WaterContainer2.CheckCollision(Player1);
            if (isColliding2 && keyPressedE && WaterContainer1.OnOff == false)
            {
                WaterContainer2.OnOff = true;

            }

            if (WaterContainer2.CheckCollision(Sink) && keyPressedE)
            {
                Fill();
            }

            else if (WaterContainer2.CheckCollision(FinalContainer) && keyPressedE)
            {
                FinalContainerCondition();
            }

            else if (WaterContainer2.CheckCollision(Drain) && keyPressedE)
            {
                DrainCup();
            }

            if (WaterContainer2.OnOff == true && keyPressedQ)
            {
                WaterContainer2.OnOff = false;
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
        public void FinalContainerCondition()
        {

            if (finalContainer.Max == finalContainer.Amount) // if the tank is full
            {
                Complete = true;
            }

            else if(waterContainer1.Amount == 0 && waterContainer1.OnOff && finalContainer.Amount != 0) // code to take water out of the big tank using container 1
            {
                waterContainer1.Amount = waterContainer1.Max;
                finalContainer.Amount = finalContainer.Amount - waterContainer1.Max;
            }

            else if(waterContainer2.Amount == 0 && waterContainer2.OnOff && finalContainer.Amount != 0) // code to take water out of the big tank using container 2
            {
                waterContainer2.Amount = waterContainer2.Max;
                finalContainer.Amount = finalContainer.Amount - waterContainer2.Max;
            }

            

            else if(finalContainer.Max < finalContainer.Amount + waterContainer1.Amount && waterContainer1.OnOff) // code to check if the amount being put in is greater than the big tank max
            {
                finalContainer.Amount = finalContainer.Amount - waterContainer1.Amount;
            }

            else if (finalContainer.Max < finalContainer.Amount + waterContainer2.Amount && waterContainer2.OnOff) // same as the one above but for container 2
            {
                finalContainer.Amount = finalContainer.Amount - waterContainer2.Amount;
            }

            else if(finalContainer.Max >= finalContainer.Amount + waterContainer1.Amount && waterContainer1.OnOff) // code to add water to big tank using water container 1
            {
                finalContainer.Amount = finalContainer.Amount + waterContainer1.Amount;
                waterContainer1.Amount = 0;
            }
            else if(finalContainer.Max >= finalContainer.Amount + waterContainer2.Amount && waterContainer2.OnOff) // code to add water to big tank using water container 2
            {
                finalContainer.Amount = finalContainer.Amount + waterContainer2.Amount;
                waterContainer2.Amount = 0;
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
