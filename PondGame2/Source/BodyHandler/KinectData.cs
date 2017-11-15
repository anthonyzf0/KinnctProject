using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KinectProject.Source.BodyHandler.CharacterPart;

namespace KinectProject.Source.BodyHandler
{
    class KinectData
    {
        private Dictionary<BodyAngle, float> angles;
        
        public KinectData()
        {
            angles = new Dictionary<BodyAngle, float>();
        }
        public void readData(Kinect.KinectHandler kinect)
        {
            if (kinect.jointPoints == null) return;

            //Clear last data
            angles = new Dictionary<BodyAngle, float>();

            angles.Add(BodyAngle.zero, 0);

            //Arms
            angles.Add(BodyAngle.leftUpperArm,
                getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.ShoulderLeft],
                    kinect.jointPoints[Microsoft.Kinect.JointType.ElbowLeft]
                    ) + (float)Math.PI

            );
            angles.Add(BodyAngle.leftLowwerArm,
                getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.HandLeft],
                    kinect.jointPoints[Microsoft.Kinect.JointType.ElbowLeft]
                    ) 

            );
            angles.Add(BodyAngle.rightUpperArm,
                getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.ElbowRight],
                    kinect.jointPoints[Microsoft.Kinect.JointType.ShoulderRight]
                    ) + (float)Math.PI / 2

            );
            angles.Add(BodyAngle.rightLowwerArm,
                getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.HandRight],
                    kinect.jointPoints[Microsoft.Kinect.JointType.ElbowRight]
                    ) + (float)Math.PI

            );
            angles.Add(BodyAngle.head,
                getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.Head],
                    kinect.jointPoints[Microsoft.Kinect.JointType.Neck]
                    )
            );
            angles.Add(BodyAngle.body,
                getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.SpineShoulder],
                    kinect.jointPoints[Microsoft.Kinect.JointType.SpineBase]
                    ) + (float)Math.PI / 2
            );


        }

        public float getAngle(Point a, Point b)
        {
            double angle = Math.Atan(((double)b.Y - a.Y) / ((double)b.X - a.X));
            if (b.X < a.X)
                angle += Math.PI;

            return (float)angle;
        }

        public float getAngle(BodyAngle angle)
        {
            return angles.ContainsKey(angle) ? angles[angle] : 0;
        }
        
    }
}
