using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TestSquare : Block
{
    public TestSquare(Texture2D sprite) : base(sprite)
    {
        this.sprite = sprite;
        blockMatrix[1, 0] = 1; blockMatrix[2,0] = 1; blockMatrix[2, 1] = 1; blockMatrix[2, 2] = 1;
        position = new Vector2(3, 5);
    }
}