using System;
using System.Text.RegularExpressions;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string s = Console.ReadLine();
            int counter = TimeCounter(s);
            Console.WriteLine($"В тексте время встречается {counter} раз(a)");
        }
        static int TimeCounter(string s)
        {
            Regex regex = new Regex(@"(\s|^)([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]");
            MatchCollection matches = regex.Matches(s);
            return matches.Count;
        }

    }
}
