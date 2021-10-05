using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Round round1 = new Round(10, 2, -3);
            Console.WriteLine($"Площадь круга : {round1.Area}");
            Console.WriteLine($"Длина окружности : {round1.Circumference}");
            Console.WriteLine(round1.Y);
            
        }

        public class Round
        {
            public int Radius { get; }
            public int X { get; set; }
            public int Y { get; set; }
            public virtual double Circumference
            {
                get { return 2 * Math.PI * Radius; }
            }
            public virtual double Area
            {
                get { return Math.PI * Radius * Radius; }
            }

            public Round(int r, int x, int y)
            {
                if (r <= 0) { throw new Exception("Недопустимый радиус окружности"); }
                Radius = r;
                X = x;
                Y = y;
            }
        }
    }
}
