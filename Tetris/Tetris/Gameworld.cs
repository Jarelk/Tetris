using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using System;
using System.Timers;

class GameWorld
{
    public enum GameState
    {
        Playing, Menu, GameOver
    }
    Random random;
    Song song;
    SpriteFont font;
    Vector2 middle;
    Texture2D blocks, background, scoreboard, nextBlock, level, mainMenu, gameOver;
    public static GameState gameState;
    static Grid grid;
    Block block;
    Sidebar sidebar;
    Menu menu;

    public GameWorld(ContentManager Content, GraphicsDeviceManager graphics)
    {
        random = new Random();
        gameState = GameState.Menu;
        middle = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        MediaPlayer.IsRepeating = true;
        mainMenu = Content.Load<Texture2D>("Menu");
        song = Content.Load<Song>("JazzTetris");
        font = Content.Load<SpriteFont>("Score");
        blocks = Content.Load<Texture2D>("AllBlocks");
        background = Content.Load<Texture2D>("BackgroundPanorama");
        scoreboard = Content.Load<Texture2D>("Scoreboard");
        nextBlock = Content.Load<Texture2D>("NextBlock");
        level = Content.Load<Texture2D>("Level");
        gameOver = Content.Load<Texture2D>("GameOver");
        grid = new Grid(blocks);
        block = new Block(blocks);
        menu = new Menu(mainMenu);
        sidebar = new Sidebar(background, scoreboard, nextBlock, level);
    }

    public void Reset()
    {
        Tetris.SetLevel = 1;
        Tetris.SetScore = 0;
        grid.Reset();
        block.Reset(grid);
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        if (gameState == GameState.Menu) { if (inputHelper.KeyPressed(Keys.Enter)) { gameState = GameState.Playing; MediaPlayer.Play(song); } }
        if (gameState == GameState.GameOver) { if (inputHelper.KeyPressed(Keys.Enter)) { Reset(); gameState = GameState.Playing; } }
        if (gameState == GameState.Playing)
        {
            block.HandleInput(inputHelper, grid);
            if (inputHelper.KeyPressed(Keys.Escape)) { Reset(); gameState = GameState.Menu; MediaPlayer.Stop(); } 
        }
    }

    public void Update(GameTime gameTime)
    {
        if(gameState == GameState.Playing){
            block.Update(gameTime, grid);
            sidebar.Update(gameTime);
        }
    }

    public void Metronome()
    {
        if(gameState == GameState.Playing)block.Metronome(grid);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        if (gameState == GameState.Menu) menu.Draw(gameTime, spriteBatch);
        if(gameState == GameState.Playing || gameState == GameState.GameOver){
            sidebar.Draw(gameTime, spriteBatch);
            grid.Draw(gameTime, spriteBatch);
            block.Draw(gameTime, spriteBatch, grid);
        }
        if (gameState == GameState.GameOver) spriteBatch.Draw(gameOver, new Vector2(middle.X - (gameOver.Width/2), middle.Y - (gameOver.Height/2)), Color.White);
        spriteBatch.End();
    }

    // Hier wordt tekst getekend, aangeroepen door Tetris.cs
    public void DrawText(int text, Vector2 positie, SpriteBatch spriteBatch)
    {
        if (gameState != GameState.Menu)
        {
            string stringText = text.ToString();
            spriteBatch.Begin();
            spriteBatch.DrawString(font, stringText, positie, Color.Black, 0f, font.MeasureString(stringText), 1, 0, 0);
            spriteBatch.End();
        }
    }

    public static GameState GameOver
    {
        set { gameState = GameState.GameOver; }
        get { return gameState; }
    }
    public Random Random
    {
        get { return random; }
    }

}