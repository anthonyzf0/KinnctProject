using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace KinectProject.Source.Graphics
{
    class Render
    {
        //Base texture
        Texture2D rect;
        SpriteBatch spriteBatch;
        SpriteFont font;

        //Render vectors
        private Vector2 horizontal = new Vector2(1, 0);

        public Render(SpriteBatch graphics, GraphicsDevice g, Microsoft.Xna.Framework.Content.ContentManager content)
        {
            rect = new Texture2D(g, 1, 1);
            rect.SetData(new Color[] { Color.White });

            spriteBatch = graphics;
            font = content.Load<SpriteFont>("font");

            SpriteLoader.content = content;
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
            draw((int)v.X - 3, (int)v.Y - 3, 6, 6,c);
        }

        public void show(int x, int y, String text)
        {
            spriteBatch.DrawString(font, text, new Vector2(x, y), Color.White);
        }
        
        public void drawPart(float angle, float distance, Texture2D texture, Vector2 pos)
        {
            double yVal = texture.Height/3;
            spriteBatch.Draw(texture, new Rectangle((int)pos.X, (int)(pos.Y), (int)distance, (int)yVal), null, Color.White, (float)angle, new Vector2(0,texture.Height/2), SpriteEffects.None, 0);
        }

    }

}
