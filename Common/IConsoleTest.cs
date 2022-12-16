using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace Common;

public class TestRunner<T> where T:IConsoleTest, new()
{
    public void Process(object[] inputStrings, object[] results)
    {
        var textReader = new StringReader(string.Join(Environment.NewLine, inputStrings));
        var stringBuilder = new StringBuilder();
        var textWriter = new StringWriter(stringBuilder);
        var startNew = Stopwatch.StartNew();
        new T().Process(textReader, textWriter);

        startNew.Stop();
        Console.WriteLine(startNew.ElapsedMilliseconds);
        var result = stringBuilder.ToString().TrimEnd('\n').TrimEnd('\r');
        Assert.That(result, Is.EqualTo(string.Join(Environment.NewLine, results)));
    }
    public void Process(object[] inputStrings)
    {
        var textReader = new StringReader(string.Join(Environment.NewLine, inputStrings));
        var stringBuilder = new StringBuilder();
        var textWriter = new StringWriter(stringBuilder);
        var startNew = Stopwatch.StartNew();
        new T().Process(textReader, textWriter);

        startNew.Stop();
        Console.WriteLine(startNew.ElapsedMilliseconds);
    }
    public void Compare<T2>(object[] inputStrings) where T2:IConsoleTest, new()
    {
        var textReader = new StringReader(string.Join(Environment.NewLine, inputStrings));
        var stringBuilder = new StringBuilder();
        var textWriter = new StringWriter(stringBuilder);
        new T().Process(textReader, textWriter);
        var textReader2 = new StringReader(string.Join(Environment.NewLine, inputStrings));
        var stringBuilder2 = new StringBuilder();
        var textWriter2 = new StringWriter(stringBuilder2);
        new T2().Process(textReader2, textWriter2);
        var result = stringBuilder.ToString().TrimEnd('\n').TrimEnd('\r');
        var result2 = stringBuilder2.ToString().TrimEnd('\n').TrimEnd('\r');
        Assert.That(result, Is.EqualTo(result2));
    }
}

public interface IConsoleTest
{
    void Process(TextReader textReader, TextWriter textWriter);
}