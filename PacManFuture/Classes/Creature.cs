using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PacManFuture.Classes
{
    abstract class Creature
    {
        public uint Speed = 0;
        public int X = 0;
        public int Y = 0;
        public bool CanMove = false;
        public string o = "1";
        public bool DirectionCanChange { get; set; } = false;
        public string Direction { get; set; } = "UNDEFINED";
        public byte lives = 3;
        public string mode = "ATTACK";

        public const int n = 20;

        public Image imageRed;
        public Image imageCyan;
        public Image imagePink;

        public Image imageFruit;

        public virtual void Draw(Graphics formGraphics) { }
        public virtual void Move(ref int[,] mas) { }
        public virtual void Move(string Direction, ref int[,] mas) { }
        
       // public virtual

       // public virt


        
    }
}
