using Common;

public class Task2Solution : IConsoleTest
{
    public void Process(TextReader textReader, TextWriter textWriter)
    {
        var readLine = textReader.ReadLine()!;
        var strings = readLine.Split();
        var a = int.Parse(strings[0]);
        var b = int.Parse(strings[1]);
        var c = int.Parse(strings[2]);

        readLine = textReader.ReadLine()!;
        strings = readLine.Split();
        var x = int.Parse(strings[0]);
        var y = int.Parse(strings[1]);
        var z = int.Parse(strings[2]);

        var sum = x / a + b / y + z / c;
        

    }
}