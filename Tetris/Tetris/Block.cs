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

    public Block()
    {
        position = new Vector2(4,0);
        potentialPosition = position;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; i++)
                blockMatrix[i,j] = 0;
        }
    }

    public void HandleInput(InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Left))
        {
            potentialPosition.X--;
        }
        if (inputHelper.KeyPressed(Keys.Right))
        {
            potentialPosition.X++;
        }
    }
    public void Update(GameTime gameTime)
    {

    }

    public void Draw(GameTime gameTime)
    {

    }

    public void Die()
    {
        Reset();
    }

    public void Reset()
    {
    }
}