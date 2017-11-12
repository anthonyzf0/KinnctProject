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

                    body = new CharacterPart(100, 0, CharacterPart.BodyAngle.HeadToSholder, "test0", textures["Arm1"]);

                    for(int i=0;i<6;i++)
                        body.addPart("test"+i, new CharacterPart(100, 0, CharacterPart.BodyAngle.HeadToSholder, "test"+(i+1), textures["Arm1"]));

                    break;
                    
            }

            return body;
        }

    }
}
