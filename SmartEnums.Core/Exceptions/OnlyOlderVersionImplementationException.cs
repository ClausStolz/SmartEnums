using System;


namespace SmartEnums
{
    public class OnlyOlderVersionImplementationException : Exception
    {
        private const string TextFormat = "Wrong version of field named '{0}'. " +
                                      "There is not implementation of field with equal or later version '{1}' in '{2}'.";

        public OnlyOlderVersionImplementationException(string key, string version, Enum value) 
            : base(string.Format(TextFormat, key, version, value.GetType() + "." + value)) { }
    }
}