using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PacManFuture.Classes
{
    class RandomGhost : Creature
    {

        private string LastDirection;
        private int coefficient = 0;
        
        
        public RandomGhost()
        {
            X = 13;
            Y = 14;
            Direction = "up";
            Speed = 10;
        }
        
        public override void Draw(Graphics formGraphics)
        {
            int dx = X * 20, dy = Y * 20;

            imageRed = Image.FromFile(@"Images/Red" + o + ".bmp");

            if (Direction == "left") dx = X * n - coefficient;
            else if (Direction == "right") dx = X * n + coefficient;
            else dx = X * n;

            if (Direction == "up") dy = Y * n - coefficient;
            else if (Direction == "down") dy = Y * n + coefficient;
            else dy = Y * n;

            formGraphics.DrawImage(imageRed, dx, 30+dy, 20,20);
        }

        public override void Move(ref int[,] mas)
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

            if(coefficient == 6 || coefficient == 16)
            {
                if (o == "1") o = "2";
                else o = "1";
            }

            
        }
    }
}
