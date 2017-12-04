using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace KinectProject.Source.Graphics
{
    class Render
    {
        public enum TexturePoint
        {
            mid, left, right, top, bottom
        }

        //Base texture
        SpriteBatch spriteBatch;
        SpriteFont font;
        Texture2D rect;

        //Render vectors
        private Vector2 horizontal = new Vector2(1, 0);

        public Render(SpriteBatch graphics, GraphicsDevice g, Microsoft.Xna.Framework.Content.ContentManager content)
        {
            spriteBatch = graphics;
            font = content.Load<SpriteFont>("font");
            SpriteLoader.content = content;

            rect = new Texture2D(graphics.GraphicsDevice, 1, 1);
            rect.SetData(new Color[1] {Color.White});
        }
        
        //Sets up render
        public void start()
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, null);
        }
        public void end()
        {
            spriteBatch.End();
        }

        //rotation type
        private Vector2 getPos(TexturePoint t)
        {
            if (t == TexturePoint.mid) return new Vector2(0.5f,0.5f);
            if (t == TexturePoint.left) return new Vector2(0f, 0.5f);
            if (t == TexturePoint.right) return new Vector2(1f, 0.5f);
            if (t == TexturePoint.top) return new Vector2(0.5f, 0f);
            if (t == TexturePoint.bottom) return new Vector2(0.5f, 1f);
            return Vector2.Zero;

        }

        //render stuff
        public void drawPart(Vector2 point, Vector2 size, Double angle, Texture2D t, double l, TexturePoint rotationType, Vector2 shift)
        {
            //Gets where to rotate
            Vector2 pos = getPos(rotationType);
            Vector2 rotationPos = (new Vector2(t.Width, t.Height) * pos) + shift;
            Rectangle rectangle = new Rectangle((int)point.X,(int)point.Y,(int)size.X, (int)size.Y);
            
            spriteBatch.Draw(t, rectangle,null, Color.White, (float)angle, rotationPos, SpriteEffects.None, (float)l);
        }
        public void show(int x, int y, String text)
        {
            spriteBatch.DrawString(font, text, new Vector2(x, y), Color.White);
        }
        public void drawBox(Vector2 v, Color c)
        {
            draw((int)v.X - 3, (int)v.Y - 3, 6, 6, c);
            show((int)v.X, (int)v.Y, (int)v.X + " " + (int)v.Y);
        }
        public void draw(int x, int y, int w, int h, Color c)
        {
            spriteBatch.Draw(rect, new Rectangle(x,y,w,h),null, c, 0, Vector2.Zero, SpriteEffects.None, 0f);
        }

        public void background (Texture2D back)
        {
            spriteBatch.Draw(back, new Rectangle(0, 0, 600, 600),null,Color.White,0,Vector2.Zero,SpriteEffects.None,0.999f);
        }
        
    }

}
