using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = GenerateArray();
            PrintArray(A);
            Console.WriteLine(GetSumOfNonNegativeElements(A));
        }
        static int[] GenerateArray()
        {
            int[] arr = new int[10];
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-10,10);
            }
            return arr;
        }
        static void PrintArray(int[] arr)
        {
            foreach (int x in arr)
            {
                Console.WriteLine(x);
            }
        }
        static int GetSumOfNonNegativeElements( int[] mas)
        {
            int sum = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 0)
                {
                    sum = sum + mas[i];
                }
                
            }
            return sum;

        }
    }
}
