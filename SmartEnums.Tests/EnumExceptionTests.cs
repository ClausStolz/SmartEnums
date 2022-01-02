using System;
using NUnit.Framework;
using SmartEnums.Core.Exceptions;
using SmartEnums.Extensions;
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
    }
}