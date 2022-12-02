using Common;

namespace Task1;

public class Task1 : IConsoleTest
{
    public void Process(TextReader textReader, TextWriter textWriter)
    {
        var n = int.Parse(textReader.ReadLine()!);
        var s = textReader.ReadLine()!;
        var b = textReader.ReadLine()!;


        var result = 0;
        var lastSymbol = '#';
        var skipBeforeSpace = false;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == ' ')
            {
                lastSymbol = '#';
                skipBeforeSpace = false;
            }
            else
            {
                if (skipBeforeSpace)
                    continue;

                if (b[i] == lastSymbol)
                {
                    skipBeforeSpace = true;
                    result++;
                }

                lastSymbol = b[i];
            }
        }

        textWriter.WriteLine(result);
    }
}