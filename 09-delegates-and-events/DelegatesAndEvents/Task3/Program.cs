using System;
using System.Threading;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            void Print(object sender, EventArgs e) { Console.WriteLine("Сортировка закончилась"); };
            string[] s1 = new string[] { "aa", "baqqfgjfj", "abcd", "abch" };
            string[] s2 = new string[] { "aa", "baq", "ahhhhhh", "aqwqwr" };
            Compare compare = CompareStrings;
            SortEnded += Print;

            Thread th1 = SortAsync(s2, compare);
            th1.Start();

            Sort(s1, compare);
            
            

            
           
        }
        public static int CompareStrings(string s1, string s2)
        {

            if (s1.Length == s2.Length)
            {
                for (int i = 0; i < s1.Length; i++)
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

        public static event EventHandler SortEnded;

        public static void Sort(string[] mas, Compare compare)
        {
            int i = 0;
            while (i < mas.Length)
            {
                if (i == 0 || compare(mas[i - 1], mas[i]) <= 0)
                    ++i;
                else
                {
                    string tmp = mas[i];
                    mas[i] = mas[i - 1];
                    mas[i - 1] = tmp;
                    --i;
                }
            }

            SortEnded?.Invoke( EventArgs.Empty, EventArgs.Empty);
        }
        public static Thread SortAsync(string[] mas, Compare compare)
        {
            Thread th = new Thread(() => Sort(mas, compare));

            return th;

        }
    }
}
