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
        private Dictionary<JointType, Point> jointPoints;

        public BodyMapper()
        {


        }

        public void update(Dictionary<JointType, Point> jointPoints)
        {
            this.jointPoints = jointPoints;

        }

        public void draw(Render render)
        {
            if (jointPoints == null) return;


            //Arms
            render.drawBodyPart(jointPoints[JointType.ElbowLeft].ToVector2(),
                                jointPoints[JointType.HandLeft].ToVector2(),
                                "test", SpriteLoader.Part.upperArm);

            render.drawBodyPart(jointPoints[JointType.ElbowLeft].ToVector2(),
                                jointPoints[JointType.ShoulderLeft].ToVector2(),
                                "test", SpriteLoader.Part.upperArm);

            render.drawBodyPart(jointPoints[JointType.ElbowRight].ToVector2(),
                                jointPoints[JointType.HandRight].ToVector2(),
                                "test", SpriteLoader.Part.upperArm);

            render.drawBodyPart(jointPoints[JointType.ElbowRight].ToVector2(),
                                jointPoints[JointType.ShoulderRight].ToVector2(),
                                "test", SpriteLoader.Part.upperArm);


            render.drawBodyPart(jointPoints[JointType.Head].ToVector2(),
                                jointPoints[JointType.SpineShoulder].ToVector2(),
                                "test", SpriteLoader.Part.head);


            render.drawBodyPart(jointPoints[JointType.HandLeft].ToVector2(),
                                jointPoints[JointType.HandTipLeft].ToVector2(),
                                "test", SpriteLoader.Part.hand);

            render.drawBodyPart(jointPoints[JointType.HandRight].ToVector2(),
                                jointPoints[JointType.HandTipRight].ToVector2(),
                                "test", SpriteLoader.Part.hand);

            render.drawBodyPart(jointPoints[JointType.SpineShoulder].ToVector2(),
                                jointPoints[JointType.SpineBase].ToVector2(),
                                "test", SpriteLoader.Part.body);
        }
        

    }
}
