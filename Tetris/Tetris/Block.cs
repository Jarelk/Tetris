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
    Vector2 sprite;
    Vector2 position;
    bool[,] blockMatrix;
    Keys key;

    public Block()
    {
        blockMatrix = new bool[4, 4];
    }

    public void HandleInput(InputHelper inputHelper)
    {

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