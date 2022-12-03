using Common;

namespace Task5;

public class Task5Solution : IConsoleTest
{
    public struct AirportVertex
    {
        public bool IsVisited;
        public int EdgeWeight;
        public List<int>? EvenEdges;
        public List<int>? OddEdges;
    }

    //Построить графф - каждый аэропорт 2 узла(чётный и не чётный)
    //Найти длиннейший путь. На основе этого выбрать чётность аэропортов(что бы остался только длинный путь)?  
    //Выключить аэропорты, и снова найти кратчайши путь для ксюши - путя нет. -1. В против случаее распечатать его.
    public void Process(TextReader textReader, TextWriter textWriter)
    {
        var strings = textReader.ReadLine()!.Split();
        var n = int.Parse(strings[0]); //колличество городов
        var m = int.Parse(strings[1]); //колличество рейсов
        var airportVertices = new AirportVertex[n];
        PrepareGraph(textReader, m, airportVertices);
    }

    private static void PrepareGraph(TextReader textReader, int m, AirportVertex[] airportVertices)
    {
        for (int i = 0; i < m; i++)
            ProcessLine(textReader, airportVertices);
    }

    private static void ProcessLine(TextReader textReader, AirportVertex[] airportVertices)
    {
        var enumerable = textReader.ReadLine()!.Split(); //ui vi ti
        var airportStartIndex = int.Parse(enumerable[0]) - 1;
        var airportEndIndex = int.Parse(enumerable[1]) - 1;
        if (enumerable[2] == "1")
        {
            airportVertices[airportStartIndex].OddEdges ??= new List<int>(1);
            airportVertices[airportStartIndex].OddEdges!.Add(airportEndIndex);
        }
        else
        {
            airportVertices[airportStartIndex].EvenEdges ??= new List<int>(1);
            airportVertices[airportStartIndex].EvenEdges!.Add(airportEndIndex);
        }
    }
}