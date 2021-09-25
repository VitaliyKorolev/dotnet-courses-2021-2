using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] A = GenerateArray();
            PrintArray(A);
            ReplacePositiveElementsWithZero(ref A);
            PrintArray(A);
        }


        static int[,,] GenerateArray()
        {
            int[,,] arr = new int[2, 3, 2];
            Random r = new Random();
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
                {
                    for (int k = 0; k < arr.GetUpperBound(2) + 1; k++)
                    {
                        arr[i, j, k] = r.Next(-10,10);
                    }
                }
                
            }
            return arr;
        }
        static void PrintArray(int[,,] arr)
        {
            foreach (int x in arr)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();
        }

        static void ReplacePositiveElementsWithZero(ref int[,,] arr)
        {
           
            
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
                {
                    for (int k = 0; k < arr.GetUpperBound(2) + 1; k++)
                    {
                       if( arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }

            }
           
        }
    }

}
