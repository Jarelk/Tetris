﻿using System;
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
    Texture2D gridBlock, redBlock;
    Vector2 position;
    public Grid(Texture2D block, Texture2D redBlock)
        {
        gridBlock = block;
        this.redBlock = redBlock;
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
                if(grid[i+2,j+2] == 0)
                spriteBatch.Draw(gridBlock, new Vector2(30 * i, 30 * j), Color.White);
                else if(grid[i+2,j+2] == 1)
                spriteBatch.Draw(redBlock, new Vector2(30 * i, 30 * j), Color.White);
            }
        }

    public static void SetBlock(Block block)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(block.getMatrix[i,j] == 1)grid[block.position.X + 2 + i, block.position.Y + 2 + j] = block.getMatrix[i, j];
            }
        }
    }

    public int[,] getGrid
        {
        get { return grid; }
        }
}