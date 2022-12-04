using Common;

namespace Task5;

public class Task5Solution : IConsoleTest
{
    private class AirportVertex
    {
        public int AirportNumber;
        public byte EvenOdd;
    }

    //Найти крайтчайшие пути, и в обратном порядке уничтожать их. Но можно ли полагаться на это?
    //Возможно уничтожение кратчайшего в ближайшее время преведёт к ошибке в дальнейшем. Придумать сценарий! Такого сценария нет!
    //Надо уничтожать кратчайший!
    public void Process(TextReader textReader, TextWriter textWriter)
    {
        var strings = textReader.ReadLine()!.Split();
        var n = int.Parse(strings[0]); //колличество городов
        var m = int.Parse(strings[1]); //колличество рейсов

        var listVertex = new List<AirportVertex>?[n]; //airport->next->odd\even
        var listVertexPrev = new List<AirportVertex>?[n]; //airport->prev

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

                    listVertexPrev[edge.AirportNumber] ??= new List<AirportVertex>(2);
                    //todo: possible can be improved. additional copy
                    listVertexPrev[edge.AirportNumber]!.Add(new AirportVertex
                    {
                        EvenOdd = edge.EvenOdd,
                        AirportNumber = currentIndex
                    });

                    if (nextDistance != 0 && possibleDistance >= nextDistance)
                        continue;

                    distance[edge.AirportNumber] = possibleDistance;
                    queue.Enqueue(edge.AirportNumber);
                }
        }


        var backPathIndex = n - 1;
        byte[] results = new byte[n];
    

        var resultMinPath = distance[backPathIndex];
        while (backPathIndex > 0)
        {
            var currentMinPath = distance[backPathIndex];
            var newMinPath = int.MaxValue;
            foreach (var prevNode in listVertexPrev[backPathIndex])
            {
                if (prevNode.EvenOdd < 3 && results[prevNode.AirportNumber] == 0)
                {
                    results[prevNode.AirportNumber] = prevNode.EvenOdd;
                }
                else
                {
                    results[prevNode.AirportNumber] = 1;
                    if (newMinPath > distance[prevNode.AirportNumber])
                    {
                        newMinPath = distance[prevNode.AirportNumber];
                        backPathIndex = prevNode.AirportNumber;
                    }
                }


                //найти наикратчайший путь.
                //уничтожить его(пометить ноду что она определённого типа - будет использоваться в ответе)
                //увеличить общий путь до разницы с новым наименьшим - будет использоваться в ответе
                //установить backPathIndex = новый путь
                //если такого пути нет - то гг. -1, остальные значения не важны
            }

            resultMinPath += newMinPath - currentMinPath + 1;
            if (int.MaxValue == newMinPath) //нет обратного пути
            {
                resultMinPath = -1;
                results[backPathIndex] = 0;
                break;
            }
        }

        textWriter.WriteLine(resultMinPath);
        
        for (var index = 0; index < results.Length; index++)
        {
            var result = results[index];
            if (result == 2)
                results[index] = 0;
        }

        results[n-1] = 1;
        textWriter.WriteLine(string.Join("", results));
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