using Figures.Exceptions;
using Figures.Models;

namespace Figures.Utils
{
    //один из стандартных способов получения объекта заданного интерфейса
    public class FigureFactory
    {
        //часть функционала библиотеки не обернута тестами, потому что для данного формата библиотеки
        //это не является острой необходимостью, но занимает много времени
        public static IFigure GetRightFigure(double sideLength, int sidesCount)
        {
            var type = (FigureType)(sidesCount - 1);

            return type switch
            {
                FigureType.Circle => new Circle(sideLength),
                FigureType.Square => new Square(sideLength),
                FigureType.Triangle => new Triangle(new List<double> { sideLength, sideLength, sideLength }),
                _ => throw new FigureTypeException($"Unsupported fugure type. It can't have {sidesCount} edges.")
            };
        }
    }
}
