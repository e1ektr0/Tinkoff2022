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

        new T().Process(textReader, textWriter);

        var result = stringBuilder.ToString().TrimEnd('\n').TrimEnd('\r');
        Assert.That(result, Is.EqualTo(string.Join(Environment.NewLine, results)));
    }
}

public interface IConsoleTest
{
    void Process(TextReader textReader, TextWriter textWriter);
}