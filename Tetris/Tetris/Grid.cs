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
    Vector2 position;
    public Grid(ContentManager content)
        {
        gridBlock = content.Load<Texture2D>("block");
        grid = new bool[12, 20];
        position = Vector2.Zero;
        }

    public void Update(GameTime gameTime)
        {

        }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        for (int i = 0; i < 12; i++)
            for (int j = 0; j < 20; j++)
                spriteBatch.Draw(gridBlock, new Vector2(30*i, 30*j) , Color.White);
        }
}