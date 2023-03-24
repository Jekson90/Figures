using FigureConsole;

/*
 
            ПРИМЕР РАБОТЫ С БИБЛИОТЕКОЙ Figure
 
 */


Console.WriteLine(" = Example for Figure.cs = \n");

string text = "Background task creating new random figure each 2 seconds.\n" +
              "It consists of N random equals edges witch have random length.\n" +
              "Then it's ptinting on console. It has enless cycle.\n" +
              "You can interrupt running by press \"Enter\" any time because console doesn't freeze.\n";
Console.WriteLine(text);
Console.WriteLine(exitMessage);

//запустим генератор, что бы рандомные фигуры генерировались автоматически раз в 2 сек
using (var generator = new FigureGenerator(100))
{
    generator.Print += Print;
    //вывод будет асинхронным и не блокирует консоль, на которой можно нажать Enter для остановки
    Task t = generator.StartGeneratorAsync();
    Console.ReadKey();
    generator.Dispose();
}        

//метод для отработки события Print в генераторе
static void Print(string? text)
{
    if (string.IsNullOrEmpty(text))
        text = "Generator return no message...\n";

    Console.WriteLine(text);
    Console.WriteLine(exitMessage);
}

public partial class Program
{
    private static readonly string exitMessage = "Press \"Enter\" for exit...\n";
}