namespace Figures.Exceptions
{
    //добавим свое исключение, что бы ловить именно его, при необходимости
    public class FigureTypeException : Exception
    {
        public FigureTypeException() : base()
        {
            
        }

        public FigureTypeException(string? message) : base(message)
        {
            
        }

        public FigureTypeException(string? message, Exception ex) : base(message, ex)
        {
            
        }
    }
}
