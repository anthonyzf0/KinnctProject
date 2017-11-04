using KinectProject.Source.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectProject.Source.Menu
{
   class Tab
    {
        public String name = "";

        public virtual void initialize(String name)
        {
            this.name = name;
        }
        public virtual void update()
        {

        }
        public virtual void render(Render render)
        {

        }
        
    }
}
