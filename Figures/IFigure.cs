namespace Figures
{
    //работать с интерфейсами всегда удобнее, чем привязываться к конкретному классу
    //правда они требуют проработки архитектуры, иначе влекут большое количество доработок при изменении этой архитектуры
    public interface IFigure
    {
        /// <summary>
        /// Вычисление периметра фигуры
        /// </summary>
        /// <returns></returns>
        double GetPerimeter();
        /// <summary>
        /// Вычисление площади фигуры
        /// </summary>
        /// <returns></returns>
        double GetSquare();
    }
}
