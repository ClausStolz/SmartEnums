using System;
using System.Collections.Generic;
using System.Linq;
using SmartEnums.Helpers;

// ReSharper disable once CheckNamespace
namespace SmartEnums
{
    /// <summary>
    /// Extension implemented main functional for searching value by key
    /// in metadata fields.
    /// </summary>
    public static partial class EnumValueExtension
    {
        /// <summary>
        /// Return the value of the custom field through an
        /// <see cref="SmartEnums.EnumValueAttribute"/> by key.
        /// If enum element has some equal fields with another
        /// versions method will return the field with newest version. 
        /// </summary>
        /// <param name="obj">Enumeration object.</param>
        /// <param name="key">Key of custom field.</param>
        /// <typeparam name="T">
        /// Type to cast. By default <see cref="SmartEnums.EnumValueAttribute"/>
        /// hold value in object type.
        /// </typeparam>
        public static T GetValueOf<T>(this Enum obj, string key)
        {
            var valueAttributes = obj.GetEnumValueAttributes();

            var valueOf = valueAttributes?
                .Where(x => x?.Key == key)
                .MaxBy(x => x?.Version);

            return valueOf is not null
                ? valueOf.Value.TypeCasting<T>(key)
                : throw new FieldNotImplementException(key, obj);
        }
        
        /// <summary>
        /// Return the value of the custom field through an
        /// <see cref="SmartEnums.EnumValueAttribute"/> by key and version.
        /// You can get either a specific version, or you can tell the method
        /// to return the newest version using keywords: "newest", "latest",
        /// or a version that is newer than the specified one using the symbol
        /// '^' at the beginning of the version parameter.
        /// </summary>
        /// <param name="obj">Enumeration object.</param>
        /// <param name="key">Key of custom field.</param>
        /// <param name="version">Version of custom field.</param>
        /// <typeparam name="T">
        /// Type to cast. By default <see cref="SmartEnums.EnumValueAttribute"/>
        /// hold value in object type.
        /// </typeparam>
        public static T GetValueOf<T>(this Enum obj, string key, string version)
        {
            var valueAttributes = obj.GetEnumValueAttributes();

            var valuesOf = valueAttributes?.Where( 
                x => x?.Key == key);

            if (valuesOf is null) throw new FieldNotImplementException(key, obj);

            return version is not null
                ? valuesOf!.FindVersion(key, version, obj)!.Value.TypeCasting<T>(key)
                : throw new ArgumentNullException(nameof(version));
        }
        
        private static EnumValueAttribute FindVersion(this IEnumerable<EnumValueAttribute> valuesOf, 
            string key, string version, Enum obj)
        {
            if (Config.LatestVersionFlags.Contains(version))
            {
                return valuesOf.MaxBy(x => x.Version)!;
            }
            
            if (version[0].Equals(Config.UpVersionFlag))
            {
                var valueOf = valuesOf.MaxBy(x => x.Version)!;
                return new StringEqualAdapter(valueOf.Version) >= version.Remove(0, 1)
                    ? valueOf
                    : throw new OnlyOlderVersionImplementationException(key, version, obj);
            }
            return valuesOf.FirstOrDefault(x => x.Version.Equals(version)) 
                   ?? throw new VersionNotImplementException(key, version, obj);
        }
        
        private static T TypeCasting<T>(this object value, string key)
        {
            return value is T typeCastingValue 
                ? typeCastingValue 
                : throw new WrongEnumValueTypeException(key, typeof(T));
        }
    }
}