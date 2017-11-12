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

            //Clear last data
            angles = new Dictionary<BodyAngle, float>();

            //Head to sholder
            angles.Add(BodyAngle.HeadToSholder, 
                getAngle(
                    kinect.jointPoints[Microsoft.Kinect.JointType.Head], 
                    kinect.jointPoints[Microsoft.Kinect.JointType.Neck]
                    )
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
