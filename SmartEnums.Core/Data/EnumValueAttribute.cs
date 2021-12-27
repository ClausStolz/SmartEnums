using System;
using System.Collections.Generic;

namespace SmartEnums.Core.Data
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class EnumValueAttribute : Attribute
    {
        public string Key { get; }

        public Type ValueType { get; }
        
        public object Value { get; }

        public EnumValueAttribute(string key, Type valueType, object value)
        {
            Key = key;
            ValueType = valueType;
            Value = value;
        }
    }
}