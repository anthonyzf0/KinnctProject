using Microsoft.Kinect;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source.Graphics
{
    class BodyMapper
    {
        public BodyMapper()
        {


        }

        public void update(Body[] bodies)
        {
            if (bodies.Length < 1) return;
            Body playerBody = bodies[0];



        }

        public void draw(Render render)
        {
            MouseState state = Mouse.GetState();

            render.drawBodyPart(new Vector2(300, 300), new Vector2(state.X, state.Y), "test", SpriteLoader.Part.head);

        }
        

    }
}
