using System;

// ReSharper disable once CheckNamespace
namespace SmartEnums
{
    /// <summary>
    /// Exception throwing when field not implemented.
    /// </summary>
    public class FieldNotImplementException : Exception
    {
        private const string TextFormat = "Wrong field name '{0}'. Field not implement in '{1}'.";
        
        /// <param name="key">Field name implemented in metadata field key.</param>
        /// <param name="value">Enum object.</param>
        public FieldNotImplementException(string key, Enum value)
            : base(string.Format(TextFormat, key, value.GetType() + "." + value)) { }
    }
}