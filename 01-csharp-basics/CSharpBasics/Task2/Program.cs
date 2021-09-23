using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Введите число N, большее 0");
            int N = Convert.ToInt32(Console.ReadLine());
           
            if (N <= 0)
            {
                Console.WriteLine("N должно быть больше 0");
                N = Convert.ToInt32(Console.ReadLine());
            }
            string s = "";
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(s= s+"*");
            }
        }
    }
}
