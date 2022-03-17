using System;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using NUnit.Framework;
using SmartEnums.Tests.Enums;
using SmartEnums;

namespace SmartEnums.Tests
{
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
}