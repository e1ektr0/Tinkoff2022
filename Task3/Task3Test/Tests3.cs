using System.Diagnostics;
using System.Text;
using Common;

namespace Task3Test;

public class Tests3
{
    [Test]
    [TestCase(new object[] { "1 2" }, new object[] { "3" })]
    [TestCase(new object[] { "3 3" }, new object[] { "6" })]
    [TestCase(new object[] { "3 6" }, new object[] { "9" })]
    [TestCase(new object[] { "50 50" }, new object[] { "100" })]
    [TestCase(new object[] { "1 100" }, new object[] { "101" })]
    [TestCase(new object[] { "51 51" }, new object[] { "102" })]
    [TestCase(new object[] { "35 70" }, new object[] { "105" })]
    [TestCase(new object[] { "1 6" }, new object[] { "7" })]
    [TestCase(new object[] { "1 4" }, new object[] { "5" })]
    [TestCase(new object[] { "1 1222" }, new object[] { "1223" })] //simple numbers = simplenumber - 1...hmmmm
    [TestCase(new object[] { "33 66" }, new object[] { "99" })]
    [TestCase(new object[] { "9 18" }, new object[] { "27" })]
    public void SlowTest(object[] results, object[] inputStrings)
    {
        var textReader = new StringReader(string.Join(Environment.NewLine, inputStrings) + Environment.NewLine);
        var stringBuilder = new StringBuilder();
        var textWriter = new StringWriter(stringBuilder);

        new Task3.Task3Slow().Process(textReader, textWriter);

        var result = stringBuilder.ToString().TrimEnd('\n').TrimEnd('\r');
        Assert.That(result, Is.EqualTo(string.Join(Environment.NewLine, results)));
    }


    [Test, MaxTime(1000)]
    [TestCase(new object[] { "1 2" }, new object[] { "3" })]
    [TestCase(new object[] { "3 3" }, new object[] { "6" })]
    [TestCase(new object[] { "3 6" }, new object[] { "9" })]
    [TestCase(new object[] { "50 50" }, new object[] { "100" })]
    [TestCase(new object[] { "1 100" }, new object[] { "101" })]
    [TestCase(new object[] { "51 51" }, new object[] { "102" })]
    [TestCase(new object[] { "35 70" }, new object[] { "105" })]
    [TestCase(new object[] { "1 6" }, new object[] { "7" })]
    [TestCase(new object[] { "1 4" }, new object[] { "5" })]
    [TestCase(new object[] { "33 66" }, new object[] { "99" })]
    [TestCase(new object[] { "9 18" }, new object[] { "27" })]
    public void BaseTest(object[] results, object[] inputStrings)
    {
        var textReader = new StringReader(string.Join(Environment.NewLine, inputStrings) + Environment.NewLine);
        var stringBuilder = new StringBuilder();
        var textWriter = new StringWriter(stringBuilder);

        new Task3.Task3().Process(textReader, textWriter);

        var result = stringBuilder.ToString().TrimEnd('\n').TrimEnd('\r');
        Assert.That(result, Is.EqualTo(string.Join(Environment.NewLine, results)));
    }

    [TestCase(new object[] { "33333333 66666666" }, new object[] { "99999999" })]//1e8-1
    [TestCase(new object[] { "177241 74441220" }, new object[] { "74618461" })]//1e8-1
    public void BigNumberTest(object[] results, object[] inputStrings)
    {
        var textReader = new StringReader(string.Join(Environment.NewLine, inputStrings) + Environment.NewLine);
        var stringBuilder = new StringBuilder();
        var textWriter = new StringWriter(stringBuilder);

        var startNew = Stopwatch.StartNew();
        new Task3.Task3().Process(textReader, textWriter);
        startNew.Stop();
        Console.WriteLine(startNew.ElapsedMilliseconds);
        var result = stringBuilder.ToString().TrimEnd('\n').TrimEnd('\r');
        Assert.That(result, Is.EqualTo(string.Join(Environment.NewLine, results)));
    }
    

    [Test]
    public void CarefulTest()
    {
        for (int i = 999; i < 1002; i++)
        {
            var result = Result(i, new Task3.Task3());
            var result2 = Result(i, new Task3.Task3Slow());
            Console.WriteLine(i+":"+result);
            Assert.That(result, Is.EqualTo(result2), "For " + i);
        }
    }

    [Test]
    public void GenerateValueTest()
    {
        var test = (int)1e3+1;
        var result2 = Result(test, new Task3.Task3Slow());
        Console.WriteLine(test+":"+result2);
    }

    private static string Result(int i, IConsoleTest test)
    {
        var textReader = new StringReader(string.Join(Environment.NewLine, i) + Environment.NewLine);
        var stringBuilder = new StringBuilder();
        var textWriter = new StringWriter(stringBuilder);

        test.Process(textReader, textWriter);

        var result = stringBuilder.ToString().TrimEnd('\n').TrimEnd('\r');
        return result;
    }
}