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
            string result = ReplaceHTMLTags(s1);
            Console.WriteLine("Результат замены: "+result);
        }
        static string ReplaceHTMLTags(string s)
        {
            string pattern = @"<.+?>";
            string target = "_";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(s, target);
            return result;
        }
    }
}
