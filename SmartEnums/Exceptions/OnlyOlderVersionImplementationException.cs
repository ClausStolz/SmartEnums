using System;


// ReSharper disable once CheckNamespace
namespace SmartEnums
{
    /// <summary>
    /// Exception throwing when for field find only older version.
    /// </summary>
    public class OnlyOlderVersionImplementationException : Exception
    {
        private const string TextFormat = "Wrong version of field named '{0}'. " +
                                      "There is not implementation of field with equal or later version '{1}' in '{2}'.";
        
        /// <param name="key">Field name implemented in metadata field key.</param>
        /// <param name="version">Defined version of metadata field.</param>
        /// <param name="value">Enum object.</param>
        public OnlyOlderVersionImplementationException(string key, string version, Enum value) 
            : base(string.Format(TextFormat, key, version, value.GetType() + "." + value)) { }
    }
}