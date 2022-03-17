// ReSharper disable once CheckNamespace
namespace SmartEnums
{
    /// <summary>
    /// Attribute used to tag enum with specific data.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class EnumTagAttribute : Attribute
    {
        /// <summary>
        /// Hold value of tag.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Constructor to generate metadata tag for enum using attribute.
        /// </summary>
        /// <param name="value">Specific tag data.</param>
        public EnumTagAttribute(string value)
        {
            Value = value;
        }
    }
}

