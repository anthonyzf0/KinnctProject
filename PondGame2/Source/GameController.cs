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

        //SideBar
        private SideBar sidebar = new SideBar();

        //Background
        public static string sceneUsed = "woah";
        private Rectangle scene = new Rectangle(0, 0, 1000, 800);

        //Updates kinect sensor
        //private KinectHandler kinect = new KinectHandler();

        public GameController()
        {

        }
        
        public void update()
        {
            //Updates the body drawing with where the bodies currently are
            //body.update(kinect.jointPoints);

            sidebar.update();

        }

        public void draw(Render render)
        {
            //Draws scene
            render.drawBackground(scene, sceneUsed);

            //Draws the bodies
            body.renderDebug(render);

            //Sidebar
            sidebar.render(render);

        }

    }
}
