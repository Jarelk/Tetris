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
    Texture2D gridblock, redblock;
    GameState gameState;
    static Grid grid;
    Block block;

    public GameWorld(ContentManager Content)
    {
        random = new Random();
        gameState = GameState.Playing;

        gridblock = Content.Load<Texture2D>("block");
        redblock = Content.Load<Texture2D>("RedBlock");
        grid = new Grid(gridblock, redblock);
        block = new TestSquare(redblock);
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
    public void DrawText(string text, Vector2 positie, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, text, positie, Color.Blue);
    }
    public Random Random
    {
        get { return random; }
    }
}