using System.Text;

long num = (long)1e8;
var aggregate = Enumerable.Range(0, (int)Math.Floor(2.52 * Math.Sqrt(num) / Math.Log(num))).Aggregate(
    Enumerable.Range(2, (int)num - 1).ToList(),
    (result, index) =>
    {
        var bp = result[index];
        var sqr = bp * bp;
        result.RemoveAll(i => i >= sqr && i % bp == 0);
        return result;
    }
);

// StringBuilder sb = new StringBuilder();
// sb.Append(File.ReadAllText("GoPrefix.txt"));
// for (var index = 1; index < aggregate.Count; index++)
// {
//     var i = aggregate[index];
//     var gap = i - aggregate[index - 1];
//     if (gap <= 254)
//     {
//         sb.Append((char)gap);
//     }
//     else
//     {
//         sb.Append((char)255);
//         sb.Append((char)(gap - 255));
//     }
//
//     if (index % 10000 == 0)
//     {
//         Console.WriteLine(index);
//     }
// }
//
// sb.Append(File.ReadAllText("GoPostFix"));
//
//
// File.WriteAllText("go1e2", sb.ToString());

StringBuilder sb = new StringBuilder();
sb.Append("using System;");
sb.Append("using System.IO;");
sb.Append("using System.Text;");
sb.Append(File.ReadAllText("dotnetprefix.txt"));
for (var index = 1; index < aggregate.Count; index++)
{
    var i = aggregate[index];
    var gap = i - aggregate[index - 1];
    if (gap <= 254)
    {
        var c = (char)gap;
        if (c != '\n')
        {
            if (c != '"')
            {
                if (c != '\\')
                    sb.Append(c);
                else
                    sb.Append(@"\\");
            }
            else
                sb.Append("\\\"");
        }
        else
            sb.Append(@"\n");
    }
    else
    {
        sb.Append((char)255);
        var c = (char)(gap - 255);
        if (c != '\n')
            if (c != '"')
                if (c != '\\')
                    sb.Append(c);
                else
                    sb.Append(@"\\");
            else
                sb.Append("\\\"");
        else
            sb.Append(@"\n");
    }

    if (index % 10000 == 0)
    {
        Console.WriteLine(index);
    }
}

sb.Append(File.ReadAllText("dotnetpostfix.txt"));

File.WriteAllText("Solution.cs", sb.ToString());