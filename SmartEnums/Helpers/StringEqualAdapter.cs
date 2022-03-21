// ReSharper disable once CheckNamespace
namespace SmartEnums.Helpers;

/// <summary>
/// Implement comparing of strings.
/// </summary>
public class StringEqualAdapter : IDisposable
{
    /// <summary>
    /// Hold string that need to compare.
    /// </summary>
    private string Value { get; set; }

    /// <param name="value">Value that need to compare.</param>
    public StringEqualAdapter(string value)
    {
        Value = value;
    }
    
    /// <param name="obj">Comparing object.</param>
    public override bool Equals(object? obj) => Value.Equals(obj as string);
    
    /// <param name="other">Comparing <see cref="StringEqualAdapter"/> object.</param>
    protected bool Equals(StringEqualAdapter other) => Value == other.Value;

    /// <summary>
    /// Hash code of objects.
    /// </summary>
    public override int GetHashCode() => Value.GetHashCode();
    
    /// <param name="lhs">Object that need to compare.</param>
    /// <param name="rhs">Comparing object.</param>
    public static bool operator ==(StringEqualAdapter lhs, string rhs) => lhs.Value.Equals(rhs);
    
    /// <param name="lhs">Object that need to compare.</param>
    /// <param name="rhs">Comparing object.</param>
    public static bool operator !=(StringEqualAdapter lhs, string rhs) => !(lhs == rhs);
    
    /// <param name="lhs">Object that need to compare.</param>
    /// <param name="rhs">Comparing object.</param>
    public static bool operator <(StringEqualAdapter lhs, string rhs) 
        => string.Compare(lhs.Value, rhs, StringComparison.Ordinal) is -1;
    
    /// <param name="lhs">Object that need to compare.</param>
    /// <param name="rhs">Comparing object.</param>
    public static bool operator >(StringEqualAdapter lhs, string rhs) 
        => string.Compare(lhs.Value, rhs, StringComparison.Ordinal) is 1;
    
    /// <param name="lhs">Object that need to compare.</param>
    /// <param name="rhs">Comparing object.</param>
    public static bool operator <=(StringEqualAdapter lhs, string rhs)  
        => string.Compare(lhs.Value, rhs, StringComparison.Ordinal) is -1 or 0;
    
    /// <param name="lhs">Object that need to compare.</param>
    /// <param name="rhs">Comparing object.</param>
    public static bool operator >=(StringEqualAdapter lhs, string rhs) 
        => string.Compare(lhs.Value, rhs, StringComparison.Ordinal) is 0 or 1;

    /// <summary>
    /// Disposing method.
    /// </summary>
    public void Dispose()
    {
        Value = default!;
    }
}