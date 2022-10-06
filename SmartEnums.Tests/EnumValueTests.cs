using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SmartEnums.Tests.Enums;

namespace SmartEnums.Tests;

public class EnumValueTests
{
    [Test]
    [TestCase(EnumValue.John, "Name", "John")]
    [TestCase(EnumValue.Claus, "Name", "Claus")]
    [TestCase(EnumValue.Elza, "Name", "Elza")]
    public void TestEnumValueString(Enum value, string key, string expectedResult)
    {
        Assert.AreEqual(expectedResult, value.GetValueOf<string>(key));
    }
    
    [Test]
    [TestCase(EnumValue.John, "Age", 20)]
    [TestCase(EnumValue.Claus, "Age", 31)]
    [TestCase(EnumValue.Elza, "Age", 15)]
    public void TestEnumValueInt(Enum value, string key, int expectedResult)
    {
        Assert.AreEqual(expectedResult, value.GetValueOf<int>(key));
    }
    
    [Test]
    [TestCase(EnumValue.John, "Gender", "he/him")]
    [TestCase(EnumValue.Claus, "Gender", "he/him")]
    [TestCase(EnumValue.Elza, "Gender", "she/her")]
    public void TestRecursiveEnumValue(Enum value, string key, string expectedResult)
    {
        Assert.AreEqual(expectedResult, value.GetValueOf<Gender>(key).GetValueOf<string>("Description"));
    }
    
    [Test]
    [TestCase(EnumValue.Claus, "Age", "1.0.0", 25)]
    [TestCase(EnumValue.Claus, "Age", "2.0.0", 30)]
    [TestCase(EnumValue.Claus, "Age", "^1.0.0", 31)]
    [TestCase(EnumValue.Claus, "Age", "latest", 31)]
    public void TestVersionedEnumValue(Enum value, string key, string version, int expectedResult)
    {
        Assert.AreEqual(expectedResult, value.GetValueOf<int>(key, version));
    }

    [Test]
    [TestCase(EnumValue.Claus, 5)]
    [TestCase(EnumValue.John, 3)]
    [TestCase(EnumValue.Elza, 3)]
    public void TestEnumValueJsonMetadata(Enum value, int expectedResult)
    {
        var deserialize = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<object>>(value.GetJsonMetadata());
        if (deserialize != null) Assert.AreEqual(expectedResult, deserialize.Count());
    }

    [Test]
    [TestCase(EnumValue.Claus, "Gender", true)]
    [TestCase(EnumValue.Claus, "Style", false)]
    public void TestEnumValueContainKey(Enum obj, string key, bool expectedResult)
    {
        Assert.AreEqual(expectedResult, obj.ContainKey(key));
    }
    
    [Test]
    [TestCase("Gender", new[] { EnumValue.Claus, EnumValue.John, EnumValue.Elza})]
    [TestCase("Style", null)]
    public void TestEnumValueFindByKey(string key, EnumValue[] expectedResult)
    {
        var values = SmartEnum.FindByKey<EnumValue>(key);
        foreach (var element in values)
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
    
    [Test]
    [TestCase("Gender", Gender.Male, new[] { EnumValue.Claus, EnumValue.John})]
    [TestCase("Gender", Gender.Female, new[] {EnumValue.Elza})]
    public void TestEnumValueFindByValue(string key, Gender value, EnumValue[] expectedResult)
    {
        var values = SmartEnum.FindByValue<EnumValue, Gender>(key, value);
        foreach (var element in values)
        {
            Assert.True(expectedResult.Contains(element));
        }
    }
}