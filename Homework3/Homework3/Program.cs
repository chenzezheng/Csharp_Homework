using System;

namespace Homework3
{
    class ShapeException : Exception
    {
        public ShapeException(string message) : base(message)
        {
        }
    }
    interface Shape
    {
        public double GetArea();
        public bool IsLegal();
    }
    class Rectangle : Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public Rectangle (double w, double h)
        {
            Width = w;
            Height = h;
            if (!IsLegal())
            {
                throw new ShapeException(message: "Illegal Rectangle");
            }
        }
        public double GetArea()
        {
            return Width * Height;
        }
        public bool IsLegal()
        {
            return Width > 0 && Height > 0;
        }
    }

    class Square : Shape
    {
        public double Edge { get; private set; }
        public Square(double e)
        {
            Edge = e;
            if (!IsLegal())
            {
                throw new ShapeException(message: "Illegal Square");
            }
        }
        public double GetArea()
        {
            return Edge * Edge;
        }
        public bool IsLegal()
        {
            return Edge > 0;
        }
    }

    class Triangle : Shape
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public Triangle (double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
            if (!IsLegal())
            {
                throw new ShapeException(message: "Illegal Triangle");
            }
        }
        public double GetArea()
        {
            double p = (A + B + C) / 2.0;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public bool IsLegal()
        {
            return (A > 0 && B > 0 && C > 0 && A + B > C && A + C > B && B + C > A);
        }
    }
    class Factory
    {
        public static Shape CreateShapeRandomly(string name)
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            Shape someShape = null;
            switch(name)
            {
                case "Rectangle":
                    double w = ran.NextDouble() * 100;
                    double h = ran.NextDouble() * 100;
                    someShape = new Rectangle(w, h);
                    break;
                case "Square":
                    double e = ran.NextDouble() * 100;
                    someShape = new Square(e);
                    break;
                case "Triangle":
                    double a = ran.NextDouble() * 100;
                    double b = ran.NextDouble() * 100;
                    double c = ran.NextDouble() * 100;
                    someShape = new Triangle(a, b, c);
                    break;
            }
            Console.WriteLine($"Create a {name} with area of {someShape.GetArea()}");
            return someShape;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double totalArea = 0.0;
            string[] shapes = new string[] { "Rectangle", "Square", "Triangle" };
            Random ran = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 10; )
            {
                int index = ran.Next(0, 3);
                string shapeName = shapes[index];
                try
                {
                    Shape aShape = Factory.CreateShapeRandomly(shapeName);
                    totalArea += aShape.GetArea();
                    i++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            Console.WriteLine(totalArea);
        }
    }
}
