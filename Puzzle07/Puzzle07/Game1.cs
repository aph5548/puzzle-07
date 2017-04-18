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
    enum RoomEnum {Room1, Room2, Room3, Room4 };
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D sprite;
        Texture2D objectSprite1;
        Texture2D interSprite1;
        Texture2D buttonTexture;
        Texture2D menuTitle;
        SpriteFont font;
        Player player;
        List<Interactable> interact;
        int level;
        GameObject objectTest;
        Interactable lightswitch;
        Lever testLever;
        Door testDoor;
        //double time;
        
        
        GameState gameState;
        Boolean[] wasd = { false, false, false, false };
        string[] wasdStr = { "W", "A", "S", "D" };
        KeyboardState kbState;
        KeyboardState previousKbState;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            //graphics.PreferredBackBufferWidth = 1280; Can be commented back in, changes the size of the screen. C; - Michael
            //graphics.PreferredBackBufferHeight = 1024;
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
            gameState = GameState.Menu;
            interact = new List<Interactable>();
            lightswitch = new Interactable(200, 200, 100, 100);
            kbState = Keyboard.GetState();
            this.IsMouseVisible = true;
            testDoor = new Door(400, 200, 128, 128);
            testLever = new Puzzle07.Lever(testDoor, 300, 300, 32, 32);

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
            sprite = Content.Load<Texture2D>("characterSprite");
            objectSprite1 = Content.Load<Texture2D>("enemySprite");
            interSprite1 = Content.Load<Texture2D>("enemySprite");
            buttonTexture = Content.Load<Texture2D>("buttonTexture");
            menuTitle = Content.Load<Texture2D>("menuTitle");
            font = Content.Load<SpriteFont>("mainFont");
            player.Texture = sprite;
            lightswitch.Texture = interSprite1;
            testLever.Texture = interSprite1;
            testDoor.Texture = interSprite1;
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
            // finite state machine checks
            if (gameState == GameState.Menu)
            {
                
                if (SingleKeyPress(Keys.Enter))
                {
                    
                    gameState = GameState.Game;
                    ResetGame();
                }
            }

            else if(gameState == GameState.Game)
            {

                player.Move(kbState); //Made a move method so that we're not looking at a massive if statement - Michael
                //time -= gameTime.ElapsedGameTime.TotalSeconds;

                // if statements to check if each of the movement keys are being pressed
                

                ScreenWrap(player);

                if (SingleKeyPress(Keys.P))
                {
                    gameState = GameState.InGameMenu;
                }
                // main check for player collision that allows E press if in range
                /*foreach(Interactable inter in interact)
                {
                    bool collision = inter.CheckCollision(player);
                    if (collision == true && SingleKeyPress(Keys.E))
                    {
                        inter.Active = false;
                        if(inter == lightswitch)
                        {
                            
                            lightswitch.Active = true;
                            
                        }
                        
                    }
                    
                    
                }*/

                bool isColliding = lightswitch.CheckCollision(player); 
                if(isColliding == true && SingleKeyPress(Keys.E) && lightswitch.OnOff == false)
                {
                    lightswitch.OnOff = true;
                }
                else if(isColliding == true && SingleKeyPress(Keys.E) && lightswitch.OnOff == true)
                {
                    lightswitch.OnOff = false;
                }

                isColliding = testLever.CheckCollision(player);
                if(isColliding == true && SingleKeyPress(Keys.E))
                {
                    testLever.StateChanged();
                    if(testLever.OnOff == true)
                    {
                        testLever.OnOff = false;
                    }
                    else
                    {
                        testLever.OnOff = true;
                    }
                }

                testDoor.Collision(player);

               /*if(time =< 0)
                {
                    gameState = GameState.GameOver;
                }*/

                    /*if()
                    {
                        NextLevel();
                    }*/

            }

            else if(gameState == GameState.InGameMenu)
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

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            // check game state and draw what is needed in each
            if (gameState == GameState.Menu)
            {
                //spriteBatch.DrawString(font, "Puzzle07", new Vector2(350f, 200f), Color.Black);
                spriteBatch.DrawString(font, "Press Enter to continue, move with WASD, interact with E, and P to pause", new Vector2(50, 400f), Color.Black, 0, new Vector2(0,0), (float).8, SpriteEffects.None, 0);
                spriteBatch.Draw(buttonTexture, new Rectangle(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100, 200, 100), Color.White);  //Start Button
                spriteBatch.Draw(buttonTexture, new Rectangle(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 + 25, 200, 100), Color.White);   //Exit Button
                spriteBatch.Draw(menuTitle, new Rectangle(GraphicsDevice.Viewport.Width / 2 - 250, 25, 500, 100), Color.White);            //Title
            }

            else if (gameState == GameState.Game)
            {
                /*foreach(Interactable inter in interact)
                {
                    inter.Draw(spriteBatch);

                    // changing background color on collision and key press not working currently, fix tomorrow in meeting
                    if (lightswitch.CheckCollision(player) && SingleKeyPress(Keys.E))
                    {
                        GraphicsDevice.Clear(Color.Black);
                        lightswitch.OnOff = true;
                        if (lightswitch.CheckCollision(player) && SingleKeyPress(Keys.E))
                        {
                            GraphicsDevice.Clear(Color.CornflowerBlue);
                        }
                    }
                }*/
                lightswitch.Draw(spriteBatch);
                if(lightswitch.OnOff == true)
                {
                    GraphicsDevice.Clear(Color.Black);
                }
                else
                {
                    GraphicsDevice.Clear(Color.CornflowerBlue);
                }
                //To be commented out and removed
                spriteBatch.Draw(player.Texture, player.Position, Color.White);
                spriteBatch.Draw(testLever.Texture, testLever.Position, Color.White);
                spriteBatch.Draw(testDoor.Texture, testDoor.Position, Color.White);
                if(testDoor.IsOpen == true)
                {
                    spriteBatch.DrawString(font, "Open", new Vector2(testDoor.X, testDoor.Y), Color.Black);
                }
                else if(testDoor.IsOpen == false)
                {
                    spriteBatch.DrawString(font, "Closed", new Vector2(testDoor.X, testDoor.Y), Color.Black);
                }

                if (testLever.OnOff == true)
                {
                    spriteBatch.DrawString(font, "On", new Vector2(testLever.X, testLever.Y), Color.Black);
                }
                else if (testLever.OnOff == false)
                {
                    spriteBatch.DrawString(font, "Off", new Vector2(testLever.X, testLever.Y), Color.Black);
                }


                //spriteBatch.DrawString(font, "Room: " + level, new Vector2(10, 10), Color.Black);
                //spriteBatch.DrawString(font, string.Format("Time: {0:0.00}", time), new Vector2(400, 10), Color.Black);


            }

            else if(gameState == GameState.InGameMenu)
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
<<<<<<< HEAD
            if(game.X >= (GraphicsDevice.Viewport.Width - player.Width))
=======
            if(game.X >= GraphicsDevice.Viewport.Width - player.Width)
>>>>>>> 4f85c6e68b32a52d72ff5692f47dc9b5d392a037
            {
                game.X = (GraphicsDevice.Viewport.Width - player.Width);
            }

            else if (game.X < 0)
            {
                game.X = 0;
            }

<<<<<<< HEAD
            if(game.Y >= (GraphicsDevice.Viewport.Height - player.Height)) //Quality of life improvement, now properly prevents the player from leaving the boundaries of the room.
=======
            if(game.Y >= GraphicsDevice.Viewport.Height - player.Height)
>>>>>>> 4f85c6e68b32a52d72ff5692f47dc9b5d392a037
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
