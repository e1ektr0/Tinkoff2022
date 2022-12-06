using Common;

namespace Task1Test;

public class Tests1
{
    [Test]
    [TestCase(new object[] { "7", "Tinkoff", "BYBYBYB" }, new object[] { "0" })]
    [TestCase(new object[] { "27", "Algorithms and Data Structures", "BBBBBBBBBBBYBYYYYBBBBBBBBBB" },
        new object[] { "3" })]
    public void BaseTest(object[] inputStrings, object[] results)
    {
        var testRunner = new TestRunner<Task1.Task1>();
        testRunner.Process(inputStrings, results);
    }
}