using Encog.Neural.Networks;
using KinectProject.Source.Graphics;
using KinectProject.Source.Kinect;
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

        //Updates kinect sensor
        //private KinectHandler kinect = new KinectHandler();

        public GameController()
        {
        }
        
        public void update()
        {
            //Updates the body drawing with where the bodies currently are
            //body.update(kinect.jointPoints);

        }

        public void draw(Render render)
        {
            //Draws the bodies
            body.renderDebug(render);

        }

    }
}
