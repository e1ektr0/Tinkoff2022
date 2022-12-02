using System.Text;

namespace Task2Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(new object[] { "0" }, new object[] { "7", "Tinkoff", "BYBYBYB" })]
    public void BaseTest(object[] results, object[] inputStrings)
    {
        var textReader = new StringReader(string.Join(Environment.NewLine, inputStrings));
        var stringBuilder = new StringBuilder();
        var textWriter = new StringWriter(stringBuilder);

        new Task2.Task2().Process(textReader, textWriter);

        var result = stringBuilder.ToString().TrimEnd('\n').TrimEnd('\r');
        Assert.That(result, Is.EqualTo(string.Join(Environment.NewLine, results)));
    }
}