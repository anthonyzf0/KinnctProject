using KinectProject.Source.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
            body,head,
            xPos,yPos

        }
        
        //Used for debug
        public float debugAngle = 0;

        //Rotation offset
        private Vector2 size, axis, center;
        private Render.TexturePoint point;
        private double axisAngle, axisDistance, layer;
        private Vector2 shift = Vector2.Zero;
        
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
        public CharacterPart(String name, BodyAngle delta, Texture2D img, double depth, Render.TexturePoint point, Vector2 deltaAxis, Vector2 dimentions)
        {
            //Info on part
            partName = name;
            deltaAngle = delta;
            texture = img;
            layer = depth;

            //Position 
            size = dimentions;

            //Axis location info
            axis = deltaAxis;
            axisAngle = getAngle(axis);
            axisDistance = axis.Length();
            this.point = point;


        }

        public void shiftImage(int x, int y)
        {
            shift = new Vector2(x, y);
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
            if (a == Vector2.Zero) return 0;
            double angle = Math.Atan((double)(a.Y/a.X));
            if (angle == double.NaN) angle = 0;
            if (a.X<0) angle += Math.PI;

            return -(float)angle;
        }
        public Vector2 project( double distance, double angle, Vector2 initial)
        {
            return new Vector2((float)(Math.Cos(angle) * distance), (float)(Math.Sin(angle) * distance)) + initial;
        }

        public void draw(Render render, Vector2 pos, float angle, Dictionary<BodyAngle, float> data)
        {
            //New angle
            Vector2 axisPos = project(axisDistance, angle + axisAngle, pos);
            angle += debugAngle + data[deltaAngle] + KinectData.baseAngles[deltaAngle]);

            if (texture != null)
                render.drawPart(axisPos, size, angle, texture, layer, point, shift);

            //Next Part
            foreach (CharacterPart part in attatchedParts)
            {
                part.draw(render, axisPos, angle, data);
            }
            
        }

    }
}
