using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            GeometricalProgression ser1 = new GeometricalProgression(1, 2);
            ISeries ser2= (ISeries) ser1;
            PrintSeries(ser1, 10);
           
        }
        public interface ISeries
        {
            double GetCurrent();
            bool MoveNext();
            void Reset();
        }
        class GeometricalProgression : ISeries
        {
            double start, step;int index;
            public GeometricalProgression(double start, double step)
            {
                this.start = start;
                this.step = step;
                this.index = 1;
            }
            public double GetCurrent()
            {
                return start * Math.Pow(step, index);
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
        public static void PrintSeries(ISeries series, int n)
        {
            series.Reset();
            for (int i=0; i<n; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
            }
        }

    }
}
