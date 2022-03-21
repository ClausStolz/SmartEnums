using SmartEnums.Helpers;

// ReSharper disable once CheckNamespace
namespace SmartEnums;

/// <summary>
/// Attribute used to hold metadata field to enums.
/// </summary>
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class EnumValueAttribute : Attribute
{
    /// <summary>
    /// Hold value used to search metadata field.
    /// </summary>
    public string Key { get; }

    /// <summary>
    /// Hold value of metadata field in object type so you need to cast in type
    /// you used when declare metadata field before using.
    /// </summary>
    public object Value { get; }
    
    /// <summary>
    /// Hold version for metadata field . By default version initialized using
    /// <see cref="Config.DefaultVersion"/> property of <see cref="Config"/> class.
    /// </summary>
    public string Version { get; set; }
    
    /// <summary>
    /// Constructor to generate metadata field using attribute.
    /// Notes: Every attribute has version and by default it set using
    /// <see cref="Config.DefaultVersion"/> property of <see cref="Config"/> class.
    /// </summary>
    /// <param name="key">Value for searching metadata fields.</param>
    /// <param name="value">Value of metadata field.</param>
    public EnumValueAttribute(string key, object value)
    {
        Key = key;
        Value = value;
        Version = Config.DefaultVersion;
    }

    /// <summary>
    /// Constructor to generate metadata field with specific version using attribute.
    /// </summary>
    /// <param name="key">Value for searching metadata fields.</param>
    /// <param name="value">Value of metadata field.</param>
    /// <param name="version">Value of specific version of metadata field.</param>
    public EnumValueAttribute(string key, object value, string version) : this(key, value)
    {
        Version = version;
    }
}