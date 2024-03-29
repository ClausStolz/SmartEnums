// ReSharper disable once CheckNamespace
namespace SmartEnums;

/// <summary>
/// Deprecated see 
/// <see cref="SmartEnums.SearchingFlag"/>.
/// </summary>
public enum TagSearchingFlag
{
    /// <summary>
    /// Indicated to need to search elements where any
    /// tags is match with searching tags list.
    /// </summary>
    Any,
    /// <summary>
    /// Indicated to need to search elements where all
    /// tags is match with searching tags list.
    /// </summary>
    All,
}