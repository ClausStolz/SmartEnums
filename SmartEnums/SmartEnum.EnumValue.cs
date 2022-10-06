// ReSharper disable once CheckNamespace
namespace SmartEnums;

public static partial class SmartEnum
{
    /// <summary>
    /// Searching elements in enum that have certain tag.
    /// </summary>
    /// <param name="key">Single searching key.</param>
    /// <param name="value">The value contained in the search enum value.</param>
    /// <typeparam name="T">Enum type where search elements.</typeparam>
    /// <typeparam name="TK">Type of value contained in the search enum value.</typeparam>
    public static IEnumerable<T> FindByKey<T>(string key)
        where T : Enum
    {
        var elements = GetEnumerator<T>();
        return elements.Where(x => x.ContainKey(key)).ToList();
    }

    /// <summary>
    /// Searching elements in enum that have certain tag.
    /// </summary>
    /// <param name="key">Single searching key.</param>
    /// <param name="value">The value contained in the search enum value.</param>
    /// <typeparam name="T">Enum type where search elements.</typeparam>
    /// <typeparam name="TK">Type of value contained in the search enum value.</typeparam>
    public static IEnumerable<T> FindByValue<T, TK>(string key, TK value) 
        where T: Enum
    {
        var elements = GetEnumerator<T>();
        return elements.Where(x => x.GetValueOf<TK>(key)!.Equals(value)).ToList();
    }
}
