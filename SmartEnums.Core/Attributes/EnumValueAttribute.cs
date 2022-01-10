using System;
using SmartEnums.Core.Helpers;


namespace SmartEnums
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class EnumValueAttribute : Attribute
    {
        public string Key { get; }

        public object Value { get; }
        
        public string Version { get; set; }
        
        public EnumValueAttribute(string key, object value)
        {
            Key = key;
            Value = value;
            Version = Config.DefaultVersion;
        }

        public EnumValueAttribute(string key, object value, string version) : this(key, value)
        {
            Version = version;
        }
    }
}