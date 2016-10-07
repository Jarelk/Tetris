using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TestSquare : Block
{
    public TestSquare(Texture2D sprite) : base()
    {
        this.sprite = sprite;
        blockMatrix[0, 1] = 1; blockMatrix[1,1] = 1; blockMatrix[0, 2] = 1; blockMatrix[1, 2] = 1;
    }
}