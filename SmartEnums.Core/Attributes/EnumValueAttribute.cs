using System;


namespace SmartEnums
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class EnumValueAttribute : Attribute
    {
        public string Key { get; }

        public object Value { get; }
        
        public string Version { get; }

        public EnumValueAttribute(string key, object value, string version = "latest")
        {
            Key = key;
            Value = value;
            Version = version;
        }
    }
}