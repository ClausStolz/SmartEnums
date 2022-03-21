// ReSharper disable once CheckNamespace
namespace SmartEnums;

/// <summary>
/// Extension implemented functional for getting tags
/// in enum element.
/// </summary>
public static class EnumTagExtension
{
    /// <summary>
    /// Return tags for certain enum element. 
    /// </summary>
    /// <param name="obj">Enum element that tags need to receive.</param>
    /// <returns></returns>
    public static IEnumerable<string>? GetEnumTags(this Enum obj)
    {
        var enumType = obj.GetType();
        var memberValueInfos = enumType.GetMember(obj.ToString())
            .FirstOrDefault(x => x.DeclaringType == enumType);

        return memberValueInfos?.GetCustomAttributes(typeof(EnumTagAttribute), false)
            .Select(input => (input as EnumTagAttribute)?.Value)!;
    }
}