using System.Linq;
using NUnit.Framework;
using SmartEnums.Tests.Enums;

namespace SmartEnums.Tests;

public class EnumEnumerationTests
{
    [Test]
    [TestCase(new[] { Gender.Male, Gender.Female })]
    public void TestEnumEnumeration(Gender[] expectedResult)
    {
        foreach (var element in SmartEnum.GetEnumerator<Gender>())
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
}
