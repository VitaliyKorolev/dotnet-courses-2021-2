using System;
using System.Text.RegularExpressions;
namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string s1 = Console.ReadLine();
            string pattern = @"<.+?>";
            string target = "_";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(s1, target);
            Console.WriteLine(result);
        }
    }
}
