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
            int key;
            for (int i = 1; i < mas.Length; i++)
            {
                key = mas[i];
                int j = i - 1;
                while (j >= 0 && mas[j] > key)
                {
                    mas[j + 1] = mas[j];
                    j = j - 1;
                }
                mas[j + 1] = key;
            }
            MaxVale = mas[mas.Length - 1];
            MinValue = mas[0];

        }



    }   
}
