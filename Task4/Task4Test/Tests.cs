using Common;

namespace Task4Test;

public class Tests
{
    [Test]
    [TestCase(new object[] { "3" }, new object[] { "0,43301270189221897" })]
    [TestCase(new object[] { "10" }, new object[] { "3.553212" })]
    [TestCase(new object[] { "500" }, new object[] { "3.553212" })]
    public void BaseTest(object[] inputStrings, object[] results)
    {
        var testRunner = new TestRunner<Task4Solution>();
        testRunner.Process(inputStrings, results);
    }
}