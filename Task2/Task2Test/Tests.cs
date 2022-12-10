using Common;

namespace Task2Test;

public class Tests
{
    [Test]
    [TestCase(new object[] { "1 1 1", "1 0 2"}, new object[] { "10" })]
    [TestCase(new object[] { "1 2 3", "3 5 4"}, new object[] { "28" })]
    public void BaseTest(object[] inputStrings, object[] results)
    {
        var testRunner = new TestRunner<Task2Solution>();
        testRunner.Process(inputStrings, results);
    }
    
    [Test]
    public void BigTest()
    {
        
        var testRunner = new TestRunner<Task2Solution>();
        var balances = $"{1e9} {1e9} {1e9}" ;
        testRunner.Process(new object[] { "1 1 1", balances}, new object[] { "10" });
    }
}