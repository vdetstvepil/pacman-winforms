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
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace PacManFuture
{
    public partial class Field : Form
    {
        //public int[,] mas = new int[10, 10];
        //public int[,] mas_vsp = new int[10, 10];

        public string mode = "Готовность";
        public int ochki = 0;
        public int level = 0;
        public int schetchiksobrantochek = 0;

        int t = 0;
        int g = 0;
        int m = 0;
        bool boolean = false;

        public static int[,] mas = new int[31, 28]
        {
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
            { -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1 },
            { -1, -2, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -2, -1 },
            { -1, -3, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -3, -1 },
            { -1, -2, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -2, -1 },
            { -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1 },
            { -1, -2, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -2, -1 },
            { -1, -2, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -2, -1 },
            { -1, -2, -2, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -2, -2, -1 },
            { -1, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1,  0, -1, -1,  0, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1, -1 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1, -1, -1, -1,  0, -1, -1,  0, -1, -1, -1, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0, -1, -1, -1,  0,  0, -1, -1, -1,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0, -1, -1, -1,  0, -1, -1, -1, -1,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2,  0,  0,  0, -1, -1,  0,  0,  0, -1, -1, -1,  0,  0,  0, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0, -1, -1,  0,  0,  0, -1, -1, -1,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0, -1, -1, -1, -1, -1, -1, -1, -1,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0, -1, -1, -1, -1, -1, -1, -1, -1,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            { -1, -1, -1, -1, -1, -1, -2, -1, -1,  0, -1, -1, -1, -1, -1, -1, -1, -1,  0, -1, -1, -2, -1, -1, -1, -1, -1, -1 },
            { -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1 },
            { -1, -2, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -2, -1 },
            { -1, -3, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -3, -1 },
            { -1, -2, -2, -2, -1, -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1, -1, -2, -2, -2, -1 },
            { -1, -1, -1, -2, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -2, -1, -1, -1 },
            { -1, -1, -1, -2, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -2, -1, -1, -1 },
            { -1, -2, -2, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -2, -2, -1 },
            { -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1 },
            { -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1 },
            { -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1 },
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }
        };

        public string Direction;
        PacMan pacman = new PacMan();
        RandomGhost randomGhost = new RandomGhost();
        DirectionGhost directionGhost = new DirectionGhost();
        Fruit fruit = new Fruit();

        SolidBrush myBrush = new SolidBrush(Color.Red);

        Image imageReady = Image.FromFile(@"Images/READY.bmp");
        Image imagePause = Image.FromFile(@"Images/PAUSE.bmp");


        public Field()
        {
            InitializeComponent();
            fontsProjects();
            fonts();

            Direction = "UNDEFINED";
            for (int y = 0; y < 31; y++)
            {
                for (int x = 0; x < 28; x++)
                {
                    if (mas[y, x] == -1) directionGhost.mas_vsp[y, x] = 1;
                    else directionGhost.mas_vsp[y, x] = 0;
                }
            }
            ochki = 0;
            level = 1;
            boolean = false;
        }

        PrivateFontCollection font;
        private void fontsProjects()
        {
            this.font = new PrivateFontCollection();
            this.font.AddFontFile(@"Fonts/3572.ttf");
        }

        private void fonts()
        {
            label1.Font = new Font(font.Families[0], 15);
            label2.Font = new Font(font.Families[0], 15);
        }


        const int n = 20;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int x, y;

            for (int j = 0; j < 31; j++)
                for (int i = 0; i < 28; i++)
                {
                    myBrush.Color = Color.Empty;
                    x = i * n;
                    y = j * n;
                    switch (mas[j, i])
                    {
                        case -2: myBrush.Color = Color.White; e.Graphics.FillEllipse(myBrush, x + 9, 30 + y + 9, 2, 2); break;
                        case -3: myBrush.Color = Color.LightYellow; e.Graphics.FillEllipse(myBrush, x + 7, 30 + y + 7, 7, 7); break;
                    }
                }

            if (mode != "Готовность" && mode != "Выигрыш")
            {
                if (boolean == true) fruit.Draw(e.Graphics);

                pacman.Draw(e.Graphics);
            }
            if (mode != "Смерть" && m != 1 && mode != "Выигрыш")
            {
                randomGhost.Draw(e.Graphics);
                directionGhost.Draw(e.Graphics);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void buttonClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Field_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    Direction = "up";
                    break;

                case Keys.S:
                    Direction = "down";
                    break;

                case Keys.A:
                    Direction = "left";
                    break;

                case Keys.D:
                    Direction = "right";
                    break;
            }
        }



        private void timer1_Tick(object sender, EventArgs a)
        {
            if (mode == "Готовность")
            {
                mode = "Игра";
                timer1.Interval = 16;
            }

            if (mode == "Игра")
            {
                t++;
                
                {
                    if ((pacman.X == directionGhost.X && pacman.Y == directionGhost.Y) ||
                    (pacman.X == randomGhost.X && pacman.Y == randomGhost.Y)) mode = "Смерть";

                    if (t % (30 / pacman.Speed) == 0)
                    {
                        pacman.Move(Direction, ref mas);
                        pacman.FindYacheiki(ref mas, ref ochki, ref schetchiksobrantochek);
                        if (schetchiksobrantochek > 245) { mode = "Выигрыш"; m = 0; } // 245
                    }

                    if (t % (30 / randomGhost.Speed) == 0)
                        randomGhost.Move(ref mas);

                    if (t % (30 / directionGhost.Speed) == 0)
                    {
                        for (int y = 0; y < 31; y++)
                        {
                            for (int x = 0; x < 28; x++)
                            {
                                if (mas[y, x] == -1) directionGhost.mas_vsp[y, x] = -1;
                                else directionGhost.mas_vsp[y, x] = 0;
                            }
                        }
                        directionGhost.x_end = pacman.X;
                        directionGhost.y_end = pacman.Y;
                        directionGhost.Move(ref mas);
                    }

                    if (ochki % 500 == 0 && ochki != 0)
                    {
                        boolean = true;
                        g = 0;
                    }

                    if (boolean == true)
                    {
                        g++;
                        if (pacman.X == fruit.X && pacman.Y == fruit.Y)
                        {
                            switch (fruit.o)
                            {
                                case 1:
                                    ochki += 100;
                                    fruit.o++;
                                    break;
                                case 2:
                                    ochki += 300;
                                    fruit.o++;
                                    break;
                                case 3:
                                    ochki += 500;
                                    fruit.o++;
                                    break;
                                case 4:
                                    ochki += 700;
                                    fruit.o++;
                                    break;
                                case 5:
                                    ochki += 1000;
                                    fruit.o++;
                                    break;
                                case 6:
                                    ochki += 2000;
                                    fruit.o++;
                                    break;
                                case 7:
                                    ochki += 3000;
                                    fruit.o++;
                                    break;
                                case 8:
                                    ochki += 5000;
                                    //fruit.o++;
                                    break;
                            }
                            boolean = false;
                        };
                        if (g == 700) boolean = false;
                    }
                }

                label1.Text = "Очки  " + Convert.ToString(ochki);
                this.Refresh();
            }

            if (mode == "Выигрыш")
            {
                switch (m)
                {
                    case 0:
                        m = 1;
                        timer1.Interval = 1000;
                        break;
                    case 1:
                        m = 2;
                        timer1.Interval = 2000;
                        this.BackgroundImage = Image.FromFile(@"Board 3 White.bmp");
                        break;
                    case 2:
                        mode = "Готовность";
                        mas = new int[31, 28]
        {
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
            { -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1 },
            { -1, -2, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -2, -1 },
            { -1, -3, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -3, -1 },
            { -1, -2, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -2, -1 },
            { -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1 },
            { -1, -2, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -2, -1 },
            { -1, -2, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -2, -1 },
            { -1, -2, -2, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -2, -2, -1 },
            { -1, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1,  0, -1, -1,  0, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1, -1 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1, -1, -1, -1,  0, -1, -1,  0, -1, -1, -1, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0, -1, -1, -1,  0,  0, -1, -1, -1,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0, -1, -1, -1,  0, -1, -1, -1, -1,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2,  0,  0,  0, -1, -1,  0,  0,  0, -1, -1, -1,  0,  0,  0, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0, -1, -1,  0,  0,  0, -1, -1, -1,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0, -1, -1, -1, -1, -1, -1, -1, -1,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0, -1, -2, -1, -1,  0, -1, -1, -1, -1, -1, -1, -1, -1,  0, -1, -1, -2, -1,  0,  0,  0,  0,  0 },
            { -1, -1, -1, -1, -1, -1, -2, -1, -1,  0, -1, -1, -1, -1, -1, -1, -1, -1,  0, -1, -1, -2, -1, -1, -1, -1, -1, -1 },
            { -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1 },
            { -1, -2, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -2, -1 },
            { -1, -3, -1, -1, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -2, -1, -1, -1, -1, -3, -1 },
            { -1, -2, -2, -2, -1, -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1, -1, -2, -2, -2, -1 },
            { -1, -1, -1, -2, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -2, -1, -1, -1 },
            { -1, -1, -1, -2, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -2, -1, -1, -1 },
            { -1, -2, -2, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -1, -1, -2, -2, -2, -2, -2, -2, -1 },
            { -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1 },
            { -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1 },
            { -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -1 },
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }
        };
                        m = 0;
                        level++;
                        this.BackgroundImage = Image.FromFile(@"Board 3.bmp");
                        break;
                }

                switch (level)
                {
                    case 1: break;
                    case 2: randomGhost.Speed = 15; break;
                    case 3: directionGhost.Speed = 15; break;
                    case 4: randomGhost.Speed = 30; break;
                    case 5: directionGhost.Speed = 30; break;
                }

                
                schetchiksobrantochek = 0;
                label2.Text = "Уровень  " + Convert.ToString(level);
            }

            if (mode == "Смерть")
            {
                if (m == 1)
                {
                    timer1.Interval = 16;
                    mode = "Готовность";
                    m = 0;
                    pacman.lives--;
                }
                else if (m == 0)
                {
                    timer1.Interval = 3500;
                    m++;
                }

                this.Refresh();
            }

            if (mode == "Готовность")
            {
                timer1.Interval = 2000;
                directionGhost.X = 14;
                directionGhost.Y = 14;
                randomGhost.X = 13;
                randomGhost.Y = 14;
                pacman.X = 13;
                pacman.Y = 17;
                pacman.Direction = null;
                pacman.LastDirection = null;
                Direction = null;                               

                if (pacman.lives <= 0) Environment.Exit(0);

                this.Refresh();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}