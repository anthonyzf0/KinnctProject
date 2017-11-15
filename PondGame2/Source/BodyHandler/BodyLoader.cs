using Microsoft.Xna.Framework;
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
                case "test2":

                    body = new CharacterPart(0, 0, Vector2.Zero, CharacterPart.BodyAngle.zero, "base", null);
                    //Left arm
                    body.addPart("base", new CharacterPart(100, 0, Vector2.Zero, CharacterPart.BodyAngle.leftUpperArm, "upLeft", textures["Arm1"]));
                    body.addPart("upLeft", new CharacterPart(100, 0, Vector2.Zero, CharacterPart.BodyAngle.leftLowwerArm, "lowLeft", textures["Arm1"]));

                    //Right arm
                    body.addPart("base", new CharacterPart(100, 0, Vector2.Zero, CharacterPart.BodyAngle.rightUpperArm, "upRight", textures["Arm1"]));
                    body.addPart("upRight", new CharacterPart(100, 0, Vector2.Zero, CharacterPart.BodyAngle.rightLowwerArm, "lowRight", textures["Arm1"]));

                    break;

                case "test":

                    body = new CharacterPart(0, 0, Vector2.Zero, CharacterPart.BodyAngle.zero, "base", null);
                    //Left arm
                    body.addPart("base", new CharacterPart(-5 * (float)Math.PI / 4, CharacterPart.BodyAngle.body, "body", textures["Body"]));
                    body.addPart("body", new CharacterPart(100, 0, new Vector2(-50, -50), CharacterPart.BodyAngle.leftUpperArm, "leftUpperArm", textures["Arm1"]));

                    break;

            }

            return body;
        }

    }
}
