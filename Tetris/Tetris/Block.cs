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
    protected int[,] blockMatrix;
    protected bool colliding = false;
    protected int[] randomBlocks;
    static Random random;
    protected int cur;

    public Block(Texture2D sprite)
    {
        random = new Random();
        this.sprite = sprite;
        randomBlocks = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        Randomize(randomBlocks);
        cur = 0;
        blockMatrix = new int[4, 4];
        blockMatrix = SetMatrix(cur);
        position = new Point(3, 0);
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
        if (!Collission(blockMatrix, 2, grid)) position.Y++;
    }

    public bool Collission(int[,] matrix, int direction, Grid grid)
    {
        int[,] drawingGrid = grid.getGrid;
        if (direction == 0) //Checking for left movement
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {   
                    if (position.X + 1 + i >= 0 && drawingGrid[position.X + 1 + i, position.Y + 2 + j] != 0 && matrix[i, j] != 0) return true;
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
                    if (drawingGrid[position.X + 3 + i, position.Y + 2 + j] != 0 && matrix[i, j] != 0) return true;
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
                    if (drawingGrid[position.X + 2 + i, position.Y + 3 + j] != 0 && matrix[i, j] != 0) { Grid.SetBlock(this); Reset(); return true; }
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
                    if (drawingGrid[position.X + 2 + i, position.Y + 2 + j] != 0 && matrix[i, j] != 0) return true;
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
                    if (drawingGrid[position.X + 2 + i, position.Y + 2 + j] == 9 && matrix[i, j] != 0) return true;
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
                if (drawingGrid[(int)position.X + i + 2, (int)position.Y + j + 2] == 0 && blockMatrix[i, j] != 0) {
                    Rectangle rectangle = new Rectangle(30 * blockMatrix[i,j], 0, 30, 30);
                    spriteBatch.Draw(sprite, new Vector2((position.X + i) * 30, (position.Y + j) * 30), rectangle, Color.White);
                }
            }
        }
        int[,] NextBlock = new int[4, 4];
        Array.Clear(NextBlock, 0, 16);
        NextBlock = SetMatrix(cur + 1);
        for (int k = 0; k < 4; k++)
        {
            for (int l = 0; l < 4; l++)
            {
               if(NextBlock[k,l] != 0) {
                    Rectangle rectangle = new Rectangle(30 * NextBlock[k, l], 0, 30, 30);
                    spriteBatch.Draw(sprite, new Vector2(400 + 30 * k, 50 + 30 * l), rectangle, Color.White);
                }
            }
        }

    }

    public void RotateClockwise(Grid grid)
    {

        int[,] rotateMatrix = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                rotateMatrix[i, j] = blockMatrix[j, 3 - i];
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
                rotateMatrix[i, j] = blockMatrix[3 - j, i];
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

    public void Randomize(int[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int i = random.Next(n--);
            int local = array[n];
            array[n] = array[i];
            array[i] = local;
        }
    }

    public int[,] SetMatrix(int i)
    {
        int[,] matrix = new int[4, 4];
        Array.Clear(matrix, 0, 16);
        if (randomBlocks[i] == 1) //T
        {
            matrix[2, 1] = 1; matrix[1, 2] = 1; matrix[2, 2] = 1; matrix[3, 2] = 1;
        }
        else if (randomBlocks[i] == 2) //I
        {
            matrix[1, 0] = 2; matrix[1, 1] = 2; matrix[1, 2] = 2; matrix[1, 3] = 2;
        }
        else if (randomBlocks[i] == 3) //O
        {
            matrix[1, 1] = 3; matrix[2, 1] = 3; matrix[1, 2] = 3; matrix[2, 2] = 3;
        }
        else if (randomBlocks[i] == 4) //S
        {
            matrix[1, 1] = 4; matrix[2, 1] = 4; matrix[0, 2] = 4; matrix[1, 2] = 4;
        }
        else if (randomBlocks[i] == 5) //Z
        {
            matrix[1, 1] = 5; matrix[2, 1] = 5; matrix[2, 2] = 5; matrix[3, 2] = 5;
        }
        else if (randomBlocks[i] == 6) //L
        {
            matrix[1, 1] = 6; matrix[2, 1] = 6; matrix[2, 2] = 6; matrix[2, 3] = 6;
        }
        else if (randomBlocks[i] == 7) //J
        {
            matrix[2, 1] = 7; matrix[1, 1] = 7; matrix[1, 2] = 7; matrix[1, 3] = 7;
        }
        return matrix;
    }

    public int[] getOrder
    {
        get { return randomBlocks; }
    }

    public int[,] getMatrix
    {
        get { return blockMatrix; }
    }

    public virtual void Reset()
    {
        position = new Point(4, 0);
        Array.Clear(blockMatrix, 0, 16);
        cur++;
        blockMatrix = SetMatrix(cur);
        if (cur == 6) { cur = -1; Randomize(randomBlocks); }
    }
}