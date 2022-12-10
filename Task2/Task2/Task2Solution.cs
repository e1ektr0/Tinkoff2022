using Common;

public class Task2Solution : IConsoleTest
{
    public void Process(TextReader textReader, TextWriter textWriter)
    {
        var readLine = textReader.ReadLine()!;
        var strings = readLine.Split();
        long a = int.Parse(strings[0]);
        long b = int.Parse(strings[1]);
        long c = int.Parse(strings[2]);

        readLine = textReader.ReadLine()!;
        strings = readLine.Split();
        long x = int.Parse(strings[0]);
        long y = int.Parse(strings[1]);
        long z = int.Parse(strings[2]);

        var max = x / a + y / b + z / c;

        var constanta = max + 1;
        var result = (constanta+1) * (max+1) / 2;//S_n=\frac{(a_1+a_n)n}{2}
        
        textWriter.WriteLine(result);
    }

    public int Factorial(int f)
    {
        if (f == 0)
            return 1;
        else
            return f * Factorial(f - 1);
    }
}