using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace KinectProject.Source.Graphics
{
    class Render
    {
        //Base texture
        Texture2D rect;
        SpriteBatch spriteBatch;
        SpriteFont font;

        //Loaded Textures
        private SpriteLoader sprites;

        public Render(SpriteBatch graphics, GraphicsDevice g, Microsoft.Xna.Framework.Content.ContentManager content)
        {
            rect = new Texture2D(g, 1, 1);
            rect.SetData(new Color[] { Color.White });

            spriteBatch = graphics;
            font = content.Load<SpriteFont>("font");

            sprites = new SpriteLoader(content);

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


        public void drawBodyPart(Vector2 a, Vector2 b, String body, SpriteLoader.Part bodyPart, bool rotate, bool points = false)
        {

            //rotation between points
            double rotation = Math.Atan(((double)(b.Y - a.Y)) / ((double)(b.X - a.X)));
            if (b.X < a.X) rotation += Math.PI;

            if (rotate)
                rotation -= Math.PI / 2;

            Texture2D text = sprites.getTexture(body, bodyPart);

            int x = text.Width;
            int y = text.Height;

            float distance = Vector2.Distance(a, b);

            Vector2 rot = new Vector2((rotate) ? x / 2 : 0, (rotate) ? 0 : y / 2);
            
            spriteBatch.Draw(text, a, null, Color.White, (float)rotation, rot, distance / x, SpriteEffects.None, 0);
           
            if (points)
            {
                drawBox(a, Color.White);
                drawBox(b, Color.White);
            }
        }

        public void drawBackground(Rectangle rect, String name)
        {
            Texture2D text = sprites.getBackground(name);
            spriteBatch.Draw(text, rect, Color.White);

        }
    }

}
