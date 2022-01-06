using NUnit.Framework;
using SmartEnums.Tests.Enums;


namespace SmartEnums.Tests
{
    public class EnumExceptionTests
    {
        [Test]
        public void TestWrongEnumValueTypeException()
        {
            Assert.Throws<WrongEnumValueTypeException>(() => TestEnumValue.Claus.GetValueOf<int>("Name"));
        }
        
        [Test]
        public void TestFieldNotImplementException()
        {
            Assert.Throws<FieldNotImplementException>(() => TestEnumValue.Claus.GetValueOf<string>("Nationality"));
        }
        
        [Test]
        public void TestVersionNotImplementException()
        {
            Assert.Throws<VersionNotImplementException>(() => TestEnumValue.Claus.GetValueOf<string>("Age", "2.0.4"));
        }
        
        [Test]
        public void TestOnlyOlderVersionImplementationException()
        {
            Assert.Throws<OnlyOlderVersionImplementationException>(() => TestEnumValue.Claus.GetValueOf<string>("Age", "^3.0.0"));
        }
    }
}