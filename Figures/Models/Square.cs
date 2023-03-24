namespace Figures.Models
{
    //добавим дополнительный класс для проверки, что библиотека легко-расширяемая
    //т.е. нужно просто добвить новый класс и переопределить требуемые методы
    //для более сложных объектов (многоугольники), возможно,
    //будет немного больше кода, но это уже проблема не архитектуры
    public class Square : FigureBase
    {
        public Square(double side) : base(new List<double> { side }) { }

        public double Side => Edges.First();

        public override double GetPerimeter() => Side * 4;

        public override double GetSquare() => Math.Pow(Side, 2);
    }
}
