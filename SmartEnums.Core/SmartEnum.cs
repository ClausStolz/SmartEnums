using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartEnums
{
    public static class SmartEnum
    {
        public static IEnumerable<T> GetEnumerator<T>() => Enum.GetValues(typeof(T)).Cast<T>();
    }
}