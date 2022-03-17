// ReSharper disable once CheckNamespace
namespace SmartEnums
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumTagExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
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
}

