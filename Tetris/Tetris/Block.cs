using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Block
{
    protected Texture2D sprite;
    public Vector2 position;
    public Vector2 potentialPosition;
    protected int[,] blockMatrix;
    protected Keys key;
    protected int blockType;

    public Block(Texture2D sprite)
    {
        sprite = this.sprite;
        position = new Vector2(4,0);
        potentialPosition = position;
        blockMatrix = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
                blockMatrix[i,j] = 0;
        }
    }

    public void HandleInput(InputHelper inputHelper)
    {
        int[,] drawingGrid = grid.getGrid;
        if (inputHelper.KeyPressed(Keys.Left) && position.X >= -1)
        {
            position.X--;
        }
        if (inputHelper.KeyPressed(Keys.Right) && position.X < 8)
        {
            position.X++;
        }
        if (inputHelper.KeyPressed(Keys.Down) && position.Y < 16)
        {
            position.Y++;
        }
    }
    public void Update(GameTime gameTime)
    {

    }

    public void Metronome()
    {
      if(position.Y < 16) position.Y++;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Grid grid)
    {
        int[,] drawingGrid = grid.getGrid;
        for (int i = 0; i < 4; i++) { for (int j = 0; j < 4; j++) {
                if (drawingGrid[(int)position.X + i + 2, (int)position.Y + j + 2] == 0 && blockMatrix[i,j] == 1) {
                    spriteBatch.Draw(sprite, new Vector2((position.X + i) * 30, (position.Y + j) * 30), Color.White);
                }
                    }
        }
    }

    public void Die()
    {
        Reset();
    }

    public void Reset()
    {
    }
}