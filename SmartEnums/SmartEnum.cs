// ReSharper disable once CheckNamespace
namespace SmartEnums;

/// <summary>
/// Helper static class contain optional functional for enums.
/// </summary>
public static class SmartEnum
{
    /// <summary>
    /// Return enumeration by enum type. 
    /// </summary>
    /// <typeparam name="T">Enum type that need to enumerate.</typeparam>
    public static IEnumerable<T> GetEnumerator<T>() where T: Enum => Enum.GetValues(typeof(T)).Cast<T>();
    
    /// <summary>
    /// Searching elements in enum that have certain tag.
    /// </summary>
    /// <param name="tag">Single searching tag.</param>
    /// <typeparam name="T">Enum type where search elements.</typeparam>
    public static IEnumerable<T> FindByTag<T>(string tag) where T: Enum
    {
        var elements = GetEnumerator<T>();
        return elements.Where(x => ((x as Enum)!.GetEnumTags() ?? Array.Empty<string>()).Contains(tag));
    }

    /// <summary>
    /// Searching elements in enum that have certain tags.
    /// </summary>
    /// <param name="tags">Searching tags list.</param>
    /// <param name="flag">Flag indicates how need to search via tags.</param>
    /// <typeparam name="T">Enum type where search elements.</typeparam>
    public static IEnumerable<T> FindByTag<T>(IEnumerable<string> tags, TagSearchingFlag flag = TagSearchingFlag.Any) 
        where T: Enum
    {
        var elements = GetEnumerator<T>();
        return elements.Where(x =>
        {
            var elementTags = (x as Enum)!.GetEnumTags() ?? Array.Empty<string>();

            return flag switch
            {
                TagSearchingFlag.All => tags.All(elementTags.Contains), 
                TagSearchingFlag.Any => tags.Any(elementTags.Contains),
                _ => throw new ArgumentOutOfRangeException(nameof(flag), flag, null)
            };
        });
    }
    
    /// <summary>
    /// Searching elements in enum that have not certain tag.
    /// </summary>
    /// <param name="tag">Single excluding tag.</param>
    /// <typeparam name="T">Enum type where search elements.</typeparam>
    public static IEnumerable<T> FindExcludingByTag<T>(string tag) where T: Enum
    {
        var elements = GetEnumerator<T>();
        return elements.Where(x => !((x as Enum)!.GetEnumTags() ?? Array.Empty<string>()).Contains(tag));
    }
    
    /// <summary>
    /// Searching elements in enum that have not certain tags.
    /// </summary>
    /// <param name="tags">Excluding tags list.</param>
    /// <param name="flag">Flag indicates how need to search via tags.</param>
    /// <typeparam name="T">Enum type where search elements.</typeparam>
    /// <returns></returns>
    public static IEnumerable<T> FindExcludingByTag<T>(IEnumerable<string> tags, TagSearchingFlag flag = TagSearchingFlag.Any)
        where T: Enum
    {
        var elements = GetEnumerator<T>();
        return elements.Where(x =>
        {
            var elementTags = (x as Enum)!.GetEnumTags() ?? Array.Empty<string>();
            return flag switch
            {
                TagSearchingFlag.All => !tags.All(elementTags.Contains),
                TagSearchingFlag.Any => !tags.Any(elementTags.Contains),
                _ => throw new ArgumentOutOfRangeException(nameof(flag), flag, null)
            };
        });
    }

    /// <summary>
    /// Getting enum element by string name.
    /// </summary>
    /// <param name="name">Name of enum element.</param>
    /// <typeparam name="T">Enum where trying to get element.</typeparam>
    /// <returns></returns>
    public static T ToEnum<T>(string name) where  T: Enum => (T)Enum.Parse(typeof(T), name);
}