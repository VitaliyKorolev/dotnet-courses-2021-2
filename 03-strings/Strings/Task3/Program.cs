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
            Console.WriteLine("Date: " + DateTime.Now.ToString(cul1) + " Float: " + 1.35343.ToString(cul1));
            Console.WriteLine("Date: " + DateTime.Now.ToString(cul2) + " Float: " + 1.35343.ToString(cul2));
        }
        static void CultureComparison(CultureInfo cul1)
        {
            Console.WriteLine("Date: " + DateTime.Now.ToString(cul1) + " Float: " + 1.35343.ToString(cul1));
            Console.WriteLine("Invariant Date: " + DateTime.Now.ToString(CultureInfo.InvariantCulture) + " Float: " + 1.35343.ToString(CultureInfo.InvariantCulture));
        }
    }

}
