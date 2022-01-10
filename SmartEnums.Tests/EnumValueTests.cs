using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using SmartEnums.Tests.Enums;

namespace SmartEnums.Tests
{
    public class EnumValueTests
    {
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
        [TestCase(TestEnumValue.Claus, "Age", 31)]
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
        
        [Test]
        [TestCase(TestEnumValue.Claus, "Age", "1.0.0", 25)]
        [TestCase(TestEnumValue.Claus, "Age", "2.0.0", 30)]
        [TestCase(TestEnumValue.Claus, "Age", "^1.0.0", 31)]
        [TestCase(TestEnumValue.Claus, "Age", "latest", 31)]
        public void TestVersionedEnumValue(Enum value, string key, string version, int expectedResult)
        {
            Assert.AreEqual(expectedResult, value.GetValueOf<int>(key, version));
        }

        [Test]
        [TestCase(TestEnumValue.Claus, 5)]
        [TestCase(TestEnumValue.Jhon, 3)]
        [TestCase(TestEnumValue.Elza, 3)]
        public void TestEnumValueJsonMetadata(Enum value, int expectedResult)
        {
            var deserialize = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<object>>(value.GetJsonMetadata());
            if (deserialize != null) Assert.AreEqual(expectedResult, deserialize.Count());
        }
    }
}