using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinectProject.Source.Graphics;
using Microsoft.Xna.Framework;

namespace KinectProject.Source.Menu.Tabs
{
    class Character : Tab
    {

        private List<Button> buttons = new List<Button>();

        public Character()
        {
            String[] names = SpriteLoader.characterNames;

            for (int i = 0; i < names.Length; i++)
                buttons.Add(new Button(1100, i * 175 + 50, 200, 100, names[i]));

            base.initialize("Characters");
        }
        
        public override void update()
        {

            foreach (Button b in buttons)
            {
                b.update();

                if (b.down)
                    BodyMapper.currentCharacter = b.img;
            }

        }

        public override void render(Render render)
        {
            //Background
            render.draw(1000, 30, 600, 800, Color.DarkGray);

            foreach (Button b in buttons)
                b.draw(render);
        }
    }
}
