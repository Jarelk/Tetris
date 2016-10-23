using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

class Sidebar
{
    Texture2D sprite, scoreboard, nextBlock, level;
    float position;
    float velocity;

    public Sidebar(Texture2D sprite, Texture2D scoreboard, Texture2D nextBlock, Texture2D level)
    {
        this.sprite = sprite;
        this.scoreboard = scoreboard;
        this.nextBlock = nextBlock;
        this.level = level;
        position = 0;
        velocity = 0;
    }

    public void Update(GameTime gameTime)
    {
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        velocity = 1.2f * (Tetris.SetScore / 3 - position);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        Rectangle rect = new Rectangle(MathHelper.Clamp((int)position, 0, 3960), 0, 360, 600);
        spriteBatch.Draw(sprite, new Vector2(360, 0), rect, Color.White);
        spriteBatch.Draw(scoreboard, new Vector2(398, 55), Color.White);
        spriteBatch.Draw(level, new Vector2(400, 100), Color.White);
        spriteBatch.Draw(nextBlock, new Vector2(400, 325), Color.White);
    }
}