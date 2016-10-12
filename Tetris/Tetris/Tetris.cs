using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Timers;

public class Tetris : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    InputHelper handleInput;
    GameWorld gameworld;
    Timer tetrisTimer;

    [STAThread]
    static void Main(string[] args)
    {
        System.Timers.Timer tetrisTimer = new System.Timers.Timer();
        tetrisTimer.Interval = 1000;
        tetrisTimer.Elapsed += new ElapsedEventHandler(timerPass);
        tetrisTimer.Enabled = true;
        Tetris game = new Tetris();
        game.Run();
    }

    public static void timerPass(object source, ElapsedEventArgs e)
    {
        
    }

    public Tetris()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        handleInput = new InputHelper();
    }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameworld = new GameWorld(720, 600, Content);

        // TODO: use this.Content to load your game content here
    }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
        // TODO: Add your update logic 
        handleInput.Update(gameTime);
            //grid.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        gameworld.Draw(gameTime, spriteBatch);
            // TODO: Add your drawing code here

        base.Draw(gameTime);
        }
    }
