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
        public Dictionary<BodyAngle, float> angles;
        
        public static  Dictionary<BodyAngle, float> baseAngles = new Dictionary<BodyAngle, float>() {

            {BodyAngle.zero, 0 },
            {BodyAngle.head, 0 },
            {BodyAngle.body, 0 },
            {BodyAngle.leftLowwerArm, 0 },
            {BodyAngle.rightLowwerArm, 0 },
            {BodyAngle.leftUpperArm,  0},
            {BodyAngle.rightUpperArm, 0 },
            {BodyAngle.leftLowwerLeg, 0 },
            {BodyAngle.leftUpperLeg, 0 },
            {BodyAngle.rightLowwerLeg, 0 },
            {BodyAngle.rightUpperLeg, 0 }
        };

        
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

            //Left arm
            angles.Add(BodyAngle.leftUpperArm,
                -getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.ShoulderLeft],
                    kinect.jointPoints[Microsoft.Kinect.JointType.ElbowLeft]
                    )

            );
            angles.Add(BodyAngle.leftLowwerArm,
                -getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.HandLeft],
                    kinect.jointPoints[Microsoft.Kinect.JointType.ElbowLeft]
                    ) 

            );
            //Right arm
            angles.Add(BodyAngle.rightUpperArm,
                getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.ElbowRight],
                    kinect.jointPoints[Microsoft.Kinect.JointType.ShoulderRight]
                    ) + (float)Math.PI

            );
            angles.Add(BodyAngle.rightLowwerArm,
                -getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.HandRight],
                    kinect.jointPoints[Microsoft.Kinect.JointType.ElbowRight]
                    )

            );

            //Body / head
            angles.Add(BodyAngle.head,
                -getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.Head],
                    kinect.jointPoints[Microsoft.Kinect.JointType.Neck]
                    )
            );
            angles.Add(BodyAngle.body,
                getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.SpineShoulder],
                    kinect.jointPoints[Microsoft.Kinect.JointType.SpineBase]
                    )
            );

            //Left leg
            angles.Add(BodyAngle.rightUpperLeg,
                -getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.HipLeft],
                    kinect.jointPoints[Microsoft.Kinect.JointType.KneeLeft]
                    )

            );
            angles.Add(BodyAngle.rightLowwerLeg,
                -getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.KneeLeft],
                    kinect.jointPoints[Microsoft.Kinect.JointType.FootLeft]
                    )

            );
            //Right leg
            angles.Add(BodyAngle.leftUpperLeg,
                -getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.HipRight],
                    kinect.jointPoints[Microsoft.Kinect.JointType.KneeRight]
                    )

            );
            angles.Add(BodyAngle.leftLowwerLeg,
                -getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.KneeRight],
                    kinect.jointPoints[Microsoft.Kinect.JointType.FootLeft]
                    )

            );

            angles.Add(BodyAngle.xPos, kinect.jointPoints[Microsoft.Kinect.JointType.SpineBase].X);
            angles.Add(BodyAngle.yPos, kinect.jointPoints[Microsoft.Kinect.JointType.SpineBase].Y);

        }

        public float getAngle(Point a, Point b)
        {
            double angle = Math.Atan(((double)b.Y - a.Y) / ((double)b.X - a.X));
            if (b.X < a.X)
                angle += Math.PI;

            return (float)angle;
        }

        public void zero()
        {
            foreach (BodyAngle key in angles.Keys)
            {
                baseAngles[key] = 0;
                baseAngles[key] = -getAngle(key);
            }

        }

        public float getAngle(BodyAngle angle)
        {
            if (angles.ContainsKey(angle))
                return angles[angle] + baseAngles[angle];

            return baseAngles[angle];
        }
        
    }
}
