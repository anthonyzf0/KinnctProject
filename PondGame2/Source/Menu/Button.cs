using KinectProject.Source.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source.Menu
{
    class Button
    {
        public String img;
        public Rectangle pos;
        public bool down = false;

        public Button(int x, int y, int w, int h, String img)
        {
            this.img = img;
            pos = new Rectangle(x, y, w, h);
        }

        public void update()
        {
            MouseState mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed && pos.Contains(mouse.Position) && !down)
                down = true;

            else if (down)
                down = false;
        }

        public void draw(Render render)
        {
            render.drawBackground(pos, img);
            render.show(pos.X + 50, pos.Y - 15, img);
        }
    }
}
