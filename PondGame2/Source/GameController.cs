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
using static KinectProject.Source.BodyHandler.CharacterPart;

namespace KinectProject.Source
{
    class GameController
    {
        private KinectHandler kinect;
        private KinectData data;
        
        //Loads a body
        private CharacterPart body = BodyLoader.loadBody("Fighter");

        //Backgrounds and other bodies
        private int backgroundId, bodyId;
        private bool lastPress = false;
        private List<Texture2D> background = SpriteLoader.loadBackgrounds();
        private List<String> bodyNames = SpriteLoader.characterNames();

        //Saves
        private List<Save> saves = new List<Save>();
        public bool saving = false;
        
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
            
            //Body swapping stuff
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (!lastPress)
                {
                    lastPress = true;
                    bodyId++;
                    if (bodyId >= bodyNames.Count) bodyId = 0;
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
            //Start or stop save
            else if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                saving = !saving;

                if (saving)
                {
                    saves.Add(new Save(bodyNames[bodyId]));
                }
            }
            else
            {
                lastPress = false;
            }

            //Saving
            if (saving)
            {
                saves[saves.Count - 1].addFrame(data.angles);
            }
            
        }

        public void draw(Render render)
        {

            render.background(background[backgroundId]);

            for (int i = 0; i < saves.Count; i++)
                saves[i].draw(i, render);

            body.draw(render, new Vector2(300, 300), 0, data.angles);
        }

    }
}
