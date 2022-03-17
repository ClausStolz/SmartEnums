// ReSharper disable once CheckNamespace
namespace SmartEnums
{
    /// <summary>
    /// Helper static class contain optional functional for enums.
    /// </summary>
    public static class SmartEnum
    {
        /// <summary>
        /// Return enumeration by enum type. 
        /// </summary>
        /// <typeparam name="T">Enum type that need to enumerate</typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetEnumerator<T>() => Enum.GetValues(typeof(T)).Cast<T>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> FindByTag<T>(string tag)
        {
            var elements = GetEnumerator<T>();
            return elements.Where(x => ((x as Enum)!.GetEnumTags() ?? Array.Empty<string>()).Contains(tag));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="flag"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> FindByTag<T>(IEnumerable<string> tags, TagSearchingFlag flag = TagSearchingFlag.Any)
        {
            var elements = GetEnumerator<T>();
            return elements.Where(x =>
            {
                var elementTags = (x as Enum)!.GetEnumTags() ?? Array.Empty<string>();

                return flag switch
                {
                    TagSearchingFlag.All => tags.All(elementTags.Contains), 
                    TagSearchingFlag.Any => tags.Any(elementTags.Contains),
                    _ => throw new ArgumentOutOfRangeException(nameof(flag), flag, null)
                };
            });
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> FindExcludingByTag<T>(string tag)
        {
            var elements = GetEnumerator<T>();
            return elements.Where(x => !((x as Enum)!.GetEnumTags() ?? Array.Empty<string>()).Contains(tag));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="flag"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> FindExcludingByTag<T>(IEnumerable<string> tags, TagSearchingFlag flag = TagSearchingFlag.Any)
        {
            var elements = GetEnumerator<T>();
            return elements.Where(x =>
            {
                var elementTags = (x as Enum)!.GetEnumTags() ?? Array.Empty<string>();
                return flag switch
                {
                    TagSearchingFlag.All => !tags.All(elementTags.Contains), // elementTags.All(tags.Contains),
                    TagSearchingFlag.Any => !tags.Any(elementTags.Contains), //elementTags.Any(tags.Contains),
                    _ => throw new ArgumentOutOfRangeException(nameof(flag), flag, null)
                };
            });
        }
    }
}