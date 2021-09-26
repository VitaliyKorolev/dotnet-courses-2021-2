using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = GenerateArray();
            int MaxValue;
            int MinValue;
            SortAndGetMinAndMaxValues(ref A, out MinValue, out MaxValue);
            PrintArray(A);
            
            Console.WriteLine(MinValue);
            Console.WriteLine(MaxValue);
        }

        static int[] GenerateArray()
        {
            int[] arr = new int[10];
            Random r = new Random();
            for (int i =0; i < arr.Length; i++)
            {
                arr[i] = r.Next(10);
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
        static void SortAndGetMinAndMaxValues(ref int[] mas,  out int MinValue, out int MaxVale)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            MaxVale = mas[mas.Length - 1];
            MinValue = mas[0];

        }



    }   
}
