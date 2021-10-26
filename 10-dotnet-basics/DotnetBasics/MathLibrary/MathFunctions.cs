using System;

namespace MathLibrary
{
    public static class MathFunctions
    {
        public static long Factorial(int number)
        {
            if (number < 0) throw new ArgumentException("Число должно быть больше нуля");
            if (number == 0 || number == 1) return 1;

            return Factorial(number - 1) * number;

        }
        public static double Power(double x, double y)
        {
            
            return Math.Exp(Math.Log(x)* y);
        }

    }
}
