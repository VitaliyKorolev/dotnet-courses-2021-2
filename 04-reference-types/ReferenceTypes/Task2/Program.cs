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

        class Round
        {
            public int Radius { get;  }
            public int X { get; set; }
            public int Y { get; set; }
            public double Circumference { get; }
            public double Area { get; }

            public Round(int r, int x, int y)
            {
                if(r<=0) { throw new Exception("Недопустимый радиус окружности"); }
                Radius = r;
                X = x;
                Y = y;
                Circumference = 2 * Math.PI * r;
                Area = Math.PI * r * r;
            }
            



        }
    }
}
