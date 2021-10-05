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
            Round round = new Round(10, 0, 0);
            Console.WriteLine(round.Area + "   " + round.Circumference);

        }
    }
    class Ring : Round
    {
        public int InnerRadius { get;  }
        public override double Circumference
        {
            get { return base.Circumference + 2 * Math.PI * InnerRadius; }
        }
        public  override double Area
        {
            get { return base.Area - Math.PI * InnerRadius * InnerRadius; }
        }
    
        public Ring(int r, int x, int y, int ir):base( r,  x, y)
        {
            if (ir >= r) { throw new Exception("Недопустимый внутренний радиус окружности"); }
            InnerRadius = ir;
        }

    }
}
