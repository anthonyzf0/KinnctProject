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

            if (name == "Knight1")
            {

                body.addPart("base", new CharacterPart("body", CharacterPart.BodyAngle.body, textures["body"],
                    0.6f, Graphics.Render.TexturePoint.mid, z, new Vector2(266, 177)));

                body.addPart("body", new CharacterPart("RightArm", CharacterPart.BodyAngle.rightUpperArm, textures["rightarm"],
                    0.5f, Graphics.Render.TexturePoint.left, new Vector2(-50, 30), new Vector2(126, 77)));

                body.addPart("RightArm", new CharacterPart("Shield", CharacterPart.BodyAngle.rightLowwerArm, textures["shield"],
                    0.4f, Graphics.Render.TexturePoint.mid, new Vector2(150, 0), new Vector2(170, 170)));

                body.addPart("body", new CharacterPart("LeftArm", CharacterPart.BodyAngle.leftUpperArm, textures["leftarm"],
                    0.7f, Graphics.Render.TexturePoint.left, new Vector2(50, 30), new Vector2(126, 77)));

                body.addPart("LeftArm", new CharacterPart("Spear", CharacterPart.BodyAngle.leftLowwerArm, textures["wep"],
                    0.1f, Graphics.Render.TexturePoint.mid, new Vector2(105, 9), new Vector2(60, 470)));
                body.findPart("Spear").shiftImage(-10, 255);
                body.findPart("Spear").debugAngle += (float)Math.PI/2f;

                body.addPart("body", new CharacterPart("Head", CharacterPart.BodyAngle.head, textures["head"],
                    0.59f, Graphics.Render.TexturePoint.bottom, new Vector2(30, 80), new Vector2(160, 160)));
                body.findPart("Head").shiftImage(100, -160);

                body.addPart("body", new CharacterPart("LeftLeg", CharacterPart.BodyAngle.leftUpperLeg, textures["leftleg"],
                    0.58f, Graphics.Render.TexturePoint.top, new Vector2(-20, -20), new Vector2(77, 126)));
                body.addPart("body", new CharacterPart("RightLeg", CharacterPart.BodyAngle.rightUpperLeg, textures["rightleg"],
                    0.9f, Graphics.Render.TexturePoint.top, new Vector2(50, -20), new Vector2(77, 126)));

            }

            if (name == "Knight2")
            {

                body.addPart("base", new CharacterPart("body", CharacterPart.BodyAngle.body, textures["body"],
                    0.6f, Graphics.Render.TexturePoint.mid, z, new Vector2(140, 190)));

                body.addPart("body", new CharacterPart("RightArm", CharacterPart.BodyAngle.rightUpperArm, textures["rightarm"],
                    0.5f, Graphics.Render.TexturePoint.left, new Vector2(-50, 30), new Vector2(200, 100)));
                body.findPart("RightArm").shiftImage(20, 40);

                body.addPart("RightArm", new CharacterPart("Shield", CharacterPart.BodyAngle.rightLowwerArm, textures["shield"],
                    0.4f, Graphics.Render.TexturePoint.mid, new Vector2(200, 50), new Vector2(170, 170)));

                body.addPart("body", new CharacterPart("LeftArm", CharacterPart.BodyAngle.leftUpperArm, textures["leftarm"],
                    0.7f, Graphics.Render.TexturePoint.left, new Vector2(50, 30), new Vector2(150, 77)));
                body.findPart("LeftArm").shiftImage(-20, 40);

                body.addPart("LeftArm", new CharacterPart("Sword", CharacterPart.BodyAngle.leftLowwerArm, textures["wep"],
                    0.1f, Graphics.Render.TexturePoint.bottom, new Vector2(135, 30), new Vector2(150, 150)));
                body.findPart("Sword").shiftImage(-175, -70);

                body.addPart("body", new CharacterPart("Head", CharacterPart.BodyAngle.head, textures["head"],
                    0.59f, Graphics.Render.TexturePoint.bottom, new Vector2(30, 60), new Vector2(160, 160)));
                body.findPart("Head").shiftImage(100, -60);

                body.addPart("body", new CharacterPart("LeftLeg", CharacterPart.BodyAngle.leftUpperLeg, textures["leftleg"],
                    0.58f, Graphics.Render.TexturePoint.top, new Vector2(-20, -20), new Vector2(77, 126)));
                body.addPart("body", new CharacterPart("RightLeg", CharacterPart.BodyAngle.rightUpperLeg, textures["rightleg"],
                    0.9f, Graphics.Render.TexturePoint.top, new Vector2(50, -20), new Vector2(77, 126)));

            }

            if (name == "Knight3")
            {

                body.addPart("base", new CharacterPart("body", CharacterPart.BodyAngle.body, textures["body"],
                    0.6f, Graphics.Render.TexturePoint.mid, z, new Vector2(140, 190)));

                body.addPart("body", new CharacterPart("RightArm", CharacterPart.BodyAngle.rightUpperArm, textures["rightarm"],
                    0.5f, Graphics.Render.TexturePoint.left, new Vector2(-50, 30), new Vector2(200, 100)));
                body.findPart("RightArm").shiftImage(20, 40);

                body.addPart("RightArm", new CharacterPart("Shield", CharacterPart.BodyAngle.rightLowwerArm, textures["shield"],
                    0.4f, Graphics.Render.TexturePoint.mid, new Vector2(200, 50), new Vector2(170, 170)));

                body.addPart("body", new CharacterPart("LeftArm", CharacterPart.BodyAngle.leftUpperArm, textures["leftarm"],
                    0.7f, Graphics.Render.TexturePoint.left, new Vector2(50, 30), new Vector2(150, 77)));
                body.findPart("LeftArm").shiftImage(20, 40);

                body.addPart("LeftArm", new CharacterPart("Sword", CharacterPart.BodyAngle.leftLowwerArm, textures["wep"],
                    0.1f, Graphics.Render.TexturePoint.bottom, new Vector2(135, 30), new Vector2(250, 250)));
                body.findPart("Sword").shiftImage(-175, -70);

                body.addPart("body", new CharacterPart("Head", CharacterPart.BodyAngle.head, textures["head"],
                    0.59f, Graphics.Render.TexturePoint.bottom, new Vector2(30, 60), new Vector2(160, 160)));
                body.findPart("Head").shiftImage(100, -60);

                body.addPart("body", new CharacterPart("LeftLeg", CharacterPart.BodyAngle.leftUpperLeg, textures["leftleg"],
                    0.58f, Graphics.Render.TexturePoint.top, new Vector2(-20, -20), new Vector2(77, 126)));
                body.addPart("body", new CharacterPart("RightLeg", CharacterPart.BodyAngle.rightUpperLeg, textures["rightleg"],
                    0.9f, Graphics.Render.TexturePoint.top, new Vector2(50, -20), new Vector2(77, 126)));

            }

            if (name == "Elf1")
            {

                body.addPart("base", new CharacterPart("body", CharacterPart.BodyAngle.body, textures["body"],
                    0.6f, Graphics.Render.TexturePoint.mid, z, new Vector2(140, 190)));

                body.addPart("body", new CharacterPart("RightArm", CharacterPart.BodyAngle.rightUpperArm, textures["rightarm"],
                    0.5f, Graphics.Render.TexturePoint.top, new Vector2(-30, 30), new Vector2(120, 76)));
                body.findPart("RightArm").shiftImage(-150, 60);

                body.addPart("body", new CharacterPart("LeftArm", CharacterPart.BodyAngle.leftUpperArm, textures["leftarm"],
                    0.7f, Graphics.Render.TexturePoint.left, new Vector2(50, 30), new Vector2(130, 96)));
                body.findPart("LeftArm").shiftImage(20, 40);

                body.addPart("LeftArm", new CharacterPart("Sword", CharacterPart.BodyAngle.leftLowwerArm, textures["wep"],
                    0.1f, Graphics.Render.TexturePoint.bottom, new Vector2(85, 30), new Vector2(100, 250)));
                body.findPart("Sword").shiftImage(-105, -30);
                body.findPart("Sword").debugAngle += (float)Math.PI / 2f;
                
                body.addPart("body", new CharacterPart("Head", CharacterPart.BodyAngle.head, textures["head"],
                    0.59f, Graphics.Render.TexturePoint.bottom, new Vector2(30, 60), new Vector2(140, 140)));
                body.findPart("Head").shiftImage(30, -60);

                body.addPart("body", new CharacterPart("LeftLeg", CharacterPart.BodyAngle.leftUpperLeg, textures["leftleg"],
                    0.58f, Graphics.Render.TexturePoint.top, new Vector2(-20, -40), new Vector2(77, 126)));
                body.addPart("body", new CharacterPart("RightLeg", CharacterPart.BodyAngle.rightUpperLeg, textures["rightleg"],
                    0.9f, Graphics.Render.TexturePoint.top, new Vector2(50, -40), new Vector2(77, 126)));

            }

            if (name == "Ork")
            {

                body.addPart("base", new CharacterPart("body", CharacterPart.BodyAngle.body, textures["body"],
                    0.6f, Graphics.Render.TexturePoint.mid, z, new Vector2(140, 190)));

                body.addPart("body", new CharacterPart("RightArm", CharacterPart.BodyAngle.rightUpperArm, textures["rightarm"],
                    0.5f, Graphics.Render.TexturePoint.top, new Vector2(-40, 40), new Vector2(200, 80)));
                body.findPart("RightArm").shiftImage(-200, 80);

                body.addPart("body", new CharacterPart("LeftArm", CharacterPart.BodyAngle.leftUpperArm, textures["leftarm"],
                    0.7f, Graphics.Render.TexturePoint.left, new Vector2(50, 30), new Vector2(200, 80)));
                body.findPart("LeftArm").shiftImage(20, 40);

                body.addPart("LeftArm", new CharacterPart("Sword", CharacterPart.BodyAngle.leftLowwerArm, textures["wep"],
                    0.1f, Graphics.Render.TexturePoint.bottom, new Vector2(170, 15), new Vector2(200, 200)));
                body.findPart("Sword").shiftImage(-200, -110);
                body.findPart("Sword").debugAngle -= (float)Math.PI / 2f;

                body.addPart("body", new CharacterPart("Head", CharacterPart.BodyAngle.head, textures["head"],
                    0.59f, Graphics.Render.TexturePoint.bottom, new Vector2(30, 60), new Vector2(140, 140)));
                body.findPart("Head").shiftImage(30, -60);

                body.addPart("body", new CharacterPart("LeftLeg", CharacterPart.BodyAngle.leftUpperLeg, textures["leftleg"],
                    0.58f, Graphics.Render.TexturePoint.top, new Vector2(-20, -40), new Vector2(77, 126)));
                body.addPart("body", new CharacterPart("RightLeg", CharacterPart.BodyAngle.rightUpperLeg, textures["rightleg"],
                    0.9f, Graphics.Render.TexturePoint.top, new Vector2(50, -40), new Vector2(77, 126)));

            }

            if (name == "Fighter")
            {

                body.addPart("base", new CharacterPart("body", CharacterPart.BodyAngle.body, textures["body"],
                    0.6f, Graphics.Render.TexturePoint.mid, z, new Vector2(140, 190)));

                body.addPart("body", new CharacterPart("RightArm", CharacterPart.BodyAngle.rightUpperArm, textures["rightarm"],
                    0.5f, Graphics.Render.TexturePoint.top, new Vector2(-30, 30), new Vector2(150, 90)));
                body.findPart("RightArm").shiftImage(-130, 80);

                body.addPart("body", new CharacterPart("LeftArm", CharacterPart.BodyAngle.leftUpperArm, textures["leftarm"],
                    0.7f, Graphics.Render.TexturePoint.left, new Vector2(60, 20), new Vector2(150, 110)));
                body.findPart("LeftArm").shiftImage(40, -50);

                body.addPart("LeftArm", new CharacterPart("Sword", CharacterPart.BodyAngle.leftLowwerArm, textures["wep"],
                    0.1f, Graphics.Render.TexturePoint.bottom, new Vector2(130, -50), new Vector2(100,100)));
                body.findPart("Sword").shiftImage(-50, -50);

                body.addPart("body", new CharacterPart("Head", CharacterPart.BodyAngle.head, textures["head"],
                    0.59f, Graphics.Render.TexturePoint.bottom, new Vector2(30, 60), new Vector2(140, 140)));
                body.findPart("Head").shiftImage(30, -60);

                body.addPart("body", new CharacterPart("LeftLeg", CharacterPart.BodyAngle.leftUpperLeg, textures["leftleg"],
                    0.58f, Graphics.Render.TexturePoint.top, new Vector2(-20, -40), new Vector2(77, 126)));
                body.addPart("body", new CharacterPart("RightLeg", CharacterPart.BodyAngle.rightUpperLeg, textures["rightleg"],
                    0.9f, Graphics.Render.TexturePoint.top, new Vector2(50, -40), new Vector2(77, 126)));

            }

            if (name == "Troll1")
            {

                body.addPart("base", new CharacterPart("body", CharacterPart.BodyAngle.body, textures["body"],
                    0.6f, Graphics.Render.TexturePoint.mid, z, new Vector2(177, 266)));

                body.addPart("body", new CharacterPart("RightArm", CharacterPart.BodyAngle.rightUpperArm, textures["rightarm"],
                    0.5f, Graphics.Render.TexturePoint.left, new Vector2(-50, 20), new Vector2(250, 120)));
                body.findPart("RightArm").shiftImage(20, -90);

                body.addPart("body", new CharacterPart("LeftArm", CharacterPart.BodyAngle.leftUpperArm, textures["leftarm"],
                    0.7f, Graphics.Render.TexturePoint.top, new Vector2(50, 30), new Vector2(77, 180)));

                body.addPart("body", new CharacterPart("Head", CharacterPart.BodyAngle.head, textures["head"],
                    0.59f, Graphics.Render.TexturePoint.bottom, new Vector2(25, 35), new Vector2(160, 160)));
                body.findPart("Head").shiftImage(40, -20);

                body.addPart("body", new CharacterPart("LeftLeg", CharacterPart.BodyAngle.leftUpperLeg, textures["leftleg"],
                    0.58f, Graphics.Render.TexturePoint.top, new Vector2(-20, -60), new Vector2(77, 126)));

                body.addPart("body", new CharacterPart("RightLeg", CharacterPart.BodyAngle.rightUpperLeg, textures["rightleg"],
                    0.9f, Graphics.Render.TexturePoint.top, new Vector2(50, -60), new Vector2(77, 126)));

            }
        
            return body;
        }

    }
}
