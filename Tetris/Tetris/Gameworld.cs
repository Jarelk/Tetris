using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using System.Timers;

/*
 * A class for representing the game world.
 */
class GameWorld
{
    /*
     * enum for different game states (playing or game over)
     */
    enum GameState
    {
        Playing, GameOver
    }
    Random random;
    SpriteFont font;
    Texture2D blocks;
    GameState gameState;
    static Grid grid;
    Block block;

    public GameWorld(ContentManager Content)
    {
        random = new Random();
        gameState = GameState.Playing;

        font = Content.Load<SpriteFont>("Score");
        blocks = Content.Load<Texture2D>("AllBlocks");
        grid = new Grid(blocks);
        block = new Block(blocks);
    }

    public void Reset()
    {
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        block.HandleInput(inputHelper, grid);
    }

    public void Update(GameTime gameTime)
    {
        block.Update(gameTime);
    }

    public void Metronome()
    {
        block.Metronome(grid);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        block.Draw(gameTime, spriteBatch, grid);
        spriteBatch.End();
    }

    /*
     * utility method for drawing text on the screen
     */
    public void DrawText(int text, Vector2 positie, SpriteBatch spriteBatch)
    {
        string stringText = text.ToString();
        spriteBatch.Begin();
        spriteBatch.DrawString(font, stringText, positie, Color.Black);
        spriteBatch.End();
    }
    public Random Random
    {
        get { return random; }
    }
}