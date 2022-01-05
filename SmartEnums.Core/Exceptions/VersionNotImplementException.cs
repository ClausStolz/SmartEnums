using System;

namespace SmartEnums
{
    public class VersionNotImplementException : Exception
    {
        private const string TextFormat = "Wrong version of field named '{0}'. " +
                                          "There is not implementation of field with version '{1}' in '{2}'.";

        public VersionNotImplementException(string key, string version, Enum value)
            : base(string.Format(TextFormat, key, version, value.GetType() + "." + value)) { }
    }
}