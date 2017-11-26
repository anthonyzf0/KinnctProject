using Encog.Neural.Networks;
using KinectProject.Source.BodyHandler;
using KinectProject.Source.Graphics;
using KinectProject.Source.Kinect;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source
{
    class GameController
    {
        private KinectHandler kinect;
        private KinectData data;
        
        //Loads a body
        private CharacterPart body = BodyLoader.loadBody("Knight");

        //Backgrounds and other bodies
        private int backgroundId, bodyId;
        private bool lastPress = false;
        private List<Texture2D> background = SpriteLoader.loadBackgrounds();
        private List<String> bodyNames = SpriteLoader.characterNames();

        public GameController()
        {
            //kinect = new KinectHandler();
            data = new KinectData();
            
        }
        
        public void update()
        {
            //Updates angle data with the kinect object
            //data.readData(kinect);

            //Zeros all data so that your position is now the base position
            if (Keyboard.GetState().IsKeyDown(Keys.Q)) data.zero();

            if (Keyboard.GetState().IsKeyDown(Keys.R)) body.findPart("body").debugAngle += 0.05f;
            if (Keyboard.GetState().IsKeyDown(Keys.T)) body.findPart("RightArm").debugAngle += 0.05f;
            if (Keyboard.GetState().IsKeyDown(Keys.Y)) body.findPart("Shield").debugAngle += 0.05f;
            if (Keyboard.GetState().IsKeyDown(Keys.U)) body.findPart("LeftArm").debugAngle += 0.05f;
            if (Keyboard.GetState().IsKeyDown(Keys.I)) body.findPart("Spear").debugAngle += 0.05f;
            if (Keyboard.GetState().IsKeyDown(Keys.O)) body.findPart("Head").debugAngle += 0.05f;

            //Body swapping stuff
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (!lastPress)
                {
                    bodyId = (bodyId == bodyNames.Count - 1) ? 0 : bodyId + 1;
                    body = BodyLoader.loadBody(bodyNames[bodyId]);
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.E)) {
                if (!lastPress)
                {
                    lastPress = true;
                    backgroundId = (backgroundId == background.Count - 1) ? 0 : backgroundId + 1;
                }
            }
            else { 
                lastPress = false;
                }

        }

        public void draw(Render render)
        {

            body.draw(render, new Vector2(300, 300), 0, data);
        }

    }
}
