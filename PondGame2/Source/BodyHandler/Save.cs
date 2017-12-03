using KinectProject.Source.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KinectProject.Source.BodyHandler.CharacterPart;

namespace KinectProject.Source.BodyHandler
{
    class Save
    {
        private bool selected = false;
        private int frameNumber = 0;

        private List<Dictionary<BodyAngle, float>> frames = new List<Dictionary<BodyAngle, float>>();
        private CharacterPart body;
        
        public Save(String character)
        {
            body = BodyLoader.loadBody(character);
        }

        public void addFrame(Dictionary<BodyAngle, float> data)
        {
            frames.Add(data);
            selected = false;
        }

        public void select()
        {
            selected = !selected;
        }

        public void draw(int num, Render render) {

            render.draw(num * 100, 500, 75, 75, Color.White);
            if (selected)
                render.draw(num * 100 - 5, 500-5, 75+10, 75+10, Color.Green);
            render.show(num * 100 + 30, 530, num+"!");


            if (selected)
            {
                frameNumber++;
                if (frameNumber == frames.Count)
                    frameNumber = 0;

                body.draw(render, new Vector2(  frames[frameNumber][BodyAngle.xPos], 
                                                frames[frameNumber][BodyAngle.yPos]), 
                                                0, frames[frameNumber]);

            }

        }
    }
}
