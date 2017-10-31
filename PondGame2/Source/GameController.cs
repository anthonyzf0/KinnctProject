using Encog.Neural.Networks;
using KinectProject.Source.Graphics;
using KinectProject.Source.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source
{
    class GameController
    {
        private KinectHandler kinect;

        public GameController()
        {
            kinect = new KinectHandler();
        }
        
        public void update()
        {
        }

        public void draw(Render render)
        {
            kinect.draw(render);
        }

    }
}
