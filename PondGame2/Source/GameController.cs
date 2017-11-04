using Encog.Neural.Networks;
using KinectProject.Source.Graphics;
using KinectProject.Source.Kinect;
using KinectProject.Source.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source
{
    class GameController
    {
        //Handles body drawing / maping
        private BodyMapper body = new BodyMapper();

        //Tabs
        private List<Tab> Menu = new List<Tab>();
        private int selectedTab = 0;
        private int startX = 1000;

        //Background
        public static string sceneUsed = "woah";
        private Rectangle scene = new Rectangle(0, 0, 1000, 800);

        //Updates kinect sensor
        //private KinectHandler kinect = new KinectHandler();

        public GameController()
        {

            Menu.Add(new Menu.Tabs.Background());
        }
        
        public void update()
        {
            //Updates the body drawing with where the bodies currently are
            //body.update(kinect.jointPoints);

            Menu[selectedTab].update();

        }

        public void draw(Render render)
        {
            //Draws scene
            render.drawBackground(scene, sceneUsed);

            //Draws the bodies
            body.renderDebug(render);

            for(int i = 0; i < Menu.Count; i++)
            {
                render.draw(startX, 0, 100, 30, Color.Black);
                render.show(startX+5, 7, Menu[i].name);
            }

            Menu[selectedTab].render(render);

        }

    }
}
