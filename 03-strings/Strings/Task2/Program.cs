using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку");
            string s1 = Console.ReadLine();
            Console.WriteLine("Введите втрую строку строку");
            string s2 = Console.ReadLine();
            string answer = DoubleLetters(s1, s2);
            Console.WriteLine(answer);
        }
        static string DoubleLetters(string s1, string s2)
        {
            string s3 ="";
            for (int i = 0; i < s1.Length; i++)
            {
                if (s2.Contains(s1[i]))
                {
                    s3 = s3+ s1[i]+ s1[i];

                }
                else
                {
                    s3 = s3 + s1[i];
                }
            }
            return s3;


        }
    }
}
