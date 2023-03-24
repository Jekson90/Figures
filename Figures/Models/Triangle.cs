namespace Figures.Models
{
    //здесь немного больше кода, потому что сам объект посложнее
    public class Triangle : FigureBase
    {
        public Triangle(List<double> sides) : base(sides)
        {
            if (sides.Count != 3)
                throw new ArgumentException("Triangle can have onle 3 edges.");

            if (A + B < C ||
                A + C < B ||
                B + C < A)
                throw new ArgumentException("Impossible triangle.");
        }

        public double A => Edges[0];
        public double B => Edges[1];
        public double C => Edges[2];

        public override double GetSquare()
        {
            var p = GetPerimeter() / 2.0;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public bool IsRectangular()
        {
            return A * A + B * B == C * C ||
                   A * A + C * C == B * B ||
                   B * B + C * C == A * A;
        }
    }
}
