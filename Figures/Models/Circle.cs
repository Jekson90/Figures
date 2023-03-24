namespace Figures.Models
{
    //добавим класс "Круга"
    //видно, что тут требуется минимальная реализация, т.к. все реализовано в базовом классе
    public class Circle : FigureBase
    {
        public Circle(double radius) : base(new List<double> { radius }) { }

        public double Radius => Edges.First();

        public override double GetSquare() => Math.PI * Math.Pow(Radius, 2);
    }
}
