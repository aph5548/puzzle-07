﻿using Microsoft.Xna.Framework;
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
        SpriteFont font;
        Player player;
        List<Interactable> interact;
        int level;
        GameObject objectTest;
        Interactable lightswitch;
        //double time;
        
        
        GameState gameState;
        Boolean[] wasd = { false, false, false, false };
        string[] wasdStr = { "W", "A", "S", "D" };
        KeyboardState kbState;
        KeyboardState previousKbState;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
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
            player.Texture = sprite;
            lightswitch.Texture = interSprite1;
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
                

                //time -= gameTime.ElapsedGameTime.TotalSeconds;

                // if statements to check if each of the movement keys are being pressed
                if (kbState.IsKeyDown(Keys.W))
                {
                    wasd[0] = true;
                    player.Position = new Rectangle(player.X, player.Y - 5, player.Width, player.Height);
                }

                else
                {
                    wasd[0] = false;
                }

                if (kbState.IsKeyDown(Keys.A))
                {
                    wasd[1] = true;
                    player.Position = new Rectangle(player.X - 5, player.Y, player.Width, player.Height);
                }

                else
                {
                    wasd[1] = false;
                }

                if (kbState.IsKeyDown(Keys.S))
                {
                    wasd[2] = true;
                    player.Position = new Rectangle(player.X, player.Y + 5, player.Width, player.Height);
                }

                else
                {
                    wasd[2] = false;
                }

                if (kbState.IsKeyDown(Keys.D))
                {
                    wasd[3] = true;
                    player.Position = new Rectangle(player.X + 5, player.Y, player.Width, player.Height);
                }

                else
                {
                    wasd[3] = false;
                }

                ScreenWrap(player);

                if (SingleKeyPress(Keys.P))
                {
                    gameState = GameState.InGameMenu;
                }
                // main check for player collision that allows E press if in range
                foreach(Interactable inter in interact)
                {
                    bool collision = inter.CheckCollision(player);
                    if (collision && SingleKeyPress(Keys.E))
                    {
                        inter.Active = false;
                        if(inter == lightswitch)
                        {
                            
                            lightswitch.Active = true;
                            
                        }
                        
                    }
                    
                    
                }

               /*if(time < 0)
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
                spriteBatch.DrawString(font, "Puzzle07", new Vector2(350f, 200f), Color.Black);
                spriteBatch.DrawString(font, "Press Enter to continue, move with WASD, interact with E, and P to pause", new Vector2(50, 400f), Color.Black, 0, new Vector2(0,0), (float).8, SpriteEffects.None, 0);
            }

            else if (gameState == GameState.Game)
            {
                foreach(Interactable inter in interact)
                {
                    inter.Draw(spriteBatch);

                    // changing background color on collision and key press not working currently, fix tomorrow in meeting
                    if (lightswitch.CheckCollision(player) && SingleKeyPress(Keys.E))
                    {
                        GraphicsDevice.Clear(Color.Black);
                        lightswitch.Active = true;
                        if (lightswitch.CheckCollision(player) && SingleKeyPress(Keys.E))
                        {
                            GraphicsDevice.Clear(Color.CornflowerBlue);
                        }
                    }
                }
                
                spriteBatch.Draw(player.Texture, player.Position, Color.White);
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
            if(game.X >= GraphicsDevice.Viewport.Width)
            {
                game.X = GraphicsDevice.Viewport.Width - player.Width;
            }

            else if (game.X < 0)
            {
                game.X = 0;
            }

            if(game.Y >= GraphicsDevice.Viewport.Height)
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
