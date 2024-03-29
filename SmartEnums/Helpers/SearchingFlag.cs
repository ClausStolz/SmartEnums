// ReSharper disable once CheckNamespace
namespace SmartEnums;

/// <summary>
/// Hold types to searching for
/// <see cref="SmartEnums.EnumTagAttribute"/> using
/// searching methods realized in
/// <see cref="SmartEnum"/>.
/// </summary>
public enum SearchingFlag
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