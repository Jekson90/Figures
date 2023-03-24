using Figures.Utils;

namespace FigureConsole
{
    public class FigureGenerator : IDisposable
    {
        private const int SleepingTime = 2000;
        private readonly int _count = 0;
        private Random _random = new Random();
        private CancellationTokenSource? _cts;

        public event Action<string?>? Print;

        public FigureGenerator(int count = 0)
        {
            _count = count;
        }

        /// <summary>
        /// Асинхронный метод запуска генерации фигур
        /// </summary>
        /// <returns></returns>
        public async Task StartGeneratorAsync() => await Task.Factory.StartNew(Generator);

        private void Generator()
        {
            //токен отмены, может работать некорректно если запускать несколько генераторов, требуется доработка
            _cts = new CancellationTokenSource();
            //если в конструкторе пришло значение "0 циклов генерации", то генератор будет псевдобесконечным
            var counter = _count <= 0 ? int.MaxValue : _count;

            while (counter > 0 && !_cts.IsCancellationRequested)
            {
                //количество сторон может меняться в диапазоне 0-5, больше не поставил,
                //так как иначе будут редко попадать успешные фигуры
                var sidesCount = _random.Next(0, 5);
                //длина стороны сделана отрицательно, что бы видеть сообщение о неправильности ее длины
                var sideLength = _random.Next(-5, 100);
                string message;

                try
                {
                    var figure = FigureFactory.GetRightFigure(sideLength, sidesCount);
                    message = figure.ToString() ?? string.Empty;
                }
                catch (Exception ex)
                {
                    message = ex.Message + "\n";
                }

                Print?.Invoke(message);
                counter--;
                Thread.Sleep(SleepingTime);
            }

            _cts = null;
        }

        public void Dispose()
        {
            _cts?.Cancel();
        }
    }
}
