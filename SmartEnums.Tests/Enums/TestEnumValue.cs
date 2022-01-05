using System;

namespace SmartEnums.Tests.Enums
{
    public enum TestEnumValue
    {
        [EnumValue("Name", "Jhon")]
        [EnumValue("Age", 20)]
        [EnumValue("Gender", Gender.Male)]
        Jhon,
        [EnumValue("Name", "Claus")]
        [EnumValue("Age", 25, "1.0.0")]
        [EnumValue("Age", 30, "2.0.0")]
        [EnumValue("Age", 31, "2.0.1")]
        [EnumValue("Gender", Gender.Male)]
        Claus,
        [EnumValue("Name", "Elza")]
        [EnumValue("Age", 15)]
        [EnumValue("Gender", Gender.Female)]
        Elza
    }
}