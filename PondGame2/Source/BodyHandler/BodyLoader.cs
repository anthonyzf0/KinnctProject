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
    class BodyLoader
    {
        public static CharacterPart loadBody(String name)
        {
            //Shortens declarations
            Vector2 z = Vector2.Zero;

            Dictionary<String, Texture2D> textures = Graphics.SpriteLoader.loadSpriteFile(name);
            CharacterPart body = new CharacterPart();
            
            switch (name)
            {
                case "Knight":

                    body.addPart("base", new CharacterPart("body", CharacterPart.BodyAngle.body, textures["Body"],
                        0.6f, Graphics.Render.TexturePoint.mid, z, new Vector2(266, 177)));

                    body.addPart("body", new CharacterPart("RightArm", CharacterPart.BodyAngle.rightUpperArm, textures["RightArm"],
                        0.5f, Graphics.Render.TexturePoint.left, new Vector2(-50, 30), new Vector2(126, 77)));

                    body.addPart("RightArm", new CharacterPart("Shield", CharacterPart.BodyAngle.rightUpperArm, textures["Shield"],
                        0.4f, Graphics.Render.TexturePoint.mid, new Vector2(150, 0), new Vector2(170, 170)));

                    body.addPart("body", new CharacterPart("LeftArm", CharacterPart.BodyAngle.rightUpperArm, textures["LeftArm"],
                        0.7f, Graphics.Render.TexturePoint.left, new Vector2(50, 30), new Vector2(126, 77)));

                    body.addPart("LeftArm", new CharacterPart("Spear", CharacterPart.BodyAngle.rightUpperArm, textures["Spear"],
                        0.7f, Graphics.Render.TexturePoint.mid, new Vector2(114, 0), new Vector2(60, 470)));
                    body.findPart("Spear").shiftImage(-10, 265);

                    body.addPart("body", new CharacterPart("Head", CharacterPart.BodyAngle.rightUpperArm, textures["Head"],
                        0.59f, Graphics.Render.TexturePoint.bottom, new Vector2(30, 80), new Vector2(160, 160)));
                    body.findPart("Head").shiftImage(100, -160);

                    body.addPart("body", new CharacterPart("LeftLeg", CharacterPart.BodyAngle.rightUpperArm, textures["LeftLeg"],
                        0.58f, Graphics.Render.TexturePoint.top, new Vector2(-20, -20), new Vector2(77, 126)));
                    body.addPart("body", new CharacterPart("RightLeg", CharacterPart.BodyAngle.rightUpperArm, textures["RightLeg"],
                        0.9f, Graphics.Render.TexturePoint.top, new Vector2(50, -20), new Vector2(77, 126)));


                    break;

            }

            return body;
        }

    }
}
