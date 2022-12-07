using System.Diagnostics;
using Common;

namespace Task4Test;

public class Tests
{
    [Test]
    [TestCase(new object[] { "3" }, new object[] { "0,4330127018922193" })]
    [TestCase(new object[] { "4" }, new object[] { "0,49999999999999983" })]
    [TestCase(new object[] { "5" }, new object[] { "0,7694208842938134" })]
    [TestCase(new object[] { "10" }, new object[] { "3,5532117953228317" })]
    [TestCase(new object[] { "500" }, new object[] { "19127,29452358118" })]
    public void BaseTest(object[] inputStrings, object[] results)
    {
        var testRunner = new TestRunner<Task4Solution>();
        testRunner.Process(inputStrings, results);
       
    }
}