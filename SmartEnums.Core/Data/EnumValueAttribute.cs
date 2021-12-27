using System;
using System.Collections.Generic;

namespace SmartEnums.Core.Data
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class EnumValueAttribute : Attribute
    {
        public string Key { get; }

        public object Value { get; }

        public EnumValueAttribute(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}