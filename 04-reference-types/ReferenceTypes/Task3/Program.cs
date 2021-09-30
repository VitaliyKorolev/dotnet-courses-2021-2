using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle t1 = new Triangle(5, 4, 3);
            Console.WriteLine(t1.GetPerimetr());
            Console.WriteLine(t1.GetArea());
                
            
        }

        class Triangle
        {
            private int a;
            private int b;
            private int c;
            
            public int A 
            {
                get { return a; }
                private set
                {
                    if (value <= 0) {  throw new Exception("Сторона треугольника должна быть больше 0");  }
                    else { a = value; }
                }
            }
            public int B
            {
                get { return b; }
                private set
                {
                    if (value <= 0) { throw new Exception("Сторона треугольника должна быть больше 0"); }
                    else { b = value; }
                }
            }
            public int C
            {
                get { return c; }
                private set
                {
                    if (value <= 0) { throw new Exception("Сторона треугольника должна быть больше 0"); }
                    else { c = value; }
                }
            }
            public Triangle(int a, int b, int c)
            {
                if (a + b <= c || a + c <= b || b + c <= a) { throw new Exception("Не существует треугольника с такими сторонами"); }
                A = a; B = b; C = c;


            } 
            public int GetPerimetr()
            {
                return( a + b + c);
            }
            public double GetArea()
            {
                double s = (a + b + c) / 2;
                return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            }
        }
    }
}
