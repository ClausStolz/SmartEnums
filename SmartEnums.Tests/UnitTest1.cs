using System;
using System.Reflection;
using NUnit.Framework;
using SmartEnums.Core.Extensions;
using SmartEnums.Tests.Data;

namespace SmartEnums.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(TestEnumValue.Jhon, "Name", "Jhon")]
        [TestCase(TestEnumValue.Claus, "Name", "Claus")]
        [TestCase(TestEnumValue.Elza, "Name", "Elza")]
        public void TestEnumValueString(Enum value, string key, string expectedResult)
        {
            Assert.AreEqual(expectedResult, value.GetValueOf<string>(key));
        }
        
        [Test]
        [TestCase(TestEnumValue.Jhon, "Age", 20)]
        [TestCase(TestEnumValue.Claus, "Age", 25)]
        [TestCase(TestEnumValue.Elza, "Age", 15)]
        public void TestEnumValueInt(Enum value, string key, int expectedResult)
        {
            Assert.AreEqual(expectedResult, value.GetValueOf<int>(key));
        }
        
        [Test]
        [TestCase(TestEnumValue.Jhon, "Gender", "he/him")]
        [TestCase(TestEnumValue.Claus, "Gender", "he/him")]
        [TestCase(TestEnumValue.Elza, "Gender", "she/her")]
        public void TestRecursiveEnumValue(Enum value, string key, string expectedResult)
        {
            Assert.AreEqual(expectedResult, value.GetValueOf<Gender>(key).GetValueOf<string>("Description"));
        }
        
    }
}