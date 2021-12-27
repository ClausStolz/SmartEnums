using System;
using SmartEnums.Core.Data;

namespace SmartEnums.Tests.Data
{
    public enum TestEnumValue
    {
        [EnumValue("Name", "Jhon")]
        [EnumValue("Age", 20)]
        [EnumValue("Gender", Gender.Male)]
        Jhon,
        [EnumValue("Name", "Claus")]
        [EnumValue("Age", 25)]
        [EnumValue("Gender", Gender.Male)]
        Claus,
        [EnumValue("Name", "Elza")]
        [EnumValue("Age", 15)]
        [EnumValue("Gender", Gender.Female)]
        Elza
    }
}