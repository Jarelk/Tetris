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
    public static int score;
    public static int level;

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
        level = 1;
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
            gameworld = new GameWorld(Content, graphics);
        tetrisTimer = new System.Timers.Timer();
        tetrisTimer.Interval = 2000;
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
        int levelCounter;
        // TODO: Add your update logic 
        handleInput.Update(gameTime);
        gameworld.HandleInput(gameTime, handleInput);
        gameworld.Update(gameTime);
        levelCounter =+ SetScore - 1000 * (SetLevel - 1);
        if(levelCounter >= SetLevel * 1000)
        {
            levelCounter = 0;
            SetLevel++;
            SetTimer = MathHelper.Clamp(2000 - (SetLevel - 1) * 200, 200, 2000);
        }
            //grid.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
        GraphicsDevice.Clear(Color.CornflowerBlue);


        gameworld.Draw(gameTime, spriteBatch);
       // TODO: Add your drawing code here
        gameworld.DrawText(score, new Vector2(680, 100), spriteBatch);
        gameworld.DrawText(SetLevel, new Vector2(565, 148), spriteBatch);

        base.Draw(gameTime);
        }


    public static int SetScore
    {
        get { return score;}
        set { score = value; }
    }
        public double SetTimer
    {
        set { tetrisTimer.Interval = value; }
    }

    public static int SetLevel
    {
        get { return level; }
        set { level = value; }
    }

    }
