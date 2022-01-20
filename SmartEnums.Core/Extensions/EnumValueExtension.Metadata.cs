using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace SmartEnums
{
    public static partial class EnumValueExtension
    {
        /// <summary>
        /// Returns the metadata of an enum object based on an
        /// <see cref="SmartEnums.EnumValueAttribute"/> serialized to json.
        /// </summary>
        /// <param name="obj">Enum object.</param>
        /// <returns>Metadata of enum serialized to json in string type</returns>
        public static string GetJsonMetadata(this Enum obj) 
            => System.Text.Json.JsonSerializer.Serialize(obj.GetMetadata());
        
        /// <summary>
        /// Returns the metadata of an enum object based on an
        /// <see cref="SmartEnums.EnumValueAttribute"/> serialized to xml.
        /// </summary>
        /// <param name="obj">Enum object.</param>
        /// <returns>Metadata of enum serialized to xml in string type</returns>
        public static string GetXmlMetadata(this Enum obj)
        {
            var result = new XElement(XmlConvert.EncodeName(obj.ToString()));
            var metaData = obj.GetMetadata();

            if (metaData is null) return result.ToString();

            foreach (var data in metaData)
            {
                var element = new XElement(XmlConvert.EncodeName("attribute"));
			
                var type = data.GetType();
                var props = type.GetProperties();

                var fields = from prop in props
                    let value = new XElement(XmlConvert.EncodeName(prop.Name), prop.GetValue(data, null))
                    where value is not null
                    select value;

                element.Add(fields);
                result.Add(element);
            }

            return result.ToString();
        }
        
        private static IEnumerable<object>? GetMetadata(this Enum obj) 
            => obj.GetEnumValueAttributes()?.Select(x => new
            {
                x!.Key,
                x.Value,
                x.Version
            });
        
        private static IEnumerable<EnumValueAttribute?>? GetEnumValueAttributes(this Enum obj)
        {
            var enumType = obj.GetType();
            var memberValueInfos = enumType.GetMember(obj.ToString())
                .FirstOrDefault(x => x.DeclaringType == enumType);

            return memberValueInfos?.GetCustomAttributes(typeof(EnumValueAttribute), false)
                .Select(input => input as EnumValueAttribute);
        }
    }
}