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
            int i = 0;
            int tmp;
            while (i < mas.Length)
            {
                if (i == 0 || mas[i - 1] <= mas[i])
                    ++i;
                else
                {
                    tmp = mas[i];
                    mas[i] = mas[i - 1];
                    mas[i - 1] = tmp;
                    --i;
                }
            }
            MaxVale = mas[mas.Length - 1];
            MinValue = mas[0];

        }



    }   
}
