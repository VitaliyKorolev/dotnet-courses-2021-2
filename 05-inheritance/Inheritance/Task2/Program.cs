using System;
using MyLibrary;
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Ring ring = new Ring(10, 0, 0, 5);
            Console.WriteLine(ring.Area+"   "+ring.Circumference);
            Round round = new Ring(10, 0, 0,5);
            
            round = (Ring)round;
            Console.WriteLine(((Ring)round).Area + "   " + ((Ring)round).Circumference);

        }
    }
    class Ring : Round
    {
        public int InnerRadius { get;  }
        public new double Circumference { get; }
        public new double Area { get; }
    
        public Ring(int r, int x, int y, int ir):base( r,  x, y)
        {
            if (ir >= r) { throw new Exception("Недопустимый внутренний радиус окружности"); }
            InnerRadius = ir;
            Area = Math.PI * r * r - Math.PI * ir * ir;
            Circumference = 2 * Math.PI * r + 2 * Math.PI * ir;
        }

    }
}
