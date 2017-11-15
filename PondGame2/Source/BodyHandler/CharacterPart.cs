using KinectProject.Source.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source.BodyHandler
{
    class CharacterPart
    {
        public enum BodyAngle
        {
            zero,
            leftUpperArm, leftLowwerArm, rightUpperArm, rightLowwerArm,
            leftUpperLeg, leftLowwerLeg, rightUpperLeg, rightLowwerLeg,
            body,head

        }

        //Where it is
        private float distance;
        private Vector2 offset = Vector2.Zero;
        public float angle;

        //Other info
        private bool roateMid = false;

        //What effects its angle
        private BodyAngle deltaAngle;

        //Name & texture
        public String partName;
        private Texture2D texture;

        public List<CharacterPart> attatchedParts = new List<CharacterPart>();
        
        public CharacterPart(float distance, float angle, Vector2 offset, BodyAngle delta, String partName, Texture2D texture)
        {
            this.distance = distance;
            this.angle = angle;
            this.offset = offset;
            this.deltaAngle = delta;

            this.partName = partName;
            this.texture = texture;

        }

        public CharacterPart(float angle, BodyAngle delta, String name, Texture2D texture)
        {
            roateMid = true;
            
            this.angle = angle;
            this.deltaAngle = delta;
            this.partName = name;

            this.texture = texture;
            
        }

        public void addPart(string basePart, CharacterPart newPart)
        {
            CharacterPart part = findPart(basePart);

            if (part == null) return;

            part.attatchedParts.Add(newPart);

        }
        public CharacterPart findPart(String name)
        {
            if (partName == name)
                return this;

            foreach (CharacterPart part in attatchedParts)
            {
                CharacterPart foundPart = part.findPart(name);
                if (foundPart != null)
                    return foundPart;
            }

            return null;
        }

        public float getAngle(Vector2 a, Vector2 b)
        {
            double angle = Math.Atan(((double)b.Y - a.Y) / ((double)b.X - a.X));
            if (b.X < a.X)
                angle += Math.PI;

            return (float)angle;
        }

        public void draw(Render render, Vector2 pos, float angle, KinectData data)
        {
            //Gets angles and pos
            angle += this.angle + data.getAngle(deltaAngle);
            
            pos += offset;

            //Rotates and draws
            if (roateMid)
                render.drawPartCenter(texture, pos, angle);
            else
                render.drawPartDistance(angle, distance, texture, pos);

            //draws points
            render.drawBox(pos, Color.Gold);

            if (!roateMid)
            pos += new Vector2(distance * (float)Math.Cos(angle), distance * (float)Math.Sin(angle));

            render.drawBox(pos, Color.Gold);
            
            //Next points
            foreach (CharacterPart part in attatchedParts)
            {
                if (roateMid) {
                    double nextangle = (double)getAngle(Vector2.Zero, part.offset) + angle;
                    float length = part.offset.Length();
                    Vector2 nextPos = -part.offset + pos + new Vector2(length*(float)Math.Cos(nextangle), length*(float)(Math.Sin(nextangle)));
                    part.draw(render, nextPos, angle, data);
                }
                else
                    part.draw(render, pos, angle, data);
            }
            
        }
        
    }
}
