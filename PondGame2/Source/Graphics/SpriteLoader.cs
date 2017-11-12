using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source.Graphics
{
    class SpriteLoader
    {
        public static ContentManager content;
        
        public static  Dictionary<String, Texture2D> loadSpriteFile(String path)
        {
            String[] files = Directory.GetFiles(content.RootDirectory + "//Bodies//"+path);

            Dictionary<String, Texture2D> textures = new Dictionary<string, Texture2D>();

            foreach (String file in files)
            {
                String name = file.Substring(9, file.Length - 13).Replace("\\","//");
                textures.Add(name.Substring(14), content.Load<Texture2D>(name));
            }
            
            return textures;
        }
        
    }
}
