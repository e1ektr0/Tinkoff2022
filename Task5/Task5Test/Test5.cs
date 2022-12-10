using Common;
using Task5;

namespace Task5Test;

public class Test5
{
    [Test]
    //todo: need more tests
    [TestCase(new object[] { "3 3", "1 2 0", "1 3 1", "2 3 0" }, new object[] { "-1", "011" })]
    [TestCase(new object[] { "4 6", "1 3 0", "3 4 0", "3 4 1", "1 2 1", "2 3 1", "2 4 0" },new object[] { "3", "1111" })]
    public void BaseTest(object[] inputStrings, object[] results)
    {
        var testRunner = new TestRunner<Task5Solution>();
        testRunner.Process(inputStrings, results);
    }
}