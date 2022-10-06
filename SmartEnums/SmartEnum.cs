// ReSharper disable once CheckNamespace
namespace SmartEnums;

/// <summary>
/// Helper static class contain optional functional for enums.
/// </summary>
public static partial class SmartEnum
{
    /// <summary>
    /// Return enumeration by enum type. 
    /// </summary>
    /// <typeparam name="T">Enum type that need to enumerate.</typeparam>
    public static IEnumerable<T> GetEnumerator<T>() where T: Enum => Enum.GetValues(typeof(T)).Cast<T>();

    /// <summary>
    /// Getting enum element by string name.
    /// </summary>
    /// <param name="name">Name of enum element.</param>
    /// <typeparam name="T">Enum where trying to get element.</typeparam>
    /// <returns></returns>
    public static T ToEnum<T>(string name) where  T: Enum => (T)Enum.Parse(typeof(T), name);
}