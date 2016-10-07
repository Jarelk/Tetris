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
    protected bool[,] grid;
    Texture2D gridBlock;
    public Grid(ContentManager content)
        {
        gridBlock = content.Load<Texture2D>("block");
        grid = new bool[12, 20];
        }

    public void Update(GameTime gameTime)
        {

        }

    public void Draw(GameTime gameTime)
        {

        }
}