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

    [STAThread]
    static void Main(string[] args)
    {
        Tetris game = new Tetris();
        game.Run();
    }

    protected void timerPass(object source, ElapsedEventArgs e)
    {
        gameworld.Metronome();
    }

    public Tetris()
    {
        graphics = new GraphicsDeviceManager(this);
        graphics.PreferredBackBufferWidth = 720;
        graphics.PreferredBackBufferHeight = 600;
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
            gameworld = new GameWorld(Content);
        System.Timers.Timer tetrisTimer = new System.Timers.Timer();
        tetrisTimer.Interval = 1000;
        tetrisTimer.Elapsed += new ElapsedEventHandler(timerPass);
        tetrisTimer.Enabled = true;

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
        gameworld.Update(gameTime);
        gameworld.HandleInput(gameTime, handleInput);
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
