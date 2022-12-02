using Common;

namespace Task3;

public class Task3Slow : IConsoleTest
{
    public void Process(TextReader textReader, TextWriter textWriter)
    {
        var n = long.Parse(textReader.ReadLine()!);

        var minNok = long.MaxValue;
        var result = 1;
        //slow solution: generate all possible sums, and find nok
        for (int i = 1; i < n - 1; i++)
        {
            var nok = NOK(i, n - i);
            if (nok < minNok)
            {
                minNok = nok;
                result = i;
            }
        }

        textWriter.WriteLine(result + " " + (n - result));
    }

    long NOK(long n1, long n2)
    {
        return n1 * n2 / NOD(n1, n2);
    }

    
    private long NOD(long m, long n)
    {
        long nod = 0;
        for (long i = 1; i < (n * m + 1); i++)
        {
            if (m % i == 0 && n % i == 0)
            {
                nod = i;
            }
        }

        return nod;
    }
}