using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
/*
 * Austin Stone
 * Section 2
 * This is our primary game class for all of our other classes to run in, a few stubs for later commented out for now
 */
namespace Puzzle07
{
    enum GameState { Menu, Game, InGameMenu, GameOver };

    // this enum will be used for the room transitions once rooms are set and made, if statements or switch statements will be made for each room and each will contain the code for the enum above along with their unique room and object code
    enum RoomEnum {Room1, Room2 /*, Room3, Room4*/ };
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D floorTex;
        Texture2D cupSmall;
        Texture2D cupLarge;
        Texture2D sinkTex;
        Texture2D drainTex;
        Texture2D doorTex;
        Texture2D wallTex;
        Texture2D vertWallTex;
        Texture2D sprite;
        Texture2D objectSprite1;
        Texture2D interSprite1;
        Texture2D buttonTexture;
        Texture2D menuTitle;
        Texture2D spriteSheet;
        SpriteFont font;
        Player player;
        List<Interactable> interact;
        int level;
        GameObject objectTest;
        Interactable lightswitch;
        Lever testLever;
        Door testDoor;
        Cursor cursor;
        RoomExit exit;
      
        Sprite testSprite;
        Wall wall1; // left wall
        Wall wall2; // right wall
        Wall wall3; // bottom wall
        Wall wall4; // wall left of door
        Wall wall5; // wall right of door
        //double time;
        
        
        GameState gameState;
        RoomEnum roomState;
        WaterRoom waterRoom;
        Random rngWater;
        Boolean[] wasd = { false, false, false, false };
        string[] wasdStr = { "W", "A", "S", "D" };
        KeyboardState kbState;
        KeyboardState previousKbState;
        MouseState mouse;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280; //Can be commented back in, changes the size of the screen. C; - Michael
            graphics.PreferredBackBufferHeight = 1024;
        }

       
        
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player = new Player(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, 100, 100);
            rngWater = new Random();
            gameState = GameState.Menu;
            roomState = RoomEnum.Room1;
            wall1 = new Wall(-10, 0, 20, 1024);
            wall2 = new Wall(1270, 0, 20, 1024);
            wall3 = new Wall(0, 1014, 1280, 20);
            wall4 = new Wall(0, 0, 448, 20);
            wall5 = new Wall(576, 0, 700, 20);
            exit = new RoomExit(448, -50, 128, 128);
            interact = new List<Interactable>();
            lightswitch = new Interactable(200, 200, 100, 100);
            kbState = Keyboard.GetState();
            this.IsMouseVisible = false;
            testDoor = new Door(448, -50, 128, 128);
            testLever = new Puzzle07.Lever(testDoor, 300, 300, 32, 32);
            cursor = new Cursor(0, 0, 16, 16);
           
            testSprite = new Puzzle07.Sprite(32, 32, 50, 8, new Vector2(100, 700));
            waterRoom = new WaterRoom(kbState, player, new Rectangle(50, 600, 128, 128), new Rectangle(100, 100, 128, 128), new Rectangle(700, 100, 64, 64), new Rectangle(800, 100, 64, 64), rngWater.Next(2, 7), rngWater.Next(2, 7), new Rectangle(500, 700, 64, 64));
            interact.Add(lightswitch);
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sprite = Content.Load<Texture2D>("PlayerSprite");
            objectSprite1 = Content.Load<Texture2D>("enemySprite");
            interSprite1 = Content.Load<Texture2D>("enemySprite");
            buttonTexture = Content.Load<Texture2D>("buttonTexture");
            menuTitle = Content.Load<Texture2D>("menuTitle");
            font = Content.Load<SpriteFont>("mainFont");
            cupSmall = Content.Load<Texture2D>("WaterJugSmall");
            cupLarge = Content.Load<Texture2D>("WaterJugLarge");
            drainTex = Content.Load<Texture2D>("Drain");
            wallTex = Content.Load<Texture2D>("Wall");
            vertWallTex = Content.Load<Texture2D>("WallVertical");
            doorTex = Content.Load<Texture2D>("Door");
            sinkTex = Content.Load<Texture2D>("Sink");
            floorTex = Content.Load<Texture2D>("FloorTileBlank");
            //spriteSheet = Content.Load<Texture2D>("testSpriteSheet");
            player.Texture = sprite;
            lightswitch.Texture = interSprite1;
            testLever.Texture = interSprite1;
            testDoor.Texture = doorTex;
            cursor.Texture = interSprite1;
            
            wall1.Texture = vertWallTex;
            wall2.Texture = vertWallTex;
            wall3.Texture = wallTex;
            wall4.Texture = wallTex;
            wall5.Texture = wallTex;
            waterRoom.WaterContainer1.Texture = cupSmall;
            waterRoom.WaterContainer2.Texture = cupSmall;
            waterRoom.Sink.Texture = sinkTex;
            waterRoom.Drain.Texture = drainTex;
            waterRoom.FinalContainer.Texture = cupLarge;
            //testSprite.Image = spriteSheet;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            

            // gets new keyborad state
            kbState = Keyboard.GetState();

            mouse = Mouse.GetState();
            cursor.Update(mouse);
            // finite state machine checks
            if (roomState == RoomEnum.Room1)
            {
                if (gameState == GameState.Menu)
                {

                    if (SingleKeyPress(Keys.Enter))
                    {

                        gameState = GameState.Game;
                        ResetGame();
                    }
                }

                else if (gameState == GameState.Game)
                {
                    
                    player.Move(kbState); //Made a move method so that we're not looking at a massive if statement - Michael
                                          //time -= gameTime.ElapsedGameTime.TotalSeconds;

                    


                    ScreenWrap(player);

                    if (SingleKeyPress(Keys.P))
                    {
                        gameState = GameState.InGameMenu;
                    }
                    if (SingleKeyPress(Keys.B))
                    {
                        gameState = GameState.GameOver;
                    }

                    /*bool isColliding = lightswitch.CheckCollision(player);
                    
                    if (isColliding == true && SingleKeyPress(Keys.E) && lightswitch.OnOff == false) // kept this code here just in case anyone wanted to reuse it - Austin
                    {
                        lightswitch.OnOff = true;
                    }
                    else if (isColliding == true && SingleKeyPress(Keys.E) && lightswitch.OnOff == true)
                    {
                        lightswitch.OnOff = false;
                    }

                    isColliding = testLever.CheckCollision(player);
                    if (isColliding == true && SingleKeyPress(Keys.E))
                    {
                        testLever.StateChanged();
                        if (testLever.OnOff == true)
                        {
                            testLever.OnOff = false;
                        }
                        else
                        {
                            testLever.OnOff = true;
                        }
                    }
                    */
                    testDoor.Collision(player);

                   

                    bool isColliding1 = waterRoom.WaterContainer1.CheckCollision(player);
                    if (isColliding1 && SingleKeyPress(Keys.E) && waterRoom.WaterContainer2.OnOff == false)
                    {
                        waterRoom.WaterContainer1.OnOff = true;
                        
                    }
                    if (waterRoom.WaterContainer1.CheckCollision(waterRoom.Sink) && SingleKeyPress(Keys.E))
                    {
                        waterRoom.Fill();
                    }
                    else if (waterRoom.WaterContainer1.CheckCollision(waterRoom.FinalContainer) && SingleKeyPress(Keys.E))
                    {
                        waterRoom.FinalContainerCondition();
                    }

                    else if (waterRoom.WaterContainer1.CheckCollision(waterRoom.Drain) && SingleKeyPress(Keys.E))
                    {
                        waterRoom.DrainCup();
                    }

                    if (waterRoom.WaterContainer1.OnOff == true && SingleKeyPress(Keys.Q))
                    {
                        waterRoom.WaterContainer1.OnOff = false;
                    }

                    bool isColliding2 = waterRoom.WaterContainer2.CheckCollision(player);
                    if (isColliding2 && SingleKeyPress(Keys.E) && waterRoom.WaterContainer1.OnOff == false)
                    {
                        waterRoom.WaterContainer2.OnOff = true;
                        
                    }

                    if (waterRoom.WaterContainer2.CheckCollision(waterRoom.Sink) && SingleKeyPress(Keys.E))
                    {
                        waterRoom.Fill();
                    }

                    else if (waterRoom.WaterContainer2.CheckCollision(waterRoom.FinalContainer) && SingleKeyPress(Keys.E))
                    {
                        waterRoom.FinalContainerCondition();
                    }

                    else if (waterRoom.WaterContainer2.CheckCollision(waterRoom.Drain) && SingleKeyPress(Keys.E))
                    {
                        waterRoom.DrainCup();
                    }

                    if (waterRoom.WaterContainer2.OnOff == true && SingleKeyPress(Keys.Q))
                    {
                        waterRoom.WaterContainer2.OnOff = false;
                    }

                    if (waterRoom.Complete)
                    {
                        testDoor.OpenDoor(true);
                        if (exit.ChangeRoom(player, waterRoom.Complete))
                        {
                            roomState = RoomEnum.Room2;
                        }
                        
                    }
                    
                
                    waterRoom.WaterContainer1.Update(gameTime, player);
                    waterRoom.WaterContainer2.Update(gameTime, player);
                    wall1.Update(player);
                    wall2.Update(player);
                    wall3.Update(player);
                    wall4.Update(player);
                    wall5.Update(player);
                    //testSprite.Update(gameTime);

                    /*if(time =< 0)
                     {
                         gameState = GameState.GameOver;
                     }*/

                    /*if()
                    {
                        NextLevel();
                    }*/

                }

                else if (gameState == GameState.InGameMenu)
                {
                    if (SingleKeyPress(Keys.P))
                    {
                        gameState = GameState.Game;
                    }
                }

                else
                {
                    if (SingleKeyPress(Keys.Enter))
                    {
                        gameState = GameState.Menu;

                    }
                }

                // stores old keyboard state for check
                previousKbState = kbState;

                base.Update(gameTime);
            }

            else if (roomState == RoomEnum.Room2)
            {
                if (gameState == GameState.Menu)
                {

                    if (SingleKeyPress(Keys.Enter))
                    {

                        gameState = GameState.Game;
                        ResetGame();
                    }
                }

                else if (gameState == GameState.Game)
                {

                    player.Move(kbState); //Made a move method so that we're not looking at a massive if statement - Michael
                                          //time -= gameTime.ElapsedGameTime.TotalSeconds;

                    // if statements to check if each of the movement keys are being pressed


                    ScreenWrap(player);

                    if (SingleKeyPress(Keys.P))
                    {
                        gameState = GameState.InGameMenu;
                    }

                    bool isColliding = lightswitch.CheckCollision(player);
                    if (isColliding == true && SingleKeyPress(Keys.E) && lightswitch.OnOff == false)
                    {
                        lightswitch.OnOff = true;
                    }
                    else if (isColliding == true && SingleKeyPress(Keys.E) && lightswitch.OnOff == true)
                    {
                        lightswitch.OnOff = false;
                    }

                    isColliding = testLever.CheckCollision(player);
                    if (isColliding == true && SingleKeyPress(Keys.E))
                    {
                        testLever.StateChanged();
                        if (testLever.OnOff == true)
                        {
                            testLever.OnOff = false;
                        }
                        else
                        {
                            testLever.OnOff = true;
                        }
                    }

                    testDoor.Collision(player);

                    
                    //testSprite.Update(gameTime);

                    /*if(time =< 0)
                     {
                         gameState = GameState.GameOver;
                     }*/

                    /*if()
                    {
                        NextLevel();
                    }*/

                }

                else if (gameState == GameState.InGameMenu)
                {
                    if (SingleKeyPress(Keys.P))
                    {
                        gameState = GameState.Game;
                    }
                }

                else
                {
                    if (SingleKeyPress(Keys.Enter))
                    {
                        gameState = GameState.Menu;

                    }
                }

                // stores old keyboard state for check
                previousKbState = kbState;

                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            cursor.Draw(spriteBatch);

            // check game state and draw what is needed in each
            if (roomState == RoomEnum.Room1)
            {
                if (gameState == GameState.Menu)
                {
                    //spriteBatch.DrawString(font, "Puzzle07", new Vector2(350f, 200f), Color.Black);
                    spriteBatch.DrawString(font, "Press Enter to continue, move with WASD, interact with E, and P to pause", new Vector2(50, 400f), Color.Black, 0, new Vector2(0, 0), (float).8, SpriteEffects.None, 0);
                    spriteBatch.Draw(buttonTexture, new Rectangle(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100, 200, 100), Color.White);  //Start Button
                    spriteBatch.Draw(buttonTexture, new Rectangle(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 + 25, 200, 100), Color.White);   //Exit Button
                    spriteBatch.Draw(menuTitle, new Rectangle(GraphicsDevice.Viewport.Width / 2 - 250, 25, 500, 100), Color.White);            //Title
                }

                else if (gameState == GameState.Game)
                {
                    // wall and floor draw code 
                    wall1.Draw(spriteBatch);
                    wall2.Draw(spriteBatch);
                    wall3.Draw(spriteBatch);
                    wall4.Draw(spriteBatch);
                    wall5.Draw(spriteBatch);
                    spriteBatch.Draw(floorTex, new Rectangle(0, 0, 1280, 1024), Color.White);
                    
                    // draw code for water room
                    spriteBatch.DrawString(font, "Current: " + waterRoom.FinalContainer.Amount.ToString(), new Vector2(50, 80), Color.Black);
                    spriteBatch.DrawString(font, "Max: " + waterRoom.FinalContainer.Max.ToString(), new Vector2(200, 80), Color.Black);
                    
                    waterRoom.Sink.Draw(spriteBatch);
                    waterRoom.WaterContainer1.Draw(spriteBatch);
                    waterRoom.WaterContainer2.Draw(spriteBatch);
                    waterRoom.FinalContainer.Draw(spriteBatch);
                    waterRoom.Drain.Draw(spriteBatch);
                    
                    
                    spriteBatch.Draw(testDoor.Texture, testDoor.Position, Color.White);
                    
                    if (testDoor.IsOpen == true)
                    {
                        spriteBatch.DrawString(font, "Open", new Vector2(testDoor.X, testDoor.Y), Color.Black);
                    }
                    else if (testDoor.IsOpen == false)
                    {
                        spriteBatch.DrawString(font, "Closed", new Vector2(testDoor.X, testDoor.Y), Color.Black);
                    }


                    spriteBatch.Draw(player.Texture, player.Position, Color.White);

                   

                    //testSprite.Draw(spriteBatch);

                    //spriteBatch.DrawString(font, "Room: " + level, new Vector2(10, 10), Color.Black);
                    //spriteBatch.DrawString(font, string.Format("Time: {0:0.00}", time), new Vector2(400, 10), Color.Black);


                }

                else if (gameState == GameState.InGameMenu)
                {
                    spriteBatch.DrawString(font, "Pause", new Vector2(250f, 10f), Color.Black);
                }
                else
                {
                    spriteBatch.DrawString(font, "Game Over", new Vector2(250f, 10f), Color.Black);
                    spriteBatch.DrawString(font, String.Format("{0:0.00}", level), new Vector2(250f, 100f), Color.Black);
                    //spriteBatch.DrawString(font, String.Format("{0:0.00}", player.TotalScore), new Vector2(250f, 200f), Color.Black);
                    spriteBatch.DrawString(font, "Press Enter to continue", new Vector2(250f, 400f), Color.Black);
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        // Method for setting up the next level for the player
        void NextLevel()
        {
            

            // sets all the variables created above
            level += 1;
            //time = 10.00;
         
            player.X = GraphicsDevice.Viewport.Width / 2;
            player.Y = GraphicsDevice.Viewport.Height / 2;
            interact.Clear();

            interact.Add(lightswitch);

            
            

        }

        // method for resetting the game when switching states
        void ResetGame()
        {
            level = 0;
            //player.TotalScore = 0;
            NextLevel();
        }

        // method to keep player from going off screen
        void ScreenWrap(GameObject game)
        {

            if(game.X >= GraphicsDevice.Viewport.Width - player.Width)
            {
                game.X = (GraphicsDevice.Viewport.Width - player.Width);
            }

            else if (game.X < 0)
            {
                game.X = 0;
            }


            //Quality of life improvement, now properly prevents the player from leaving the boundaries of the room.

            if(game.Y >= GraphicsDevice.Viewport.Height - player.Height)
            {
                game.Y = GraphicsDevice.Viewport.Height - player.Height;
            }
            
            else if(game.Y < 0)
            {
                game.Y = 0;
            }
        }

        // method for checking for a single key press
        bool SingleKeyPress(Keys key)
        {
            if(kbState.IsKeyDown(key) && previousKbState.IsKeyUp(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
