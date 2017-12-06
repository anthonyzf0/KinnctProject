using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source
{
    class KeyHandler
    {
        private List<Keys> keys = new List<Keys>() { Keys.Q, Keys.W, Keys.E, Keys.Z, Keys.Delete, Keys.P};
        private List<Keys> nums = new List<Keys>() { Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5 };

        private Dictionary<Keys, bool> values = new Dictionary<Keys, bool>();
        private bool lastPress = false; 

        public KeyHandler()
        {
            foreach (Keys key in keys) values.Add(key, false);
            foreach (Keys key in nums) values.Add(key, false);

        }
        
        public void update()
        {
            bool press = false;
            for(int i=0;i<values.Count;i++)
            {
                Keys key = values.ElementAt(i).Key;

                values[key] = false;
                if (Keyboard.GetState().IsKeyDown(key))
                {
                    press = true;
                    if (lastPress) {
                        lastPress = false;
                        values[key] = true;
                    }
                }
            }

            if (press == false)
                lastPress = true;
        }

        public bool getKey(Keys key)
        {
            return (values[key]);

        }

        public int getNum()
        {
            foreach (Keys key in nums)
                if (values[key])
                    return nums.IndexOf(key);
            return -1;
        }
    }
}
