using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoDPointWithHash point1 = new TwoDPointWithHash(10, 10);
            TwoDPointWithHash point2 = new TwoDPointWithHash(10, 1);
            TwoDPointWithHash point3 = new TwoDPointWithHash(1, 10);

            Console.WriteLine(point1.GetHashCode());
            Console.WriteLine(point2.GetHashCode());
            Console.WriteLine(point3.GetHashCode());
        }
    }
}
