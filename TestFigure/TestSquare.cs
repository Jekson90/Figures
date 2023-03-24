using Figures.Models;

namespace TestFigure
{
    public class TestSquare
    {
        private const double side = 10;

        /// <summary>
        /// Вспомогательный метод, что бы не писать каждый раз создание объекта
        /// </summary>
        /// <returns></returns>
        private Square GetSquare() => new Square(side);

        [TestCase(0)]
        [TestCase(-1)]
        public void TestIncorrectCreation(double side)
        {
            Assert.Throws<ArgumentException>(() => new Square(side));
        }

        [Test]
        public void TestRadiusReturn()
        {
            var square = GetSquare();
            Assert.That(square.Side, Is.EqualTo(side));
        }

        [Test]
        public void TestGetSquarePerimeter()
        {
            var square = GetSquare();
            var perimeter = side * 4;
            //сложно сравнивать даблы - округлим
            Assert.That(Math.Round(square.GetPerimeter(), 5), Is.EqualTo(Math.Round(perimeter, 5)));
        }

        [Test]
        public void TestGetSquareOfSquare()
        {
            var Square = GetSquare();
            var square = side * side;
            //сложно сравнивать даблы - округлим
            Assert.That(Math.Round(Square.GetSquare(), 5), Is.EqualTo(Math.Round(square, 5)));
        }

        [Test]
        public void TestSquareIsRight()
        {
            var square = GetSquare();
            Assert.IsTrue(square.IsRight());
        }

        [Test]
        public void TestEqualsSquares()
        {
            var square1 = GetSquare();
            var square2 = new Circle(side);
            Assert.IsTrue(square1.Equals(square2));
        }
    }
}
