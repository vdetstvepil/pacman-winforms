using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PacManFuture.Classes
{
    internal class Labirint
    {
      
        





        internal void Paint()
        {
            

            Graphics formGraphics = form1.pictureBox1.CreateGraphics();

            int dx, dy;
            int i, j;
            int x, y, r;

            Pen myPen = new Pen(Color.Black);

            SolidBrush myBrush = new SolidBrush(Color.Red);

            int n = 10;
            dx = form1.pictureBox1.Width / n;
            dy = form1.pictureBox1.Height / n;
            if (dx > dy) r = (dy / 2) - 5;
            else r = (dx / 2) - 5;

            for (j = 0; j <= 9; j++)
                for (i = 0; i <= 9; i++)
                {
                    myBrush.Color = Color.Empty;
                    myPen.Color = Color.Black;
                    x = dx / 2 + i * dx;
                    y = dy / 2 + j * dy;
                    switch (form1.mas[j, i])
                    {
                        case 0: myBrush.Color = Color.White; break;
                        case -1: myBrush.Color = Color.Red; break;
                        case -2: myBrush.Color = Color.Blue; break;
                        case -3: myBrush.Color = Color.Lime; break;
                        case -4: myBrush.Color = Color.Aqua; break;
                        case -5: myBrush.Color = Color.Fuchsia; break;
                        case -6: myBrush.Color = Color.Yellow; break;
                        case -7: myBrush.Color = Color.Black; break;
                    }
                    formGraphics.FillEllipse(myBrush, x - r, y - r, 2 * r, 2 * r);
                }

            form1.pictureBox1.Update();
        }
    }
}
