using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
/*
 * Austin Stone
 * Section 2
 * This is our primary game class for all of our other classes to run in, a few stubs for later commented out for now
 */
namespace Puzzle07
{
    enum GameState { Menu, Game, InGameMenu, GameOver };

    // this enum will be used for the room transitions once rooms are set and made, if statements or switch statements will be made for each room and each will contain the code for the enum above along with their unique room and object code
    enum RoomEnum {Room1, Room2 , Room3, Room4 };
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
        Texture2D detectTex;
        Texture2D lever;
        SpriteFont font;
        Player player;
        List<Interactable> interact;
        int level;
        GameObject objectTest;
        Interactable lightswitch;
        Lever testLever;
        Door testDoor;
        Door testDoor2;
        Cursor cursor;
        RoomExit exit;
        RoomExit exit2;
        Button start;
        Button quit;
        Sprite testSprite;
        Wall wall1; // left wall
        Wall wall2; // right wall
        Wall wall3; // bottom wall
        Wall wall4; // wall left of door
        Wall wall5; // wall right of door

        // middle walls in math room
        Wall wall6;
        Wall wall7;
        double timeSinceLastMove;
        LeverRoomAustin leverRoom;
        MathRoom mathRoom;
        RedLightRoom redLight;
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
            graphics.IsFullScreen = false;
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
            wall6 = new Wall(0, 650, 1280, 30);
            wall7 = new Wall(0, 250, 1280, 30);
            exit = new RoomExit(448, -50, 128, 128);
            exit2 = new RoomExit(448, -50, 128, 128);
            interact = new List<Interactable>();
            lightswitch = new Interactable(200, 200, 100, 100);
            kbState = Keyboard.GetState();
            this.IsMouseVisible = false;
            testDoor = new Door(448, -50, 128, 128);
            testDoor2 = new Door(448, -50, 128, 128);
            testLever = new Puzzle07.Lever(testDoor, 300, 300, 32, 32);
            cursor = new Cursor(0, 0, 16, 16);
            start = new Button();
            start.Location = new Rectangle(50, 400, 500, 100);
            quit = new Button();
            quit.Location = new Rectangle(50, 520, 500, 100);
            testSprite = new Puzzle07.Sprite(32, 32, 50, 8, new Vector2(100, 700));
            waterRoom = new WaterRoom(kbState, player, new Rectangle(50, 600, 128, 128), new Rectangle(100, 100, 128, 128), new Rectangle(700, 100, 64, 64), new Rectangle(800, 100, 64, 64), rngWater.Next(2, 7), rngWater.Next(2, 7), new Rectangle(500, 700, 64, 64));
            interact.Add(lightswitch);
            leverRoom = new LeverRoomAustin(kbState, player, new Rectangle(700, 100, 64, 64), new Rectangle(800, 100, 64, 64),drainTex, sinkTex);
            redLight = new RedLightRoom(kbState, player, new Rectangle(700, 100, 64, 64), new Rectangle(300, 700, 64, 64), new Rectangle(500, 500, 64, 64));
            mathRoom = new MathRoom(kbState, player);
            timeSinceLastMove = 0;
            ReadFile();


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
            start.Texture = Content.Load<Texture2D>("StartButton");
            lever = Content.Load<Texture2D>("LeverLeft");
            quit.Texture = Content.Load<Texture2D>("ExitButton");
            detectTex = Content.Load<Texture2D>("enemySprite");
            //spriteSheet = Content.Load<Texture2D>("testSpriteSheet");
            player.Texture = sprite;
            lightswitch.Texture = interSprite1;
            testLever.Texture = interSprite1;
            testDoor.Texture = doorTex;
            cursor.Texture = interSprite1;
            leverRoom.Lever1.Texture = lever;
            leverRoom.Lever3.Texture = lever;
            leverRoom.Lever4.Texture = lever;
            leverRoom.Lever5.Texture = lever;
            leverRoom.Lever6.Texture = lever;
            wall1.Texture = vertWallTex;
            wall2.Texture = vertWallTex;
            wall3.Texture = wallTex;
            wall4.Texture = wallTex;
            wall5.Texture = wallTex;
            wall6.Texture = wallTex;
            wall7.Texture = wallTex;
            waterRoom.WaterContainer1.Texture = cupSmall;
            waterRoom.WaterContainer2.Texture = cupSmall;
            waterRoom.Sink.Texture = sinkTex;
            waterRoom.Drain.Texture = drainTex;
            testDoor2.Texture = doorTex;
            waterRoom.FinalContainer.Texture = cupLarge;
            leverRoom.Lever1.Texture = lever;
            leverRoom.Lever2.Texture = lever;
            redLight.Lever1.Texture = lever;
            redLight.Lever2.Texture = lever;
            redLight.Lever3.Texture = lever;
            redLight.Detection.Texture = detectTex;
            mathRoom.Lever1.Texture = lever;
            mathRoom.Lever2.Texture = lever;
            mathRoom.Lever3.Texture = lever;
            mathRoom.Lever4.Texture = lever;
            mathRoom.Lever5.Texture = lever;
            mathRoom.Lever6.Texture = lever;
            mathRoom.Lever7.Texture = lever;
            mathRoom.Lever8.Texture = lever;
            mathRoom.Lever9.Texture = lever;
            mathRoom.Lever10.Texture = lever;
            mathRoom.Lever11.Texture = lever;
            mathRoom.Lever12.Texture = lever;
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

                    //Check too see if the buttons are clicked or not
                    
                  if (cursor.Position.Intersects(start.Location) && mouse.LeftButton == ButtonState.Pressed)
                    {
                        gameState = GameState.Game;
                        gameState = GameState.Game; //start the game
                        ResetGame();
                    }
                    if (cursor.Position.Intersects(quit.Location) && mouse.LeftButton == ButtonState.Pressed)
                    {
                        Exit();
                        Exit(); //Quit
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

                    waterRoom.Update(SingleKeyPress(Keys.E), SingleKeyPress(Keys.Q), gameTime);

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

                    leverRoom.Update(SingleKeyPress(Keys.E), gameTime);

                    if(leverRoom.Lever1.OnOff == true && leverRoom.Lever2.OnOff == false)
                    {
                        leverRoom.Complete = true;
                        testDoor2.OpenDoor(true);
                        if (exit2.ChangeRoom(player, leverRoom.Complete))
                        {
                            roomState = RoomEnum.Room3;
                        }
                    }

                    
                    testDoor2.Collision(player);
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

            else if (roomState == RoomEnum.Room3)
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

                    bool isColliding1 = redLight.Lever1.CheckCollision(player);
                    if (isColliding1 && SingleKeyPress(Keys.E) && redLight.Lever1.OnOff == false)
                    {
                        redLight.Lever1.OnOff = true;
                    }


                    else if (isColliding1 && SingleKeyPress(Keys.E) && redLight.Lever1.OnOff == true)
                    {
                        redLight.Lever1.OnOff = false;
                    }

                    bool isColliding2 = redLight.Lever2.CheckCollision(player);
                    if (isColliding2 && SingleKeyPress(Keys.E) && redLight.Lever2.OnOff == false)
                    {
                        redLight.Lever2.OnOff = true;
                    }

                    else if (isColliding2 && SingleKeyPress(Keys.E) && leverRoom.Lever2.OnOff == true)
                    {
                        redLight.Lever2.OnOff = false;
                    }

                    bool isColliding3 = redLight.Lever3.CheckCollision(player);
                    if (isColliding3 && SingleKeyPress(Keys.E) && redLight.Lever3.OnOff == false)
                    {
                        redLight.Lever3.OnOff = true;
                    }

                    else if (isColliding3 && SingleKeyPress(Keys.E) && redLight.Lever3.OnOff == true)
                    {
                        redLight.Lever3.OnOff = false;
                    }

                    // this is our time since last move double to keep track of when to move the detection block
                    timeSinceLastMove += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    
                    
                    // this is the code to move around the detection box
                    if(redLight.Detection.X <= 0 && timeSinceLastMove > 2)
                    {
                        timeSinceLastMove = 0;
                        redLight.Detection.X += 300;
                        
                    }

                    else if(redLight.Detection.X >= 1280 && timeSinceLastMove > 2)
                    {
                        timeSinceLastMove = 0;
                        redLight.Detection.X = 1;
                    }

                    if(redLight.Detection.Y <= 0 && timeSinceLastMove > 2)
                    {
                        timeSinceLastMove = 0;
                        redLight.Detection.Y += 300;
                    }

                    else if (redLight.Detection.Y >= 1024 && timeSinceLastMove > 2)
                    {
                        timeSinceLastMove = 0;
                        redLight.Detection.Y = 1;
                    }
                    if(redLight.Detection.Y > 0 && timeSinceLastMove > 2 && redLight.Detection.X > 0)
                    {
                        timeSinceLastMove = 0;
                        redLight.Detection.X += 300;
                        redLight.Detection.Y += 300;
                    }

                    if (redLight.IsDetected(kbState, player, redLight.Detection.Position))
                    {
                        player.X = 640;
                        player.Y = 1000;
                        redLight.Lever1.OnOff = false;
                        redLight.Lever2.OnOff = false;
                        redLight.Lever3.OnOff = false;
                        testDoor2.OpenDoor(false);
                    }

                    if(redLight.Lever1.OnOff == true && redLight.Lever2.OnOff == true && redLight.Lever3.OnOff == true)
                    {
                        redLight.Complete = true;
                        testDoor2.OpenDoor(true);
                        if (exit2.ChangeRoom(player, redLight.Complete))
                        {
                            roomState = RoomEnum.Room4;
                        }
                    }


                    testDoor2.Collision(player);
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

            else if (roomState == RoomEnum.Room4)
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
                    timeSinceLastMove += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (timeSinceLastMove <= 1)
                    {
                        player.X = 640;
                        player.Y = 1000;
                        
                    }
                    
                    player.Move(kbState); //Made a move method so that we're not looking at a massive if statement - Michael
                                          //time -= gameTime.ElapsedGameTime.TotalSeconds;

                    // if statements to check if each of the movement keys are being pressed


                    ScreenWrap(player);

                    if (SingleKeyPress(Keys.P))
                    {
                        gameState = GameState.InGameMenu;
                    }

                    // SO MANY LEVERS!!!! (note to self: make loop to handle all of these after to make this neat)
                    bool isColliding1 = mathRoom.Lever1.CheckCollision(player);
                    if (isColliding1 && SingleKeyPress(Keys.E) && mathRoom.Lever1.OnOff == false)
                    {
                        mathRoom.Lever1.OnOff = true;
                        wall6.Width = 0;
                        wall6.Height = 0;
                    }


                    else if (isColliding1 && SingleKeyPress(Keys.E) && mathRoom.Lever1.OnOff == true)
                    {
                        mathRoom.Lever1.OnOff = false;
                    }

                    bool isColliding2 = mathRoom.Lever2.CheckCollision(player);
                    if (isColliding2 && SingleKeyPress(Keys.E) && mathRoom.Lever2.OnOff == false)
                    {
                        mathRoom.Lever2.OnOff = true;
                    }

                    else if (isColliding2 && SingleKeyPress(Keys.E) && mathRoom.Lever2.OnOff == true)
                    {
                        mathRoom.Lever2.OnOff = false;
                    }

                    bool isColliding3 = mathRoom.Lever3.CheckCollision(player);
                    if (isColliding3 && SingleKeyPress(Keys.E) && mathRoom.Lever3.OnOff == false)
                    {
                        mathRoom.Lever3.OnOff = true;
                    }

                    else if (isColliding3 && SingleKeyPress(Keys.E) && mathRoom.Lever3.OnOff == true)
                    {
                        mathRoom.Lever3.OnOff = false;
                    }

                    bool isColliding4 = mathRoom.Lever4.CheckCollision(player);
                    if (isColliding1 && SingleKeyPress(Keys.E) && mathRoom.Lever4.OnOff == false)
                    {
                        mathRoom.Lever4.OnOff = true;
                    }


                    else if (isColliding4 && SingleKeyPress(Keys.E) && mathRoom.Lever4.OnOff == true)
                    {
                        mathRoom.Lever4.OnOff = false;
                    }

                    bool isColliding5 = mathRoom.Lever5.CheckCollision(player);
                    if (isColliding5 && SingleKeyPress(Keys.E) && mathRoom.Lever5.OnOff == false)
                    {
                        mathRoom.Lever5.OnOff = true;
                    }

                    else if (isColliding5 && SingleKeyPress(Keys.E) && mathRoom.Lever5.OnOff == true)
                    {
                        mathRoom.Lever5.OnOff = false;
                    }

                    bool isColliding6 = mathRoom.Lever6.CheckCollision(player);
                    if (isColliding6 && SingleKeyPress(Keys.E) && mathRoom.Lever6.OnOff == false)
                    {
                        mathRoom.Lever6.OnOff = true;
                    }

                    else if (isColliding6 && SingleKeyPress(Keys.E) && mathRoom.Lever6.OnOff == true)
                    {
                        mathRoom.Lever6.OnOff = false;
                    }

                    bool isColliding7 = mathRoom.Lever7.CheckCollision(player);
                    if (isColliding7 && SingleKeyPress(Keys.E) && mathRoom.Lever7.OnOff == false)
                    {
                        mathRoom.Lever7.OnOff = true;
                        wall7.Width = 0;
                        wall7.Height = 0;
                    }


                    else if (isColliding7 && SingleKeyPress(Keys.E) && mathRoom.Lever7.OnOff == true)
                    {
                        mathRoom.Lever1.OnOff = false;
                    }

                    bool isColliding8 = mathRoom.Lever8.CheckCollision(player);
                    if (isColliding8 && SingleKeyPress(Keys.E) && mathRoom.Lever8.OnOff == false)
                    {
                        mathRoom.Lever8.OnOff = true;
                    }

                    else if (isColliding8 && SingleKeyPress(Keys.E) && mathRoom.Lever8.OnOff == true)
                    {
                        mathRoom.Lever8.OnOff = false;
                    }

                    bool isColliding9 = mathRoom.Lever9.CheckCollision(player);
                    if (isColliding9 && SingleKeyPress(Keys.E) && mathRoom.Lever9.OnOff == false)
                    {
                        mathRoom.Lever9.OnOff = true;
                    }

                    else if (isColliding9 && SingleKeyPress(Keys.E) && mathRoom.Lever9.OnOff == true)
                    {
                        mathRoom.Lever9.OnOff = false;
                    }

                    bool isColliding10 = mathRoom.Lever10.CheckCollision(player);
                    if (isColliding10 && SingleKeyPress(Keys.E) && mathRoom.Lever10.OnOff == false)
                    {
                        mathRoom.Complete = true;
                        testDoor2.OpenDoor(true);
                        mathRoom.Lever10.OnOff = true;
                        
                    }

                    else if (isColliding10 && SingleKeyPress(Keys.E) && mathRoom.Lever10.OnOff == true)
                    {
                        mathRoom.Lever10.OnOff = false;
                    }

                    bool isColliding11 = mathRoom.Lever11.CheckCollision(player);
                    if (isColliding11 && SingleKeyPress(Keys.E) && mathRoom.Lever11.OnOff == false)
                    {
                        mathRoom.Lever11.OnOff = true;
                    }

                    else if (isColliding11 && SingleKeyPress(Keys.E) && mathRoom.Lever11.OnOff == true)
                    {
                        mathRoom.Lever11.OnOff = false;
                    }

                    bool isColliding12 = mathRoom.Lever12.CheckCollision(player);
                    if (isColliding12 && SingleKeyPress(Keys.E) && mathRoom.Lever12.OnOff == false)
                    {
                        mathRoom.Lever12.OnOff = true;
                    }

                    else if (isColliding12 && SingleKeyPress(Keys.E) && mathRoom.Lever12.OnOff == true)
                    {
                        mathRoom.Lever12.OnOff = false;
                    }
                    
                    if (exit2.ChangeRoom(player, mathRoom.Complete))
                    {
                        gameState = GameState.GameOver;
                    }




                    testDoor2.Collision(player);
                    wall1.Update(player);
                    wall2.Update(player);
                    wall3.Update(player);
                    wall4.Update(player);
                    wall5.Update(player);
                    wall6.Update(player);
                    wall7.Update(player);

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
            

            // check game state and draw what is needed in each
            if (roomState == RoomEnum.Room1)
            {
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
                    
                    testDoor2.Collision(player);
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

            else if(roomState == RoomEnum.Room2)
            {
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
                    // wall and floor draw code 
                    wall1.Draw(spriteBatch);
                    wall2.Draw(spriteBatch);
                    wall3.Draw(spriteBatch);
                    wall4.Draw(spriteBatch);
                    wall5.Draw(spriteBatch);
                    spriteBatch.Draw(floorTex, new Rectangle(0, 0, 1280, 1024), Color.White);

                    // draw code for lever room
                    spriteBatch.DrawString(font, "on/off: " + leverRoom.Lever1.OnOff, new Vector2(50, 80), Color.Black);
                    spriteBatch.DrawString(font, "on/off: " + leverRoom.Lever2.OnOff, new Vector2(200, 80), Color.Black);

                    leverRoom.Lever1.Draw(spriteBatch);
                    leverRoom.Lever2.Draw(spriteBatch);
                    leverRoom.Lever3.Draw(spriteBatch);
                    leverRoom.Lever4.Draw(spriteBatch);
                    leverRoom.Lever5.Draw(spriteBatch);
                    leverRoom.Lever6.Draw(spriteBatch);



                    spriteBatch.Draw(testDoor2.Texture, testDoor2.Position, Color.White);

                    if (testDoor2.IsOpen == true)
                    {
                        spriteBatch.DrawString(font, "Open", new Vector2(testDoor.X, testDoor.Y), Color.Black);
                    }
                    else if (testDoor2.IsOpen == false)
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

            else if (roomState == RoomEnum.Room3)
            {
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
                    // wall and floor draw code 
                    wall1.Draw(spriteBatch);
                    wall2.Draw(spriteBatch);
                    wall3.Draw(spriteBatch);
                    wall4.Draw(spriteBatch);
                    wall5.Draw(spriteBatch);
                    spriteBatch.Draw(floorTex, new Rectangle(0, 0, 1280, 1024), Color.White);

                    // draw code for lever room
                    spriteBatch.DrawString(font, "on/off: " + redLight.Lever1.OnOff, new Vector2(50, 80), Color.Black);
                    spriteBatch.DrawString(font, "on/off: " + redLight.Lever2.OnOff, new Vector2(200, 80), Color.Black);
                    spriteBatch.DrawString(font, "on/off: " + redLight.Lever3.OnOff, new Vector2(400, 80), Color.Black);

                    redLight.Lever1.Draw(spriteBatch);
                    redLight.Lever2.Draw(spriteBatch);
                    redLight.Lever3.Draw(spriteBatch);
                    redLight.Detection.Draw(spriteBatch);


                    spriteBatch.Draw(testDoor2.Texture, testDoor2.Position, Color.White);

                    if (testDoor2.IsOpen == true)
                    {
                        spriteBatch.DrawString(font, "Open", new Vector2(testDoor.X, testDoor.Y), Color.Black);
                    }
                    else if (testDoor2.IsOpen == false)
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

            else if (roomState == RoomEnum.Room4)
            {
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
                    // wall and floor draw code 
                    wall1.Draw(spriteBatch);
                    wall2.Draw(spriteBatch);
                    wall3.Draw(spriteBatch);
                    wall4.Draw(spriteBatch);
                    wall5.Draw(spriteBatch);
                    wall6.Draw(spriteBatch);
                    wall7.Draw(spriteBatch);
                    spriteBatch.Draw(floorTex, new Rectangle(0, 0, 1280, 1024), Color.White);


                    mathRoom.Lever1.Draw(spriteBatch);
                    mathRoom.Lever2.Draw(spriteBatch);
                    mathRoom.Lever3.Draw(spriteBatch);
                    mathRoom.Lever4.Draw(spriteBatch);
                    mathRoom.Lever5.Draw(spriteBatch);
                    mathRoom.Lever6.Draw(spriteBatch);
                    mathRoom.Lever7.Draw(spriteBatch);
                    mathRoom.Lever8.Draw(spriteBatch);
                    mathRoom.Lever9.Draw(spriteBatch);
                    mathRoom.Lever10.Draw(spriteBatch);
                    mathRoom.Lever11.Draw(spriteBatch);
                    mathRoom.Lever12.Draw(spriteBatch);




                    spriteBatch.Draw(testDoor2.Texture, testDoor2.Position, Color.White);

                    if (testDoor2.IsOpen == true)
                    {
                        spriteBatch.DrawString(font, "Open", new Vector2(testDoor.X, testDoor.Y), Color.Black);
                    }
                    else if (testDoor2.IsOpen == false)
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
            cursor.Draw(spriteBatch);

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
        public bool SingleKeyPress(Keys key)
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

        //Reads in the file from the tool and prints it to the console.
        public void ReadFile()
        {
            StreamReader input;
            try
            {
                string[] debug = Directory.GetFiles("*pz07_*");

                input = new StreamReader(debug[0]);

                string line = " ";
                while((line = input.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                input.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            } 
        }
    }
}
