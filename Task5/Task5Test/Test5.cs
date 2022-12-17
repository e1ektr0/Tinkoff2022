using Common;
using Task5;

namespace Task5Test;

public class Test5
{
    [Test]
    //todo: need more tests
    [TestCase(new object[] { "3 3", "1 2 0", "1 3 1", "2 3 0" }, new object[] { "-1", "011" })]
    [TestCase(new object[] { "4 6", "1 3 0", "3 4 0", "3 4 1", "1 2 1", "2 3 1", "2 4 0" },
        new object[] { "3", "1111" })]
    public void BaseTest(object[] inputStrings, object[] results)
    {
        var testRunner = new TestRunner<Task5Solution>();
        testRunner.Process(inputStrings, results);
    }


    [Test]
    [MaxTime(2000)]
    public void BigTest()
    {
        
        var inputStrings = new List<object> { "2 10000"};
        for (var i = 0; i < 1e5/4; i++)
        {
            inputStrings.Add("1 1 0");
            inputStrings.Add("1 2 0");
            inputStrings.Add("1 1 1");
            inputStrings.Add("1 2 1");
        }

        var testRunner = new TestRunner<Task5Solution>();
        testRunner.Process(inputStrings.ToArray());
    }
}