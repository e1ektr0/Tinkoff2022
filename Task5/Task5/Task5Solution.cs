using Common;

namespace Task5;

public class Task5Solution : IConsoleTest
{
    public void Process(TextReader textReader, TextWriter textWriter)
    {
        var strings = textReader.ReadLine()!.Split();
        var n = int.Parse(strings[0]); //колличество городов
        var m = int.Parse(strings[1]); //колличество рейсов
        bool[] odds = new bool [m]; //чётность маршрута
        int[] possibleEdge = new int [m * 2]; //маршруты
        bool[] airportOdds = new bool[n]; //нужна чётность аэропрта
        airportOdds = new[] { true, true, true, true };
        //у маршрута есть чётность
        //можно выбрать чётность аэропорта
        for (int i = 0; i < m; i++)
        {
            var enumerable = textReader.ReadLine()!.Split(); //ui vi ti
            odds[i] = enumerable[2] == "1";
            possibleEdge[i * 2] = int.Parse(enumerable[0]);
            possibleEdge[i * 2 + 1] = int.Parse(enumerable[1]);
        }
        
        //Построить графф - каждый аэропорт 2 узла(чётный и не чётный)
        //Найти длиннейший путь. На основе этого выбрать чётность аэропортов(что бы остался только длинный путь)?  
        //Выключить аэропорты, и снова найти кратчайши путь для ксюши - путя нет. -1. В против случаее распечатать его.
        
    }
}