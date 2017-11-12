using Encog.Neural.Networks;
using KinectProject.Source.BodyHandler;
using KinectProject.Source.Graphics;
using KinectProject.Source.Kinect;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        private KinectHandler kinect;
        private KinectData data;
        
        //Loads a body
        private CharacterPart body = BodyLoader.loadBody("test");

        public GameController()
        {
            //kinect = new KinectHandler();
            data = new KinectData();
            
        }
        
        public void update()
        {
            //Updates angle data with the kinect object
            //data.readData(kinect);

            //Updates the body drawing with where the bodies currently are
            
        }

        public void draw(Render render)
        {
            body.draw(render, new Vector2(500,500), 1, data);

        }

    }
}
