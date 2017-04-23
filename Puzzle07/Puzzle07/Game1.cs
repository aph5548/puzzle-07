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
        Texture2D cup;
        Texture2D sprite;
        Texture2D objectSprite1;
        Texture2D interSprite1;
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
        WaterContainer testContainer;
        Sprite testSprite;
        Button start;
        Button quit;
        //double time;
        
        
        GameState gameState;
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
            gameState = GameState.Menu;
            interact = new List<Interactable>();
            lightswitch = new Interactable(200, 200, 100, 100);
            kbState = Keyboard.GetState();
            this.IsMouseVisible = true  ;
            testDoor = new Door(400, 200, 128, 128);
            testLever = new Puzzle07.Lever(testDoor, 300, 300, 32, 32);
            cursor = new Cursor(0, 0, 16, 16);
            testContainer = new WaterContainer(5, 0, 500, 500, 32, 32);
            testSprite = new Puzzle07.Sprite(32, 32, 50, 8, new Vector2(100, 700));
            interact.Add(lightswitch);
            start = new Button();
            start.Location = new Rectangle(50, 400, 500, 100);
            quit = new Button();
            quit.Location = new Rectangle(50, 520, 500, 100);
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
            font = Content.Load<SpriteFont>("mainFont");
            cup = Content.Load<Texture2D>("Cup");
            spriteSheet = Content.Load<Texture2D>("testSpriteSheet");
            player.Texture = sprite;
            lightswitch.Texture = interSprite1;
            testLever.Texture = interSprite1;
            testDoor.Texture = interSprite1;
            cursor.Texture = interSprite1;
            testContainer.Texture = cup;
            testSprite.Image = spriteSheet;
            start.Texture = Content.Load<Texture2D>("StartButton");
            quit.Texture = Content.Load<Texture2D>("ExitButton");
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
            if (gameState == GameState.Menu)
            {
                //Check too see if the buttons are clicked or not

                if (cursor.Position.Intersects(start.Location) && mouse.LeftButton == ButtonState.Pressed)
                {
                    gameState = GameState.Game; //start the game
                    ResetGame();
                }
                if(cursor.Position.Intersects(quit.Location) && mouse.LeftButton == ButtonState.Pressed)
                {
                    Exit(); //Quit
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

                isColliding = testContainer.CheckCollision(player);
                if(isColliding && SingleKeyPress(Keys.E))
                {
                    testContainer.OnOff = true;
                }

                if(testContainer.OnOff == true && SingleKeyPress(Keys.Q))
                {
                    testContainer.OnOff = false;
                }

                testContainer.Update(gameTime, player);
                testSprite.Update(gameTime);

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
            GraphicsDevice.Clear(Color.LightGray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            cursor.Draw(spriteBatch);

            // check game state and draw what is needed in each
            if (gameState == GameState.Menu)
            {
                //Draw each of the main menu buttons, if the mouse if hovering over them then tint them a different color

                if (cursor.Position.Intersects(start.Location))
                    spriteBatch.Draw(start.Texture, start.Location, Color.DarkGray);
                else
                    spriteBatch.Draw(start.Texture, start.Location, Color.White);

                if (cursor.Position.Intersects(quit.Location))
                    spriteBatch.Draw(quit.Texture, quit.Location, Color.DarkGray);
                else
                    spriteBatch.Draw(quit.Texture, quit.Location, Color.White);
                spriteBatch.DrawString(font, "Puzzle07", new Vector2(50f, 100f), Color.Black);
                //Title
            }

            else if (gameState == GameState.Game)
            {
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

                spriteBatch.Draw(player.Texture, player.Position, Color.White);

                testContainer.Draw(spriteBatch);

                testSprite.Draw(spriteBatch);

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
