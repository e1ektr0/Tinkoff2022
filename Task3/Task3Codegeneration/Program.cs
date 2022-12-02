using System.Text;

long num = (long)1e2;
var aggregate = Enumerable.Range(0, (int)Math.Floor(2.52 * Math.Sqrt(num) / Math.Log(num))).Aggregate(
    Enumerable.Range(2, (int)num - 1).ToList(),
    (result, index) =>
    {
        Console.WriteLine(index);
        var bp = result[index];
        var sqr = bp * bp;
        result.RemoveAll(i => i >= sqr && i % bp == 0);
        return result;
    }
);


StringBuilder sb = new StringBuilder();
sb.Append("using System;");
sb.Append("using System.IO;");
sb.Append("using System.Text; namespace Task3{public class PrimeNumbers{public static byte[] PrimeGaps = new byte[]{");
for (var index = 1; index < aggregate.Count; index++)
{
    var i = aggregate[index];
    var gap = i - aggregate[index - 1];
    if (gap <= 254)
    {
        sb.Append(gap + ",");
    }
    else
    {
        sb.Append(255 + ",");
        sb.Append(gap - 255 + ",");
    }

    if (index % 10000 == 0)
    {
        Console.WriteLine(index);
    }
}

sb.Append("};}");
sb.Append(File.ReadAllText("NewFile1.txt"));
sb.Append("}");

File.WriteAllText("Solution.cs", sb.ToString());