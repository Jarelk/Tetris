using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class Tetris : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Grid grid;
    InputHelper handleInput;


    [STAThread]
    static void Main(string[] args)
    {
        Tetris game = new Tetris();
        game.Run();
    }

    public Tetris()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        handleInput = new InputHelper();
        grid = new Grid();
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

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
        // TODO: Add your update logic 
            grid.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();
        grid.Draw(gameTime);
        spriteBatch.End();
            // TODO: Add your drawing code here

        base.Draw(gameTime);
        }
    }
