using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;

namespace PacManFuture.Classes
{
    sealed class Fruit : Creature
    {
        public new int o;
        public Fruit()
        {
            X = 14;
            Y = 17;
            Speed = 5;
            o =1;
        }

        public override void Draw(Graphics formGraphics)
        {
            int dx = X * 20, dy = Y * 20;
            
            imageFruit = Image.FromFile(@"Images/Fruit" + Convert.ToString(o) + ".bmp");

            dx = X * n;
            dy = Y * n;

            formGraphics.DrawImage(imageFruit, dx, 30 + dy, 20, 20);
        }
    }
}
