using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source.Graphics
{
    class Render
    {
        //Base texture
        Texture2D rect;
        SpriteBatch spriteBatch;
        SpriteFont font;

        public Render(SpriteBatch graphics, GraphicsDevice g, Microsoft.Xna.Framework.Content.ContentManager content)
        {
            rect = new Texture2D(g, 1, 1);
            rect.SetData(new Color[] { Color.White });

            spriteBatch = graphics;
            font = content.Load<SpriteFont>("font");
        }
        
        //Sets up render
        public void start()
        {
            spriteBatch.Begin();
        }
        public void end()
        {
            spriteBatch.End();
        }

        //render stuff
        public void draw(int x, int y, int w, int h, Color c)
        {
            spriteBatch.Draw(rect, new Rectangle(x, y, w, h), c);
        }

        public void drawBox(Vector2 v, Color c)
        {
            draw((int)v.X - 10, (int)v.Y - 10, 20, 20,c);
        }

        public void show(int x, int y, String text)
        {
            spriteBatch.DrawString(font, text, new Vector2(x, y), Color.White);
        }
        
    }

}
