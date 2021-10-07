using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure[] fig = new Figure[5];
            fig[0] = new Rectangle(5,10);
            fig[1] = new Circle(5,0,0);
            fig[2] = new Round(6, 1,1);
            fig[3] = new Ring(5, 0,0,4);
            fig[4] = new Line(5);
            for(int i = 0; i<fig.Length; i++)
            {
                fig[i].Draw();
            }
            Round round = (Round)fig[2];
            Circle circle = (Circle)fig[1];
            Ring ring = (Ring)fig[3];
            Console.WriteLine(ring.Circumference);
            Console.WriteLine(circle.Circumference);
            Console.WriteLine(round.Radius);
            
        }
    }
    class Figure
    {
        public virtual void Draw() { }
    }
    class Rectangle:Figure
    {
        public double Width { get;  }
        public double Height { get; }
        public Rectangle(double a, double b)
        {
            if (a <= 0) { throw new Exception("Недопустимая высота прямоугольника"); }
            if (b <= 0) { throw new Exception("Недопустимая ширина прямоугольника"); }
            Width = b;
            Height = a;
        }
        public override void Draw()
        {
            Console.WriteLine($"Это прямоугольник со сторонами {Height} и {Width}");
        }
    }
    class Line : Figure
    {
        public double Length { get;  }
        public Line(double a)
        {
            if (a <= 0) { throw new Exception("Недопустимая длина линии"); }
            Length = a;
        }
        public override void Draw()
        {
            Console.WriteLine($"Это линия длинной {Length} ");
        }
    }
    class Circle:Figure
    {
        public double Radius { get;  }
        public double X { get; set; }
        public double Y { get; set; }
        public virtual double Circumference
        {
            get { return 2 * Math.PI * Radius; }
        }
        public Circle(double r, double x, double y)
        {
            if (r <= 0) { throw new Exception("Недопустимый радиус окружности"); }
            Radius = r;
            X = x;
            Y = y;
        }
        public override void Draw()
        {
            Console.WriteLine($"Это окружность с радиусом {Radius} и центром в точке ({X},{Y})");
        }

    }
    class Round : Circle
    {
        public virtual double Area
        {
            get { return Math.PI * Radius * Radius; }
        }
        public Round(double r, double x, double y) : base(r, x, y) { }
        public override void Draw()
        {
            Console.WriteLine($"Это круг с радиусом {Radius} и центром в точке ({X},{Y})");
        }
    }
    class Ring : Round
    {
        public double InnerRadius { get;  }
        public override double Circumference
        {
            get { return base.Circumference + 2 * Math.PI * InnerRadius; }
        }
        public override double Area
        {
            get { return base.Area - Math.PI * InnerRadius * InnerRadius; }
        }
        public Ring(double r, double x, double y, double ir) : base(r, x, y)
        {
            if (ir >= r) { throw new Exception("Недопустимый внутренний радиус окружности"); }
            InnerRadius = ir;
        }
        public override void Draw()
        {
            Console.WriteLine($"Это кольцо с внешним радиусом {Radius}, внутренним радиусом {InnerRadius} и центром в точке ({X},{Y})");
        }
    }

}
