using NUnit.Framework;
using SmartEnums.Tests.Enums;

namespace SmartEnums.Tests;

public class EnumExceptionTests
{
    [Test]
    public void TestWrongEnumValueTypeException()
    {
        Assert.Throws<WrongEnumValueTypeException>(() => EnumValue.Claus.GetValueOf<int>("Name"));
    }
    
    [Test]
    public void TestFieldNotImplementException()
    {
        Assert.Throws<FieldNotImplementException>(() => EnumValue.Claus.GetValueOf<string>("Nationality"));
    }
    
    [Test]
    public void TestVersionNotImplementException()
    {
        Assert.Throws<VersionNotImplementException>(() => EnumValue.Claus.GetValueOf<string>("Age", "2.0.4"));
    }
    
    [Test]
    public void TestOnlyOlderVersionImplementationException()
    {
        Assert.Throws<OnlyOlderVersionImplementationException>(() => EnumValue.Claus.GetValueOf<string>("Age", "^3.0.0"));
    }

    [Test]
    public void TestNullReferenceException()
    {
        Assert.DoesNotThrow(() => EnumValue.Claus.GetValueOf<string>("Name", "1.0.0"));
    }
}