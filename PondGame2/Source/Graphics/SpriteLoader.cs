using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source.Graphics
{
    class SpriteLoader
    {
        public enum Part {
        
            lowwerArm, upperArm, hand, body, head
        
        };

        private Dictionary<String, Texture2D[]> bodySprites;

        public SpriteLoader(ContentManager content)
        {
            bodySprites = new Dictionary<string, Texture2D[]>();
            loadSpriteFile("test",content);
        }

        public void loadSpriteFile(String path, ContentManager content)
        {
            Texture2D[] textures = new Texture2D[5];
            textures[0] = content.Load<Texture2D>("Bodies//" + path + "//Arm1");
            textures[1] = content.Load<Texture2D>("Bodies//" + path + "//Arm2");
            textures[2] = content.Load<Texture2D>("Bodies//" + path + "//Hand");
            textures[3] = content.Load<Texture2D>("Bodies//" + path + "//Body");
            textures[4] = content.Load<Texture2D>("Bodies//" + path + "//Head");

            bodySprites.Add(path, textures);
        }

        //Gets the body part from the dictionary
        public Texture2D getTexture(String body, Part part){

            return bodySprites[body][(int)part];
        
        }
        
    }
}
