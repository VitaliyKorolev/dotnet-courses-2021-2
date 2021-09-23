using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for(int i=1; i<1000; i++)
            {
                if(i % 3==0 || i % 5 == 0)
                {
                    count = count + i;
                }

            }
            Console.WriteLine(count);
        }
    }
}
