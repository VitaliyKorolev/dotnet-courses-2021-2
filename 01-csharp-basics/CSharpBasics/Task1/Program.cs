using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Введите длинну и ширину прямоугольника чтобы узнать его площадь");
            double a = Convert.ToDouble(Console.ReadLine());
            if (a <= 0)
            {
                Console.WriteLine("a должно быть больше 0");
                Environment.Exit(0);
            }
            double b = Convert.ToDouble(Console.ReadLine());

            if (b <= 0)
            {
                Console.WriteLine("b должно быть больше 0");
                b = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine($"Площадь прямоугольника: {a * b} ");
        }
    }
}
