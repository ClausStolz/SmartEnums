using System;
using System.Linq;


namespace SmartEnums
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
                throw new FieldNotImplementException(key, element);
            }
            
            return valueOf.Value is T value 
                ? value
                : throw new WrongEnumValueTypeException(key, typeof(T));
        }
    }
}