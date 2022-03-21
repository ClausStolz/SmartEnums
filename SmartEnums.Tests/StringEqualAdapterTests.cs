using NUnit.Framework;
using SmartEnums.Helpers;

namespace SmartEnums.Tests;

public class StringEqualAdapterTests
{
    [Test]
    [TestCase("1.0.0", "1.0.0", true)]
    [TestCase("4.0.4.alpha", "4.0.4.alpha", true)]
    [TestCase("1.0.1", "1.0.2", false)]
    public void TestOperatorEqual(string value, string compareValue, bool expectedResult)
    {
        Assert.AreEqual(expectedResult, new StringEqualAdapter(value) == compareValue);
    }
    
    [Test]
    [TestCase("1.0.0", "1.0.0", false)]
    [TestCase("4.0.4.alpha", "4.0.4.alpha", false)]
    [TestCase("1.0.1", "1.0.2", true)]
    public void TestOperatorNotEqual(string value, string compareValue, bool expectedResult)
    {
        Assert.AreEqual(expectedResult, new StringEqualAdapter(value) != compareValue);
    }
    
    [Test]
    [TestCase("1.0.0", "1.0.0", false)]
    [TestCase("4.0.4.alpha", "4.0.4.beta", true)]
    [TestCase("1.0.1", "1.0.2", true)]
    public void TestOperatorLess(string value, string compareValue, bool expectedResult)
    {
        Assert.AreEqual(expectedResult, new StringEqualAdapter(value) < compareValue);
    }
    
    [Test]
    [TestCase("1.0.0", "1.0.0", true)]
    [TestCase("4.0.4.beta", "4.0.4.alpha", false)]
    [TestCase("1.0.1", "1.0.2", true)]
    public void TestOperatorLessOrEqual(string value, string compareValue, bool expectedResult)
    {
        Assert.AreEqual(expectedResult, new StringEqualAdapter(value) <= compareValue);
    }
    
    [Test]
    [TestCase("1.0.0", "1.0.0", false)]
    [TestCase("4.0.4.alpha", "4.0.4.beta", false)]
    [TestCase("1.0.2", "1.0.1", true)]
    public void TestOperatorMore(string value, string compareValue, bool expectedResult)
    {
        Assert.AreEqual(expectedResult, new StringEqualAdapter(value) > compareValue);
    }
    
    [Test]
    [TestCase("1.0.0", "1.0.0", true)]
    [TestCase("4.0.4.beta", "4.0.4.alpha", true)]
    [TestCase("1.0.1", "1.0.2", false)]
    public void TestOperatorMoreOrEqual(string value, string compareValue, bool expectedResult)
    {
        Assert.AreEqual(expectedResult, new StringEqualAdapter(value) >= compareValue);
    }
}