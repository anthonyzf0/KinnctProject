using KinectProject.Source.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source.Menu
{
    class SideBar
    {
        private List<Tab> Menu = new List<Tab>();
        private List<Button> tabButtons = new List<Button>();
        
        private int selectedTab = 0;
        private int startX = 1000;

        public SideBar()
        {
            Menu.Add(new Tabs.Background());
            tabButtons.Add(new Button(1000, 0, 100, 30));

            Menu.Add(new Tabs.Character());
            tabButtons.Add(new Button(1100, 0, 100, 30));
        }

        public void update()
        {
            //Check if you swapped tabs
            for (int i = 0; i < tabButtons.Count; i++)
            {
                tabButtons[i].update();
                if (tabButtons[i].down)
                    selectedTab = i;
            }

            //Update selected tab
            Menu[selectedTab].update();
        }

        public void render(Render render)
        {

            for (int i = 0; i < Menu.Count; i++)
            {
                render.draw(startX + i*100, 0, 100, 30, Color.Black);
                render.show(startX + 5 + i*100, 7, Menu[i].name);
            }

            Menu[selectedTab].render(render);

        }
    }
}
