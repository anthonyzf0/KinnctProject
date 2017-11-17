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

        //Used for debug
        public float debugAngle = 0;

        //Rotation offset
        private float x = 0, y = 0;
        private Vector2 offset;
        private float offsetAngle = 0;

        private int length;

        private int sizeX, sizeY;
        private bool mid = false;
        private float distance = 0;
        
        //What effects its angle
        private BodyAngle deltaAngle;

        //Name & texture
        public String partName;
        private Texture2D texture;

        public List<CharacterPart> attatchedParts = new List<CharacterPart>();

        //Sets up base body
        public CharacterPart()
        {
            partName = "base";

            texture = null;
            deltaAngle = BodyAngle.zero;
        }

        //Sets a part rotating about its center
        public CharacterPart(String name, BodyAngle delta, Texture2D img, int width, int height)
        {
            partName = name;
            deltaAngle = delta;

            texture = img;

            sizeX = width;
            sizeY = height;
            
            mid = true;

        }

        //Sets a part rotating about a point x and y from last part center
        public CharacterPart(String name, BodyAngle delta, float x, float y, Texture2D img, int length)
        {
            partName = name;
            deltaAngle = delta;

            texture = img;

            //Position data
            this.x = x;
            this.y = y;
            offset = new Vector2(x, y);
            distance = offset.Length();
            offsetAngle = getAngle(offset);

            this.length = length;
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
        public float getAngle(Vector2 a)
        {
            double angle = Math.Atan((double)(a.Y/a.X));
            if (a.X<0) angle += Math.PI;

            return (float)angle;
        }

        public void draw(Render render, Vector2 pos, float angle, KinectData data)
        {
            render.drawBox(pos, Color.Orange);
            //Gets angles and pos
            angle += offsetAngle;
            float nextAngle = angle + data.getAngle(deltaAngle) + debugAngle; 

            //Rotates and draws
            if (mid)
                render.drawPartCenter(texture, pos, nextAngle, sizeX, sizeY);
            else
            {
                pos += new Vector2((float)(distance * Math.Cos(angle)),(float)(distance * Math.Sin(angle)));
                render.drawPartDistance(nextAngle, length, texture, pos);

                pos += new Vector2((float)(length * Math.Cos(nextAngle)), (float)(length * Math.Sin(nextAngle)));
            }

            render.drawBox(pos, Color.Purple);
            

            //Next points
            foreach (CharacterPart part in attatchedParts)
            {
                part.draw(render, pos, nextAngle, data);
            }
            
        }
        
    }
}
