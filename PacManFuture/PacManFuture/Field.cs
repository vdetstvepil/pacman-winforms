using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacManFuture.Classes;

namespace PacManFuture
{
    public partial class Field : Form
    {
        //internal int[,] mas = new int[10, 10];
        internal int[,] mas_vsp = new int[10, 10];

        internal static int[,] mas = new int[,]
        {
{0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0 },
{0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0 },
{0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0 },
{0, 0, 0, -1, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0 },
{0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0 },
{0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0 },
{0, 0, 0, -1, -1, -1, -1, -1, 0, 0, 0, 0, -1, -1, -1, -1, -1, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0 },
{-1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{-1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1 },
{0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, -1, -1, -1, -1, -1, 0, 0, 0, 0, -1, -1, -1, -1, -1, 0, 0, 0 },
{0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0 },
{0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0 },
{0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0 },
{0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0 },
{0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0 },
{0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0 },
        };

        

        PacMan pacman = new PacMan();
        public Field()
        {
            InitializeComponent();
            mas[pacman.Y, pacman.X] = -2;
        }

        internal void findinmas(int symbol, ref int y, ref int x)
        {
            bool STOP = false;
            for (int j = 0; j <= 19 && STOP == false; j++)
                for (int i = 0; i <= 19 && STOP == false; i++)
                {
                    if (mas[j, i] == symbol) { y = j; x = i; STOP = true; break; }
                }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics formGraphics = this.CreateGraphics();

            int dx, dy;
            int i = 1, j = 1;
            int x, y, r;

            Pen myPen = new Pen(Color.Black);

            SolidBrush myBrush = new SolidBrush(Color.Red);

            //mas[j, i] = -1;

            int n = 10;


            for (j = 0; j <= 19; j++)
                for (i = 0; i <= 19; i++)
                {
                    myBrush.Color = Color.Empty;
                    myPen.Color = Color.Black;
                    x = i * n;
                    y = j * n;
                    switch (mas[j, i])
                    {
                        case 0: myBrush.Color = Color.Black; break;
                        case -1: myBrush.Color = Color.Blue; break;

                    }
                    formGraphics.FillRectangle(myBrush, x, y, 5, 5);
                }

            //findinmas(-2, ref pacman.y, ref pacman.x);
            pacman.Draw(formGraphics);
            


            this.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Field_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    pacman.Move();
                    break;

                case Keys.S:
                    pacman.Move();
                    break;

                case Keys.A:
                    pacman.Move();
                    break;

                case Keys.D:
                    pacman.Move();
                    break;
            }
        }
    }
}
