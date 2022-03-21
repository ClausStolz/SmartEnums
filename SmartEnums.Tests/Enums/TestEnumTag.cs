namespace SmartEnums.Tests.Enums;

public enum EnumTag
{
    [EnumTag("test")]
    [EnumTag("predicate")]
    First,
    [EnumTag("test")]
    Second,
    Third,
}