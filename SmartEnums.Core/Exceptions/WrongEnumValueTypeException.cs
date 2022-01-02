using System;

namespace SmartEnums
{
    public class WrongEnumValueTypeException : Exception
    {
        private const string TextFormat = "Exception while typecasting custom field '{0}' in '{1}'. Wrong type format.";

        public WrongEnumValueTypeException(object value, Type type)
        : base(string.Format(TextFormat, value, type)) { }
    }
}