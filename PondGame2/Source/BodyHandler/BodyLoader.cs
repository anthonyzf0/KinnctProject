using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source.BodyHandler
{
    class BodyLoader
    {

        public static CharacterPart loadBody(String name)
        {
            Dictionary<String, Texture2D> textures = Graphics.SpriteLoader.loadSpriteFile(name);
            CharacterPart body = null;

            switch (name)
            {
                case "test":
                    
                    body = new CharacterPart(0, 0, CharacterPart.BodyAngle.zero, "base", null);
                    //Left arm
                    body.addPart("base", new CharacterPart(100, 0, CharacterPart.BodyAngle.leftUpperArm, "upLeft", textures["Arm1"]));
                    body.addPart("upLeft", new CharacterPart(100, 0, CharacterPart.BodyAngle.leftLowwerArm, "lowLeft", textures["Arm1"]));
                    body.addPart("handLeft", new CharacterPart(100, 0, CharacterPart.BodyAngle.leftLowwerArm, "lowLeft", textures["Arm1"]));

                    //Right arm
                    body.addPart("base", new CharacterPart(100, 0, CharacterPart.BodyAngle.rightUpperArm, "upRight", textures["Arm1"]));
                    body.addPart("upRight", new CharacterPart(100, 0, CharacterPart.BodyAngle.rightLowwerArm, "lowRight", textures["Arm1"]));
                    
                    break;
                    
            }

            return body;
        }

    }
}
