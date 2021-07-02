using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PacManFuture.Classes
{
    class DirectionGhost : Creature
    {

        public string LastDirection = "UNDEFINED";
        public string NextDirection = "UNDEFINED";
        public int x_end = 0;
        public int y_end = 0;
        public int coefficient = 0;
        public int[,] mas_vsp = new int[31, 28];
        

        public DirectionGhost()
        {
            X = 14;
            Y = 14;
            Direction = "up";
            Speed = 10;
        }

        public override void Draw(Graphics formGraphics)
        {
            int dx = X * 20, dy = Y * 20;

            imageCyan = Image.FromFile(@"Images/Cyan" + o + ".bmp");

            if (Direction == "left") dx = X * n - coefficient;
            else if (Direction == "right") dx = X * n + coefficient;
            else dx = X * n;

            if (Direction == "up") dy = Y * n - coefficient;
            else if (Direction == "down") dy = Y * n + coefficient;
            else dy = Y * n;

            formGraphics.DrawImage(imageCyan, dx, 30+dy, 20, 20);
        }

        public override void Move(ref int[,] mas)
        {
            DirectionMove();
        }

        private void RandomMove(ref int[,] mas)
        {
            Random random = new Random();
            int NumberOfPossibleDirections;
            NumberOfPossibleDirections = 0;
            bool Boolean;
            Boolean = false;

            if (coefficient == 20)
            {
                coefficient = 0;
                {
                    if (mas[Y, X - 1] != -1) if (Direction == "left") X--;
                    if (mas[Y, X + 1] != -1) if (Direction == "right") X++;
                    if (mas[Y - 1, X] != -1) if (Direction == "up") Y--;
                    if (mas[Y + 1, X] != -1) if (Direction == "down") Y++;
                }
            }

            if (coefficient == 0)
            {

                Boolean = false;
                if (mas[Y - 1, X] != -1 || mas[Y + 1, X] != -1) NumberOfPossibleDirections++;
                if (mas[Y, X - 1] != -1 || mas[Y, X + 1] != -1) NumberOfPossibleDirections++;


                if (NumberOfPossibleDirections == 2) do switch (random.Next(1, 5))
                        {
                            case 1: //up
                                if (mas[Y - 1, X] != -1 && Direction != "down") { CanMove = true; Boolean = true; Direction = "up"; } else CanMove = false;
                                break;
                            case 2: //down
                                if (mas[Y + 1, X] != -1 && Direction != "up") { CanMove = true; Boolean = true; Direction = "down"; } else CanMove = false;
                                break;
                            case 3: //left
                                if (mas[Y, X - 1] != -1 && Direction != "right") { CanMove = true; Boolean = true; Direction = "left"; } else CanMove = false;
                                break;
                            case 4: //right
                                if (mas[Y, X + 1] != -1 && Direction != "left") { CanMove = true; Boolean = true; Direction = "right"; } else CanMove = false;
                                break;
                        } while (Boolean != true);
            }

            if (CanMove == true) coefficient += 2;

            if (coefficient == 6 || coefficient == 16)
            {
                if (o == "1") o = "2";
                else o = "1";
            }
    }

        private void DirectionMove()
        {
            if (coefficient == 20)
            {
                coefficient = 0;
               if (Direction == "left") X--;
               if (Direction == "right") X++;
               if (Direction == "up") Y--;
               if (Direction == "down") Y++;
            }

            if (coefficient == 0)
            {

                int x_start;
                int y_start;

                x_start = X;
                y_start = Y;

                mas_vsp[y_start, x_start] = -8;
                mas_vsp[y_end, x_end] = -9;

                bool breakneck = false;
                bool breaknock = false;
                breakneck = false;
                breaknock = false;

                if (mas_vsp[y_start + 1, x_start] == -9) { mas_vsp[y_end, x_end] = 0; mas_vsp[y_end + 1, x_end] = -9; y_end++; }
                if (mas_vsp[y_start - 1, x_start] == -9) { mas_vsp[y_end, x_end] = 0; mas_vsp[y_end - 1, x_end] = -9; y_end--; }
                if (mas_vsp[y_start, x_start + 1] == -9) { mas_vsp[y_end, x_end] = 0; mas_vsp[y_end, x_end + 1] = -9; x_end++; }
                if (mas_vsp[y_start, x_start - 1] == -9) { mas_vsp[y_end, x_end] = 0; mas_vsp[y_end, x_end -1] = -9; x_end--; }
                try
                { 
                int i = 2;

                if (mas_vsp[Y, X + 1] == 0) mas_vsp[Y, X + 1] = i;
                if (mas_vsp[Y, X - 1] == 0) mas_vsp[Y, X - 1] = i;

                if (mas_vsp[Y + 1, X] == 0) mas_vsp[Y + 1, X] = i;
                if (mas_vsp[Y - 1, X] == 0) mas_vsp[Y - 1, X] = i;

                int j = 0, k = 0;
                bool bool1 = false;
                    if (breaknock == false)
                    {
                        do
                        {
                            for (j = 1; j < 30 && breakneck == false; j++)
                            {
                                for (k = 1; k < 27 && breakneck == false; k++)
                                {
                                    if (mas_vsp[j, k] == i)
                                    {
                                        if (mas_vsp[j + 1, k] == -9) breakneck = true;
                                        if (mas_vsp[j - 1, k] == -9) breakneck = true;

                                        if (mas_vsp[j, k + 1] == -9) breakneck = true;
                                        if (mas_vsp[j, k - 1] == -9) breakneck = true;


                                        if (mas_vsp[j + 1, k] == 0) { mas_vsp[j + 1, k] = i + 1; }
                                        if (mas_vsp[j - 1, k] == 0) { mas_vsp[j - 1, k] = i + 1; }

                                        if (mas_vsp[j, k + 1] == 0) { mas_vsp[j, k + 1] = i + 1; }
                                        if (mas_vsp[j, k - 1] == 0) { mas_vsp[j, k - 1] = i + 1; }
                                    }
                                }
                                k = 0;
                            }
                            i++;

                            bool1 = false;
                        } while (breakneck == false);

                        breakneck = false;
                        mas_vsp[y_end, x_end] = -9;
                        i = 0;
                        do
                        {
                            i++;
                            if (mas_vsp[y_end + 1, x_end] == i) { mas_vsp[y_end + 1, x_end] = -5; break; }
                            else
                            if (mas_vsp[y_end - 1, x_end] == i) { mas_vsp[y_end - 1, x_end] = -5; break; }
                            else

                            if (mas_vsp[y_end, x_end + 1] == i) { mas_vsp[y_end, x_end + 1] = -5; break; }
                            else
                            if (mas_vsp[y_end, x_end - 1] == i) { mas_vsp[y_end, x_end - 1] = -5; break; }
                        } while (true);

                        breakneck = false;
                        mas_vsp[y_start, x_start] = -8;
                        do
                        {
                            for (j = 1; j < 30 && breakneck == false; j++)
                            {
                                for (k = 1; k < 27; k++)
                                {
                                    if (mas_vsp[y_start, x_start] == -5) breakneck = true;

                                    if (mas_vsp[j, k] == -5 && breakneck != true)
                                    {
                                        if (mas_vsp[j + 1, k] == i - 1 || mas_vsp[j + 1, k] == -8) { mas_vsp[j + 1, k] = -5; }
                                        if (mas_vsp[j - 1, k] == i - 1 || mas_vsp[j - 1, k] == -8) { mas_vsp[j - 1, k] = -5; }

                                        if (mas_vsp[j, k + 1] == i - 1 || mas_vsp[j, k + 1] == -8) { mas_vsp[j, k + 1] = -5; }
                                        if (mas_vsp[j, k - 1] == i - 1 || mas_vsp[j, k - 1] == -8) { mas_vsp[j, k - 1] = -5; }
                                    }
                                }
                            }
                            i--;
                        } while (breakneck != true);

                        if (mas_vsp[y_start + 1, x_start] == -5) { Direction = "down"; }
                        else
                        if (mas_vsp[y_start - 1, x_start] == -5) { Direction = "up"; }
                        else
                        if (mas_vsp[y_start, x_start + 1] == -5) { Direction = "right"; }
                        else
                        if (mas_vsp[y_start, x_start - 1] == -5) { Direction = "left"; }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    if (mas_vsp[y_start + 1, x_start] == 0) { Direction = "down"; }
                        else
                        if (mas_vsp[y_start - 1, x_start] == 0) { Direction = "up"; }
                    else
                        if (mas_vsp[y_start, x_start + 1] == 0) { Direction = "right"; }
                    else
                        if (mas_vsp[y_start, x_start - 1] == 0) { Direction = "left"; }
                }

            }
            coefficient += 2;

            if (coefficient == 6 || coefficient == 16)
            {
                if (o == "1") o = "2";
                else o = "1";
            }
        }
    }
}