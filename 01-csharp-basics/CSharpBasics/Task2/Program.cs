using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Введите число N, большее 0");
            
            if (!int.TryParse(Console.ReadLine(), out int N))
           
            {
                Console.WriteLine("Wrong input");

            }

           
            while (N <= 0)
            {
                Console.WriteLine("N должно быть больше 0");
                if (!int.TryParse(Console.ReadLine(), out  N))

                {
                    Console.WriteLine("Wrong input");

                }
            }
            string s = "";
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(s= s+"*");
            }
        }
    }
}
