using System;
using System.Text;
using System.Diagnostics;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            StringBuilder sb = new StringBuilder();
            int N = 100000;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0}", ts.TotalMilliseconds );
           
            Stopwatch stopWatch1 = new Stopwatch();
            stopWatch1.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
            stopWatch1.Stop();
            TimeSpan ts1 = stopWatch1.Elapsed;
            string elapsedTime1 = String.Format("{0}", ts1.TotalMilliseconds );
            Console.WriteLine("String: " + elapsedTime);
            Console.WriteLine("StringBuilder: " + elapsedTime1);
        }
    }
}
