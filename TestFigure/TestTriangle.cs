using Figures.Models;

namespace TestFigure
{
    public class TestTriangle
    {
        private const double a = 10;
        private const double b = 11;
        private const double c = 12;

        private List<double> GetSides() => new List<double> { a, b, c };

        /// <summary>
        /// Вспомогательный метод, что бы не писать каждый раз создание объекта
        /// </summary>
        /// <returns></returns>
        private Triangle GetTriangle() => new Triangle(GetSides());

        [TestCase(0)]
        [TestCase(-1)]
        public void TestIncorrectCreation(double side)
        {
            var sides = GetSides();
            sides[0] = side;
            Assert.Throws<ArgumentException>(() => new Triangle(sides));
        }

        [Test]
        public void TestSideReturn()
        {
            var triangle = GetTriangle();
            var sides2 = new List<double> { triangle.A, triangle.B, triangle.C };
            Assert.IsTrue(sides2.Contains(a));
            Assert.IsTrue(sides2.Contains(b));
            Assert.IsTrue(sides2.Contains(c));
        }

        [Test]
        public void TestGetTrianglePerimeter()
        {
            var triangle = GetTriangle();
            var perimeter = GetSides().Sum(x => x);
            //сложно сравнивать даблы - округлим
            Assert.That(Math.Round(triangle.GetPerimeter(), 5), Is.EqualTo(Math.Round(perimeter, 5)));
        }

        [Test]
        public void TestGetTriangleSquare()
        {
            var triangle = GetTriangle();
            var p = triangle.GetPerimeter() / 2.0;
            var square = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            //сложно сравнивать даблы - округлим
            Assert.That(Math.Round(triangle.GetSquare(), 5), Is.EqualTo(Math.Round(square, 5)));
        }

        [TestCase(3, 4, 5)]
        [TestCase(3, 5, 4)]
        [TestCase(4, 3, 5)]
        [TestCase(4, 5, 3)]
        [TestCase(5, 4, 3)]
        [TestCase(5, 3, 4)]
        public void TestTriangleIsRectangular(double a1, double b1, double c1)
        {
            var sides = new List<double> { a1, b1, c1 };
            var triangle = new Triangle(sides);
            Assert.IsTrue(triangle.IsRectangular());
        }

        [Test]
        public void TestSquareIsRight()
        {
            var sides = new List<double> { a, a, a };
            var triangle = new Triangle(sides);
            Assert.IsTrue(triangle.IsRight());
        }

        [Test]
        public void TestEqualsCircles()
        {
            var triangle1 = GetTriangle();
            var triangle2 = new Triangle(GetSides());
            Assert.IsTrue(triangle1.Equals(triangle2));
        }
    }
}
