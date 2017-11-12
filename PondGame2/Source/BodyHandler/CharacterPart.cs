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
            HeadToSholder

        }

        //Where it is
        private float distance;
        public float angle;

        //What effects its angle
        private BodyAngle deltaAngle;

        //Name & texture
        public String partName;
        private Texture2D texture;

        public List<CharacterPart> attatchedParts = new List<CharacterPart>();
        
        public CharacterPart(float distance, float angle, BodyAngle delta, String partName, Texture2D texture)
        {
            this.distance = distance;
            this.angle = angle;
            this.deltaAngle = delta;

            this.partName = partName;
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
        
        public void draw(Render render, Vector2 pos, float angle, KinectData data)
        {
            angle += this.angle + data.getAngle(deltaAngle);

            render.drawPart(angle, distance, texture, pos);

            Vector2 newPos = pos + new Vector2(distance * (float)Math.Cos(angle), distance * (float)Math.Sin(angle));

            //Debug
            render.drawBox(pos, Color.Gold);
            render.drawBox(newPos, Color.Gold);

            foreach (CharacterPart part in attatchedParts)
                part.draw(render, newPos, angle,data);
            
        }
        
    }
}
