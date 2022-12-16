using Common;

namespace Task6;

public class Task6Slow : IConsoleTest
{
    List<int> _list = new();
    public void Process(TextReader textReader, TextWriter textWriter)
    {   var tree = new Tree();
        var q = long.Parse(textReader.ReadLine()!);
        for (int i = 0; i < q; i++)
        {
            int k = int.Parse(textReader.ReadLine()!);
            _list.Add(k);
            var max = 0;
            foreach (var l in _list)
            {
                foreach (var l1 in _list)
                {
                    var max1 = l ^ l1;
                    if (max1 > max)
                    {
                        max = max1;
                    }
                }
            }
            textWriter.WriteLine(tree.Add(k));
        }
        
    }
}