using System;

// ReSharper disable once CheckNamespace
namespace SmartEnums
{
    /// <summary>
    /// Exception throwing when type value in casting is wrong. 
    /// </summary>
    public class WrongEnumValueTypeException : Exception
    {
        private const string TextFormat = "Exception while typecasting custom field '{0}' in '{1}'. Wrong type format.";
        
        /// <param name="value">Metadata field value.</param>
        /// <param name="type">Type to casting.</param>
        public WrongEnumValueTypeException(object value, Type type)
        : base(string.Format(TextFormat, value, type)) { }
    }
}