using System;
using System.Text.RegularExpressions;
namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            string number = Console.ReadLine();
            CheckNumberFormat(number);
        }
        static void CheckNumberFormat(string number)
        {
            string patternOfExp = @"(-?\d+)\.?\d+(e-|e\+|e)\d+";
            string pattern = @"(\s|^)(-?\d+)\.?\d*(\s|$)";
            if (Regex.IsMatch(number, patternOfExp, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Это число в научной нотации");
            }
            else if (Regex.IsMatch(number, pattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Это число в обычной нотации");
            }
            else
            {
                Console.WriteLine("Это не число");
            }
           
            
        }
    }
}
