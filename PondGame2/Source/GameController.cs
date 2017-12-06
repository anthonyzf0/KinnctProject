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
        //private KinectHandler kinect;
        private KinectData data;
        private KinectHandler kinect;
        
        //Loads a body
        private CharacterPart body = BodyLoader.loadBody("Elf1");

        //Backgrounds and other bodies
        private int backgroundId, bodyId;
        private List<Texture2D> background = SpriteLoader.loadBackgrounds();
        private List<String> bodyNames = SpriteLoader.characterNames();
        
        //Saves
        private List<Save> saves = new List<Save>();
        public bool saving = false;
        public bool guy = true;

        //Keys
        private KeyHandler key = new KeyHandler();
        
        public GameController()
        {
            kinect = new KinectHandler();
            data = new KinectData();
            
        }
        
        public void update()
        {
            //Updates angle data with the kinect object
            data.readData(kinect);

            //Get key Presses
            key.update();

            //Zeros all data so that your position is now the base position
            if (key.getKey(Keys.Z)) data.zero();

            //Body swapping stuff
            if (key.getKey(Keys.W))
            {
                bodyId++;
                if (bodyId >= bodyNames.Count) bodyId = 0;
                body = BodyLoader.loadBody(bodyNames[bodyId]);
            }
            if (key.getKey(Keys.E))
            {
                backgroundId = (backgroundId == background.Count - 1) ? 0 : backgroundId + 1;
            }
            if (key.getKey(Keys.Q))
            {
                saving = !saving;
                if (saving) 
                    saves.Add(new Save(bodyNames[bodyId]));

                if (!saving)
                    saves[saves.Count-1].select();
                
            }

            if (key.getKey(Keys.Delete))
            {
                for (int i = 0; i < saves.Count; i++)
                    if (saves[i].selected)
                    {
                        saves.RemoveAt(i);
                        i--;
                    }
            }
            if (key.getKey(Keys.P))
                guy = !guy;

            //Select pressed numbers
            int num = key.getNum();
            if (num != -1 && saves.Count > num)
                saves[num].select();

            //Saving
            if (saving)
                saves[saves.Count - 1].addFrame(data.angles);
            
        }

        public void draw(Render render)
        {
            //if (data.angles.Keys.Count == 0) return;

            render.background(background[backgroundId]);

            for (int i = 0; i < saves.Count; i++)
                saves[i].draw(i, render);

            if (guy)
            {
                if (data.angles.Count != 0)
                    body.draw(render, new Vector2(1400 - data.angles[BodyAngle.xPos]*(2.7f), 150 + data.angles[BodyAngle.yPos]), 0, data.angles);
                else
                    body.draw(render, new Vector2(300, 300), 0, data.angles);
                
            }
            else
            {
                render.show(50,50,"Player hidden");
            }
        }

    }
}
