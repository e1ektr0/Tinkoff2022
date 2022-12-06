using System.Text;
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
}