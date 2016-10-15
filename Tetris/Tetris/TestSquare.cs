﻿using System;
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
        blockMatrix[1, 1] = 1; blockMatrix[2,1] = 1; blockMatrix[2, 2] = 1; blockMatrix[2, 3] = 1;
        position = new Point(3, 0);
    }

    public override void Reset()
    {
        base.Reset();
        Array.Clear(blockMatrix, 0, 16);
        blockMatrix[1, 1] = 1; blockMatrix[2, 1] = 1; blockMatrix[2, 2] = 1; blockMatrix[2, 3] = 1;
    }
}