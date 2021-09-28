using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = GenerateArray();
            SortAndGetMinAndMaxValues(a, out int minValue, out int maxValue);
            PrintArray(a);

            Console.WriteLine(minValue);
            Console.WriteLine(maxValue);
        }

        static int[] GenerateArray()
        {
            int[] arr = new int[10];
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(100);
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
        static void SortAndGetMinAndMaxValues(int[] mas, out int minValue, out int maxValue)
        {
            int i = 0;
            while (i < mas.Length)
            {
                if (i == 0 || mas[i - 1] <= mas[i])
                    ++i;
                else
                {
                    int tmp = mas[i];
                    mas[i] = mas[i - 1];
                    mas[i - 1] = tmp;
                    --i;
                }
            }
            maxValue = mas[mas.Length - 1];
            minValue = mas[0];
        }


    }   
}
