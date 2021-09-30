using System;
using System.Globalization;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo en = new CultureInfo("en-US", false);
            CultureInfo ru = new CultureInfo("ru-RU", false);
            CultureComparison(ru, en);
            CultureComparison(ru);
            CultureComparison(en);

        }

        static void CultureComparison(CultureInfo cul1, CultureInfo cul2)
        {
            PrintComparison(cul1);
            PrintComparison(cul2);
        }
        static void CultureComparison(CultureInfo cul1)
        {
            PrintComparison(cul1);
            PrintComparison(CultureInfo.InvariantCulture);
        }

        static void PrintComparison(CultureInfo culture)
        {
            Console.WriteLine("Date: " + DateTime.Now.ToString(culture) + " Float: " + 1.35343.ToString(culture));
        }
    }

}
