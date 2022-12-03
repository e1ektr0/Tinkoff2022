using System.Text;
using Task5;

namespace Task5Test;

public class Test5
{
    [Test]
    [TestCase(new object[] { "-1", "011" }, new object[] { "3 3", "1 2 0", "1 3 1", "2 3 0" })]
    [TestCase(new object[] { "3", "1111" }, new object[] { "4 6", "1 3 0", "3 4 0", "3 4 1", "1 2 1", "2 3 1", "2 4 0" })]
    public void BaseTest(object[] results, object[] inputStrings)
    {
        var textReader = new StringReader(string.Join(Environment.NewLine, inputStrings));
        var stringBuilder = new StringBuilder();
        var textWriter = new StringWriter(stringBuilder);

        new Task5Solution().Process(textReader, textWriter);

        var result = stringBuilder.ToString().TrimEnd('\n').TrimEnd('\r');
        Assert.That(result, Is.EqualTo(string.Join(Environment.NewLine, results)));
    }
}