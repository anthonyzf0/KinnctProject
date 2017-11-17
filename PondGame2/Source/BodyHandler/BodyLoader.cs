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
            CharacterPart body = new CharacterPart();

            switch (name)
            {
                case "test":

                    body.addPart("base", new CharacterPart("body", CharacterPart.BodyAngle.body, textures["Body"], 100, 100));

                    //Arms
                    body.addPart("body", new CharacterPart("leftArm", CharacterPart.BodyAngle.leftUpperArm, -100, -80, textures["Arm1"], 100));
                    body.addPart("leftArm", new CharacterPart("leftArm2", CharacterPart.BodyAngle.leftUpperArm, 0, 1, textures["Arm1"], 100));
                    body.addPart("body", new CharacterPart("rightArm", CharacterPart.BodyAngle.leftUpperArm, 100, -80, textures["Arm1"], 100));
                    body.addPart("rightArm", new CharacterPart("rightArm2", CharacterPart.BodyAngle.leftUpperArm, 0, 1, textures["Arm1"], 100));

                    break;

            }

            return body;
        }

    }
}
