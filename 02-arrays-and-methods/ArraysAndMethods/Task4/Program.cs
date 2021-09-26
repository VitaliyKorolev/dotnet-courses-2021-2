using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] A = GenerateArray();
            PrintArray(A);
            Console.WriteLine(GetSumOfElementsOnEvenPositions(A));
        }

        static int[,] GenerateArray()
        {
            int[,] arr = new int[2, 5];
            Random r = new Random();
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
                {
                    arr[i, j] = r.Next(-10, 10);  
                }

            }
            return arr;
        }
        static void PrintArray(int[,] arr)
        {
            foreach (int x in arr)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();
        }
        static int GetSumOfElementsOnEvenPositions( int[,] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
                {
                    
                        if ((i+j) % 2 == 0)
                        {
                            sum = sum +arr[i, j] ;
                        }
                    
                }

            }
            return sum;

        }
    }
}
