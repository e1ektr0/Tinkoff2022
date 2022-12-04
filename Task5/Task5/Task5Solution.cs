using Common;

namespace Task5;

public class Task5Solution : IConsoleTest
{
    private class AirportVertex
    {
        public int AirportNumber;
        public byte EvenOdd;
    }

    //Построить графф - каждый аэропорт 2 узла(чётный и не чётный)
    //Найти длиннейший путь. На основе этого выбрать чётность аэропортов(что бы остался только длинный путь)?  Гарантированно длиннейший?
    //Хранить 2 дистанции? ВОзможно множественные пути? 
    //Выключить аэропорты, и снова найти кратчайши путь для ксюши - путя нет. -1. В против случаее распечатать его.


    //Найти крайтчайшие пути, и в обратном порядке уничтожать их. Но можно ли полагаться на это?
    //Возможно уничтожение кратчайшего в ближайшее время преведёт к ошибке в дальнейшем. Придумать сценарий! Такого сценария нет!
    //Надо уничтожать кратчайший!
    public void Process(TextReader textReader, TextWriter textWriter)
    {
        var strings = textReader.ReadLine()!.Split();
        var n = int.Parse(strings[0]); //колличество городов
        var m = int.Parse(strings[1]); //колличество рейсов

        var listVertex = new List<AirportVertex>?[n]; //airport->next->odd\even
        var listVertexPrev = new List<int>?[n]; //airport->prev

        PrepareGraph(textReader, m, listVertex);

        int[] distance = new int[n];
        bool[] visited = new bool[n];
        var queue = new Queue<int>();
        queue.Enqueue(0);
        while (queue.TryDequeue(out var currentIndex))
        {
            if (visited[currentIndex])
                continue;
            visited[currentIndex] = true;

            var edges = listVertex[currentIndex];
            if (edges != null)
                foreach (var edge in edges)
                {
                    var nextDistance = distance[edge.AirportNumber];
                    var possibleDistance = distance[currentIndex] + 1;
                    if (nextDistance != 0 && possibleDistance >= nextDistance)
                        continue;

                    distance[edge.AirportNumber] = possibleDistance;
                    listVertexPrev[edge.AirportNumber] ??= new List<int>(2);
                    listVertexPrev[edge.AirportNumber]!.Add(currentIndex);
                    queue.Enqueue(edge.AirportNumber);
                }
        }


        var backPathIndex = n - 1;
        bool[] result = new bool[n];
        int minPath = distance[backPathIndex];
        while (backPathIndex > 0)
        {
            foreach (var list in listVertexPrev)
            {
                //найти наикратчайший путь.
                //уничтожить его(пометить ноду что она определённого типа - будет использоваться в ответе)
                //увеличить общий путь до разницы с новым наименьшим - будет использоваться в ответе
                //установить backPathIndex = новый путь
                //если такого пути нет - то гг. -1, остальные значения не важны
            }
        }
    }

    private static void PrepareGraph(TextReader textReader, int m, List<AirportVertex>?[] airportVertices)
    {
        for (int i = 0; i < m; i++)
            ProcessLine(textReader, airportVertices);
    }

    private static void ProcessLine(TextReader textReader, List<AirportVertex>?[] airportVertices)
    {
        var enumerable = textReader.ReadLine()!.Split(); //ui vi ti
        var airportStartIndex = int.Parse(enumerable[0]) - 1;
        var airportEndIndex = int.Parse(enumerable[1]) - 1;
        airportVertices[airportStartIndex] ??= new List<AirportVertex>(2);
        var airportVertex = airportVertices[airportStartIndex]!;
        var existVertex = FindVertex(airportVertex, airportEndIndex);
        existVertex.AirportNumber = airportEndIndex;
        if (enumerable[2] == "1")
        {
            existVertex.EvenOdd += 2;
        }
        else
        {
            existVertex.EvenOdd += 1;
        }
    }

    private static AirportVertex FindVertex(List<AirportVertex> airportVertex, int airportEndIndex)
    {
        AirportVertex? existVertex = null;
        foreach (var vertex in airportVertex)
        {
            if (vertex.AirportNumber == airportEndIndex)
            {
                existVertex = vertex;
            }

            break;
        }

        if (existVertex == null)
        {
            existVertex = new AirportVertex();
            airportVertex.Add(existVertex);
        }

        return existVertex;
    }
}