using System.Globalization;
using Common;
using Task6;

namespace Task6Test;

public class Task6Tests
{
    [Test]
    [TestCase(new object[] { "4", "3", "2", "5", "2" }, new object[] { "0", "1", "7", "7" })]
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
}