using Figures.Models;

namespace TestFigure
{
    public class TestCircle
    {
        private const double radius = 10;

        /// <summary>
        /// ¬спомогательный метод, что бы не писать каждый раз создание объекта
        /// </summary>
        /// <returns></returns>
        private Circle GetCircle() => new Circle(radius);

        [TestCase(0)]
        [TestCase(-1)]
        public void TestIncorrectCreation(double radius)
        {
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }

        [Test]
        public void TestRadiusReturn()
        {
            var circle = GetCircle();
            Assert.That(circle.Radius, Is.EqualTo(radius));
        }

        [Test]
        public void TestGetCirclePerimeter()
        {
            var circle = GetCircle();
            var perimeter = Math.PI * 2 * radius;
            //сложно сравнивать даблы - округлим
            Assert.That(Math.Round(circle.GetPerimeter(), 5), Is.EqualTo(Math.Round(perimeter, 5)));
        }

        [Test]
        public void TestGetCircleSquare()
        {
            var circle = GetCircle();
            var square = Math.PI * radius * radius;
            //сложно сравнивать даблы - округлим
            Assert.That(Math.Round(circle.GetSquare(), 5), Is.EqualTo(Math.Round(square, 5)));
        }

        [Test]
        public void TestCircleIsRight()
        {
            var circle = GetCircle();
            Assert.IsTrue(circle.IsRight());
        }

        [Test]
        public void TestEqualsCircles()
        {
            var circle1 = GetCircle();
            var circle2 = new Circle(radius);
            Assert.IsTrue(circle1.Equals(circle2));
        }
    }
}