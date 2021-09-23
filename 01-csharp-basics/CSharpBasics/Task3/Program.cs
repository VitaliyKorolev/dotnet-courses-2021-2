using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Введите число N, большее 0");
            int NumberOfLines = int.Parse(Console.ReadLine());

            if (NumberOfLines <= 0)
            {
                Console.WriteLine("N должно быть больше 0");
                NumberOfLines = Convert.ToInt32(Console.ReadLine());
            }
            for(int i=0; i< NumberOfLines; i++)
            {
                for (int j = NumberOfLines-1; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j<=i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }  
            
        }
    }
}
