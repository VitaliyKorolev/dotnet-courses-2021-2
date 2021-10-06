using System;
using System.Collections.Generic;
namespace Task3
{
    class Program
    {
         static void Main(string[] args)
        {
            IIndexableSeries ser1 = new ArithmeticalProgression(0, 2);
            double b = ser1[3];
            List<double> n = new List<double> { 1, 2, 3, 4, 5 };
            IIndexableSeries ser2 = new List(n);
            PrintIndexable(ser2, 5);

            PrintIndexable(ser1, 10);
        }
        public interface ISeries
        {
            double GetCurrent();
            bool MoveNext();
            void Reset();
            
        }
        public interface IIndexable:ISeries
        {
           public double this[int i] { get; }
        }
        interface IIndexableSeries: IIndexable { }
        public class ArithmeticalProgression : IIndexableSeries
        {
            double start, step; int index;
            public double this[int i] { get { return start + step * i; } }
            public ArithmeticalProgression (double start, double step)
            {
                this.start = start;
                this.step = step;
                this.index = 1;
            }
            public double GetCurrent()
            {
                return start +step*index;
            }
            public bool MoveNext()
            {
                index++; return true;
            }
            public void Reset()
            {
                index = 1;
            }
        }
        class List : IIndexableSeries
        {
            public List <double> numbers = new List<double>();
            int index=0;
            public double this[int i] { get { return numbers[i]; } }
            public List(List <double> n)
            {
                this.numbers = n;
            }
            public double GetCurrent()
            {
                return numbers[index];
            }
            public bool MoveNext()
            {
                index++; return true;
            }
            public void Reset()
            {
                index = 0;
            }
        }
        public static void PrintSeries(ISeries series, int n)
        {
            series.Reset();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
            }
        }
        public static void PrintIndexable(IIndexable series, int n)
        {
            series.Reset();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
            }
        }

    }
}
