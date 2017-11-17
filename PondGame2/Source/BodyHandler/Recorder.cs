using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KinectProject.Source.BodyHandler.CharacterPart;

namespace KinectProject.Source.BodyHandler
{
    class Recorder
    {
        private static int recordSize = 500;
        private bool recording = false;
        private List<Dictionary<BodyAngle, float>> bodyData = new List<Dictionary<BodyAngle, float>>();

        public Recorder()
        {
        }
        
        public void update(KinectData data)
        {
            if (!recording) return;

            Dictionary<BodyAngle, float> bodyPos =new Dictionary<BodyAngle, float>();

            foreach (BodyAngle key in data.angles.Keys)
                bodyPos.Add(key,data.angles[key]);

            if (bodyData.Count > recordSize)
                recording = false;

        }

        public void start()
        {
            recording = true;
        }

        public void stop()
        {
            recording = false;
        }

    }
}
