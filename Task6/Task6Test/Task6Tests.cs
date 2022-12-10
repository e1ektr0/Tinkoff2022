using System.Globalization;
using Common;
using Task6;

namespace Task6Test;

public class Task6Tests
{
    [Test]
    [TestCase(new object[] { "4", "3", "2", "5", "2" }, new object[] { "0", "1", "7", "7" })]
    [TestCase(new object[] { "3","0", "9","10" }, new object[] { "0", "9", "10" })]
    [TestCase(new object[] { "3","0", "5","6" }, new object[] { "0", "5", "6" })]
    [TestCase(new object[] { "2","0", "5" }, new object[] { "0", "5" })]
    public void BaseTest(object[] inputStrings, object[] results)
    {
        var testRunner = new TestRunner<Task6Solution>();
        testRunner.Process(inputStrings, results);
    }
    
    [Test]
    public void BigNumber()
    {
        var pow = Math.Pow(2, 32)-1;
        var testRunner = new TestRunner<Task6Solution>();
        var input = new object[] { "2",pow.ToString(CultureInfo.InvariantCulture), "0" };
        var result = new object[] { "0", "4294967295" };
        testRunner.Process(input, result);
    }
    
    
    [Test]
    [TestCase((int)3e5)]
    [TestCase((int)3e4)]
    [TestCase((int)3e3)]
    public void ALotOfNumbers(int count)
    {
        var input = new List<object> { count.ToString() };
        input.AddRange(Enumerable.Range(0, count).Select(n=>n.ToString()));
        
        var testRunner = new TestRunner<Task6Solution>();
        var result = new object[] { "0", "4294967295" };
        testRunner.Process(input.ToArray(), result);
    }
}