using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartEnums
{
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