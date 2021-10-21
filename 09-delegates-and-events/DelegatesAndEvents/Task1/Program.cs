using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = new string[] { "aa", "baqqfgjfj", "abcd", "abch" };
            Compare compare = CompareStrings;
            Sort(s, compare);
            foreach(string el in s)
            {
                Console.WriteLine(el);
            }
        }
        public static int CompareStrings(string s1, string s2)
        {
            
            if (s1.Length == s2.Length)
            {
                for (int i = 0; i < s1.Length ; i++)
                {
                    if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return -1;
                    if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return 1;
                }
                return 0;
            }

            if (s1.Length > s2.Length) return 1;
            else return -1;
        }
        public delegate int Compare(string s1, string s2);

        public static void Sort(string[] mas, Compare compare)
        {
            int i = 0;
            while (i < mas.Length)
            {
                if (i == 0 || compare(mas[i - 1] , mas[i]) <= 0   )
                    ++i;
                else
                {
                    string tmp = mas[i];
                    mas[i] = mas[i - 1];
                    mas[i - 1] = tmp;
                    --i;
                }
            }
        }
    }
}
