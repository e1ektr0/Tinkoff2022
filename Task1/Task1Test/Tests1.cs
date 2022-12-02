using System.Text;

namespace Task1Test;

public class Tests1
{
    [Test]
    [TestCase(new object[] { "0" }, new object[] { "7", "Tinkoff", "BYBYBYB" })]
    [TestCase(new object[] { "3" }, new object[] { "27", "Algorithms and Data Structures", "BBBBBBBBBBBYBYYYYBBBBBBBBBB" })]
    public void BaseTest(object[] results, object[] inputStrings)
    {
        var textReader = new StringReader(string.Join(Environment.NewLine, inputStrings));
        var stringBuilder = new StringBuilder();
        var textWriter = new StringWriter(stringBuilder);

        new Task1.Task1().Process(textReader, textWriter);

        var result = stringBuilder.ToString().TrimEnd('\n').TrimEnd('\r');
        Assert.That(result, Is.EqualTo(string.Join(Environment.NewLine, results)));
    }

}