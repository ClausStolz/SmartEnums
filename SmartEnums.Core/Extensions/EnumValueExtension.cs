using System;
using System.Collections.Generic;
using System.Linq;


namespace SmartEnums
{
    public static class EnumValueExtension
    {
        public static T GetValueOf<T>(this Enum element, string key)
        {
            var valueAttributes = element.GetEnumValueAttributes();

            var valueOf = valueAttributes?.FirstOrDefault(x => (x?.Key == key));

            return valueOf is not null
                ? valueOf.Value.TypeCasting<T>(key)
                : throw new FieldNotImplementException(key, element);
        }
        
        public static T GetValueOf<T>(this Enum element, string key, string version)
        {
            if (version == null) throw new ArgumentNullException(nameof(version));
            
            var valueAttributes = element.GetEnumValueAttributes();

            var valuesOf = valueAttributes?.Where( 
                x => x?.Key == key);

            if (valuesOf is null) throw new FieldNotImplementException(key, element);

            return version switch
            {
                null     => throw new NullReferenceException(),
                "latest" => valuesOf!.MaxBy(x => x?.Version)!.Value.TypeCasting<T>(key),
                _        => valuesOf!.FindVersion(key, version, element)!.Value.TypeCasting<T>(key),
            };
        }

        private static IEnumerable<EnumValueAttribute?>? GetEnumValueAttributes(this Enum element)
        {
            var enumType = element.GetType();
            var memberValueInfos = enumType.GetMember(element.ToString())
                .FirstOrDefault(x => x.DeclaringType == enumType);

            return memberValueInfos?.GetCustomAttributes(typeof(EnumValueAttribute), false)
                .Select(input => input as EnumValueAttribute);
        }
        
        private static EnumValueAttribute FindVersion(this IEnumerable<EnumValueAttribute> valuesOf, 
            string key, string version, Enum element)
        {
            return valuesOf.FirstOrDefault(x => x.Version.Equals(version)) 
                   ?? throw new VersionNotImplementException(key, version, element);
        }
        
        private static T TypeCasting<T>(this object value, string key)
        {
            return value is T typeCastingValue 
                ? typeCastingValue 
                : throw new WrongEnumValueTypeException(key, typeof(T));
        }
    }
}