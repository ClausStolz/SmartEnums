using System;
using NUnit.Framework;
using SmartEnums.Tests.Enums;

namespace SmartEnums.Tests;

public class StringToEnumTests
{
    [Test]
    [TestCase("Male", Gender.Male)]
    [TestCase("Female", Gender.Female)]
    public void TestToEnum(string text, Enum expectedResult)
    {
        Assert.AreEqual(expectedResult, SmartEnum.ToEnum<Gender>(text));
    }
}