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
    public Point position;
    public Point potentialPosition;
    protected int[,] blockMatrix;
    protected Keys key;

    public Block(Texture2D sprite)
    {
        sprite = this.sprite;
        position = new Point(4,0);
        potentialPosition = position;
        blockMatrix = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
                blockMatrix[i,j] = 0;
        }
    }

    public void HandleInput(InputHelper inputHelper, Grid grid)
    {
        if (inputHelper.KeyPressed(Keys.Left) && !Collission(blockMatrix, 0, grid))
        {
            position.X--;
        }
        if (inputHelper.KeyPressed(Keys.Right) && !Collission(blockMatrix, 1, grid))
        {
            position.X++;
        }
        if (inputHelper.KeyPressed(Keys.Down) && !Collission(blockMatrix, 2, grid))
        {
            position.Y++;
        }
        if (inputHelper.KeyPressed(Keys.E))
        {
            RotateClockwise(grid);
        }
        if (inputHelper.KeyPressed(Keys.Q))
        {
            RotateCounterClockwise(grid);
        }
    }
    public void Update(GameTime gameTime)
    {

    }

    public void Metronome(Grid grid)
    {
      if(!Collission(blockMatrix, 2, grid)) position.Y++;
    }

    public bool Collission(int[,] matrix, int direction, Grid grid)
    {
        int[,] drawingGrid = grid.getGrid;
        if (direction == 0) //Checking for left movement
        {
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (drawingGrid[position.X + 1 + i, position.Y + 2 + j] != 0 && matrix[i, j] == 1) return true;
                }
            }
            return false;
            
        }
        else if (direction == 1) //Checking for right movement
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (drawingGrid[position.X + 3 + i, position.Y + 2 + j] != 0 && matrix[i, j] == 1) return true;
                }
            }
            return false;
        }
        else if (direction == 2) //Checking for downwards movement
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (drawingGrid[position.X + 2 + i, position.Y + 3 + j] != 0 && matrix[i, j] == 1) return true;
                }
            }
            return false;
        }
        else if (direction == 3) //Checking for rotation collision
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (drawingGrid[position.X + 2 + i, position.Y + 2 + j] != 0 && matrix[i, j] == 1) return true;
                }
            }
            return false;
        }
        else if (direction == 4) // Checking for wall kick
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (drawingGrid[position.X + 2 + i, position.Y + 2 + j] == 9 && matrix[i, j] == 1) return true;
                }
            }
            return false;
        }
        else return true;
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

    public void RotateClockwise(Grid grid)
    {

        int[,] rotateMatrix = new int[4, 4];
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                rotateMatrix[i, j] = blockMatrix[j, 3-i];
            }
        }
        if (!Collission(rotateMatrix, 3, grid)) blockMatrix = rotateMatrix;
        else if (Collission(rotateMatrix, 4, grid))
        {
            if (position.X > 8 && !Collission(rotateMatrix, 0, grid)) { position.X--; blockMatrix = rotateMatrix; }
            else if (position.X < 9 && !Collission(rotateMatrix, 1, grid)) { position.X++; blockMatrix = rotateMatrix; }
        }
        else return;
    }

    public void RotateCounterClockwise(Grid grid)
    {
        int[,] rotateMatrix = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                rotateMatrix[i, j] = blockMatrix[3-j,i];
            }
        }
        if (!Collission(rotateMatrix, 3, grid)) blockMatrix = rotateMatrix;
        else if (Collission(rotateMatrix, 4, grid))
        {
            if (position.X > 8 && !Collission(rotateMatrix, 0, grid)) { position.X--; blockMatrix = rotateMatrix; }
            else if (position.X < 9 && !Collission(rotateMatrix, 1, grid)) { position.X++; blockMatrix = rotateMatrix; }
        }
        else return;
    }

    public void Die()
    {
        Reset();
    }

    public void Reset()
    {
    }
}