using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Введите число N, большее 0");
            int NumberOfTriangles = int.Parse(Console.ReadLine());

            if (NumberOfTriangles <= 0)
            {
                Console.WriteLine("N должно быть больше 0");
                NumberOfTriangles = Convert.ToInt32(Console.ReadLine());
            }
            for(int k=0; k<NumberOfTriangles;k++)
            {
                CreateTriangle(k+1, NumberOfTriangles - k-1);

            }
        }
        static void CreateTriangle(int N, int interval)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = N +interval - 1; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j <= i * 2; j++)
                {
                    Console.Write("*");

                }
                Console.WriteLine();
            }
        }

    }
}
