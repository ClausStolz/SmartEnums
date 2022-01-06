using System;
using System.Text;

namespace SmartEnums.Core.Helpers
{
    public class StringEqualAdapter : IDisposable
    {
        public string Value { get; }

        public StringEqualAdapter(string value)
        {
            Value = value;
        }
        
        public override bool Equals(object? obj) => Value.Equals(obj as string);

        protected bool Equals(StringEqualAdapter other) => Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(StringEqualAdapter lhs, string rhs) => lhs.Value.Equals(rhs);

        public static bool operator !=(StringEqualAdapter lhs, string rhs) => !(lhs == rhs);

        public static bool operator <(StringEqualAdapter lhs, string rhs) 
            => string.Compare(lhs.Value, rhs, StringComparison.Ordinal) is -1;

        public static bool operator >(StringEqualAdapter lhs, string rhs) 
            => string.Compare(lhs.Value, rhs, StringComparison.Ordinal) is 1;

        public static bool operator <=(StringEqualAdapter lhs, string rhs)  
            => string.Compare(lhs.Value, rhs, StringComparison.Ordinal) is -1 or 0;

        public static bool operator >=(StringEqualAdapter lhs, string rhs) 
            => string.Compare(lhs.Value, rhs, StringComparison.Ordinal) is 0 or 1;

        public void Dispose() { }
    }
}