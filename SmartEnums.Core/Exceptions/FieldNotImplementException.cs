using System;

namespace SmartEnums
{
    public class FieldNotImplementException : Exception
    {
        private const string TextFormat = "Wrong field name '{0}'. Field not implement in '{1}'.";

        public FieldNotImplementException(string key, Enum value)
            : base(string.Format(TextFormat, key, value.GetType().ToString() + "." + value)) { }
    }
}