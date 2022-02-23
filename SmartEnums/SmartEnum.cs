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
    }
}