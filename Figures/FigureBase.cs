using System.Text;

namespace Figures
{
    //базовый класс, который помогает избегать повторяемости кода
    //базовая часть класса обернута простыми тестами, но можно написать еще много тестов
    //и не весь фунционал протестирован

    //так же удобно расширять библиотеку добавляя другие абстрактные классы, работающие по другой логике
    //например расчет площади/периметра и др. через координаты вершин, а не стороны, или через углы и длины сторон
    public abstract class FigureBase : IFigure
    {
        protected List<double> Edges { get; }

        public FigureBase(List<double> edges)
        {
            if (edges == null) 
                throw new ArgumentNullException("Null value of Edges.");

            if (edges.Count == 0 || edges.Count == 2)
                throw new ArgumentException("Edges can't have 0 or 2 values.");

            foreach (var edge in edges)
                if (edge <= 0)
                    throw new ArgumentException("Edges must be bigger than 0.");

            Edges = edges;
        }

        public virtual double GetPerimeter()
        {
            return Edges.Count switch
            {
                0 => throw new ArgumentNullException("Edges can't be empty."),
                1 => 2 * Math.PI * Edges.First(),
                2 => throw new ArgumentException("Edges can't have 2 values."),
                _ => Edges.Sum(x => x)
            };
        }

        //одно из заданий: "Вычисление площади фигуры без знания типа фигуры в compile-time"
        //как я понял это абстрактный медод, реализация которого не известна до момента компиляции
        //и будет подставлена уже во время выполнения конкретной реализацией
        public abstract double GetSquare();

        /// <summary>
        /// Проверка, что прямоугольник правильный, т.е. все стороны равны
        /// </summary>
        /// <returns></returns>
        public bool IsRight()
        {
            if (Edges.Count == 1) 
                return true;

            for (int i = 0; i < Edges.Count - 1; i++)
                for (int j = i + 1; j < Edges.Count; j++)
                    if (Edges[j] != Edges[i])
                        return false;

            return true;
        }

        /// <summary>
        /// Сравнение с другой фигурой без учета углов между сторонами
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(FigureBase? other)
        {
            if (other == null)
                return false;

            foreach (var edge in Edges)
                if (!other.Edges.Contains(edge))
                    return false;

            foreach(var edge in other.Edges)
                if (!Edges.Contains(edge)) 
                    return false;

            return true;
        }

        public override string ToString()
        {
            StringBuilder output = new();
            output.Append($"This figure has {Edges.Count} edges.\n");

            for (int i = 0; i < Edges.Count; i++)
                output.Append($"    edge{i + 1} = {Math.Round(Edges[i], 3)}\n");

            string isRight = IsRight() ? "is" : "isn't";
            output.Append("  This figure " + isRight + " right\n");
            output.Append($"  Perimeter = {Math.Round(GetPerimeter(), 3)}\n");
            output.Append($"  Square = {Math.Round(GetSquare(), 3)}\n");

            return output.ToString();
        }
    }
}