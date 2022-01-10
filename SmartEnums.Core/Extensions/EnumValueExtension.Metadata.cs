using System;
using System.Collections.Generic;
using System.Linq;


namespace SmartEnums
{
    public static partial class EnumValueExtension
    {
        public static string GetJsonMetadata(this Enum element) 
            => System.Text.Json.JsonSerializer.Serialize(element.GetMetadata());

        private static IEnumerable<object>? GetMetadata(this Enum element) 
            => element.GetEnumValueAttributes()?.Select(x => new
            {
                Key = x!.Key,
                Value = x.Value,
                Version = x.Version
            });
        private static IEnumerable<EnumValueAttribute?>? GetEnumValueAttributes(this Enum element)
        {
            var enumType = element.GetType();
            var memberValueInfos = enumType.GetMember(element.ToString())
                .FirstOrDefault(x => x.DeclaringType == enumType);

            return memberValueInfos?.GetCustomAttributes(typeof(EnumValueAttribute), false)
                .Select(input => input as EnumValueAttribute);
        }
    }
}