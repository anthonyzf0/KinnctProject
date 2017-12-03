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
                String key = name.Substring(name.LastIndexOf("//")+2);
                textures.Add(key.ToLower(), content.Load<Texture2D>(name));
            }
            
            return textures;
        }

        public static List<Texture2D> loadBackgrounds()
        {
            String[] files = Directory.GetFiles(content.RootDirectory + "//Backgrounds");

            List<Texture2D> imgs = new List<Texture2D>();

            foreach (String file in files)
            {
                String name = file.Substring(9, file.Length-13).Replace("\\", "//");
                imgs.Add(content.Load<Texture2D>(name));
            }

            return imgs;
        }

        public static List<String> characterNames()
        {
            String[] files = Directory.GetDirectories(content.RootDirectory + "//Bodies//");

            List<String> dirs = new List<String>();

            foreach (String file in files)
            {
                String name = file.Substring(17, file.Length - 17).Replace("\\", "//");
                dirs.Add(name);
            }

            return dirs;
        }
    }
        
}
