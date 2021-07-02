using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//using System.Timers;
using System.Threading;


namespace PacManFuture.Classes
{
    sealed class PacMan : Creature
    {

        //public int x = 0;
        //public int y = 0;

        public string LastDirection = "UNDEFINED";
        public string NextDirection = "UNDEFINED";
        public int coefficient = 0;
        public bool Energize = false;
        public PacMan()
        {
            X = 13;
            Y = 17;
            lives = 3;
            //Direction = "left";
            Speed = 30;
            DirectionCanChange = false;
        }

        public override void Draw(Graphics formGraphics)
        {
            int dx = X * 20, dy = Y * 20;

            SolidBrush myBrush = new SolidBrush(Color.Yellow);
            Image image = Image.FromFile(@"Images/Pacmanleft" + o + ".png");

            if (Direction == "left") image = Image.FromFile(@"Images/Pacmanleft" + o + ".png");
            if (Direction == "right") image = Image.FromFile(@"Images/Pacmanright" + o + ".png");
            if (Direction == "up") image = Image.FromFile(@"Images/Pacmanup" + o + ".png");
            if (Direction == "down") image = Image.FromFile(@"Images/Pacmandown" + o + ".png");


            if (Direction == "left") dx = X * n - coefficient;
            else if (Direction == "right") dx = X * n + coefficient;
            else dx = X * n;

            if (Direction == "up") dy = Y * n - coefficient;
            else if (Direction == "down") dy = Y * n + coefficient;
            else dy = Y * n;

            // formGraphics.FillEllipse(myBrush, dx, dy, 20, 20);
            formGraphics.DrawImage(image, dx, 30+dy, 20, 20);
        }

        public void FindYacheiki(ref int[,] mas, ref int ochki, ref int schetchiksobrantochek)
        {
            if (mas[Y,X] == -3)
            {
                ochki += 10;
                mas[Y, X] = 0;
                schetchiksobrantochek++;
            }
            else Energize = false;

            if (mas[Y,X] == -2)
            {
                mas[Y, X] = 0;
                ochki += 10;

                schetchiksobrantochek++;
            }
        }
        public override void Move(string DirectionIn, ref int[,] mas)
        {
            
            if (coefficient == 20)
            {
                coefficient = 0;
                if (CanMove == true) if (Direction == "left") X--;
                if (CanMove == true) if (Direction == "right") X++;
                if (CanMove == true) if (Direction == "up") Y--;
                if (CanMove == true) if (Direction == "down") Y++;
                
                //if (mas[Y, X] == 0) playNotEating.PlayLooping();
                //else playNotEating.Stop();

                //else { playNotEating.Dispose(); playNotEating.Stop();  }
                //if (play)
            }

                if (coefficient == 0)
            {
                

                switch (DirectionIn)
                {
                    case "up":
                        if (mas[Y - 1, X] != -1) { Direction = DirectionIn; CanMove = true; } else CanMove = false;
                        break;
                    case "down":
                        if (mas[Y + 1, X] != -1) { Direction = DirectionIn; CanMove = true; } else CanMove = false;
                        break;
                    case "left":
                        if (mas[Y, X - 1] != -1) { Direction = DirectionIn; CanMove = true; } else CanMove = false;
                        break;
                    case "right":
                        if (mas[Y, X + 1] != -1) { Direction = DirectionIn; CanMove = true; } else CanMove = false;
                        break;
                }

                if (CanMove != true) switch (Direction)
                    {
                        case "up":
                            if (mas[Y - 1, X] != -1) { CanMove = true; } else CanMove = false;
                            break;
                        case "down":
                            if (mas[Y + 1, X] != -1) { CanMove = true; } else CanMove = false;
                            break;
                        case "left":
                            if (mas[Y, X - 1] != -1) { CanMove = true; } else CanMove = false;
                            break;
                        case "right":
                            if (mas[Y, X + 1] != -1) { CanMove = true; } else CanMove = false;
                            break;
                    }

               
            }
            
            if (CanMove == true) coefficient += 2;

            if (coefficient == 6 || coefficient == 16)
            {
               if (o == "1") o = "2";
               else o = "1";
            }

        }

    }
}