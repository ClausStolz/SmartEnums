using System;
using System.ComponentModel;
using System.Linq;
using SmartEnums.Core.Data;

namespace SmartEnums.Core.Extensions
{
    public static class EnumValueExtension
    {
        public static T GetValueOf<T>(this Enum element, string key)
        {
            var enumType = element.GetType();
            var memberValueInfos = enumType.GetMember(element.ToString())
                .FirstOrDefault(x => x.DeclaringType == enumType);
            var valueAttributes = memberValueInfos?.GetCustomAttributes(typeof(EnumValueAttribute), false);

            var valueOf = (valueAttributes?.FirstOrDefault(x =>
                (x as EnumValueAttribute)?.Key == key) as EnumValueAttribute);

            if (valueOf is null)
            {
                throw new Exception();
            }
            
            return (T)valueOf.Value;
        }
        
        public static T CastObject<T>(this object input) {   
            return (T) input;   
        }
    }
}