using KinectProject.Source.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public bool selected = false;
        private int frameNumber = 0;
        private double sec = 0;

        private List<Dictionary<BodyAngle, float>> frames = new List<Dictionary<BodyAngle, float>>();
        private CharacterPart body;
        private Texture2D head;
        
        public Save(String character)
        {
            body = BodyLoader.loadBody(character);
            head = body.findPart("Head").texture;
        }

        public void addFrame(Dictionary<BodyAngle, float> data)
        {
            frames.Add(data);
            selected = false;
            sec = Math.Round(frames.Count / 60.0, 2);
        }

        public void select()
        {
            selected = !selected;
        }

        public void draw(int num, Render render) {

            int x = num * 100, y = 500;
            int w = 75, h = 75;

            if (selected)
                render.draw(x, y, w, h, Color.Green);
            else
                render.draw(x, y, w, h, Color.White);

            render.drawPart(new Vector2(x + w/2, y + h/2), new Vector2(w, h), 0, head, 0.001f, Render.TexturePoint.mid, Vector2.Zero);
            render.show(x + 5, y - 15, sec+"s");


            if (selected)
            {
                frameNumber++;
                if (frameNumber == frames.Count)
                    frameNumber = 0;

                if (frames[frameNumber].Count != 0)
                    body.draw(render, new Vector2(1400 - (frames[frameNumber][BodyAngle.xPos])*(2.7f), 
                                                150+frames[frameNumber][BodyAngle.yPos]), 
                                                0, frames[frameNumber]);

            }

        }
    }
}
