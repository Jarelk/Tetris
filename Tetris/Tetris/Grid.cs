using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


class Grid
{
    protected static int[,] grid;
    Texture2D blocks;
    Vector2 position;
    int spriteDraw;

    public Grid(Texture2D blocks)
        {
        this.blocks = blocks;
        grid = new int[16, 24];
        position = Vector2.Zero;

        for (int x = 0; x < 2; x++)
            for (int y = 0; y < 24; y++)
                grid[x, y] = 9;

        for (int x = 14; x < 16; x++)
            for (int y = 0; y < 24; y++)
                grid[x, y] = 9;

        for (int x = 0; x < 16; x++)
            for (int y = 22; y < 24; y++)
                grid[x, y] = 9;
        }

    public void Update(GameTime gameTime)
        {

        }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        for (int i = 0; i < 12; i++)
            for (int j = 0; j < 20; j++)
            {
                if (grid[i + 2, j + 2] < 8)
                {
                    Rectangle rectangle = new Rectangle(grid[i+2, j+2] * 30, 0, 30, 30);
                    spriteBatch.Draw(blocks, new Vector2(30 * i, 30 * j), rectangle, Color.White);
                }
            }
        }

    public static void SetBlock(Block block)
    {
        int rowCount = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(block.getMatrix[i,j] != 0)grid[block.position.X + 2 + i, block.position.Y + 2 + j] = block.getMatrix[i, j];
            }
        }
        for(int i = 2; i < 22; i++)
        {
            bool isFilled = true;
            for (int k = 2; k < 14; k++)
            {
                if (grid[k, i] == 0) isFilled = false;
            }
            if (isFilled)
            {
                RemoveRow(i);
                rowCount++;
            }
        }
        if(rowCount > 0) Tetris.SetScore = 100 * (int)Math.Pow(2, rowCount-1) * Tetris.SetLevel;
        Tetris.SetScore = 20 * Tetris.SetLevel;
    }

    public static void RemoveRow(int a)
    {
        for(int i = a; i > 1; i--)
        {
            for (int j = 2; j < 14; j++)
            {
                grid[j, i] = grid[j, i - 1];
            }
        }
    }

    public int[,] getGrid
        {
        get { return grid; }
        }
}