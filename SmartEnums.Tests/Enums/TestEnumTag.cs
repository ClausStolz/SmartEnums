namespace SmartEnums.Tests.Enums;

public enum TestEnumTag
{
    [EnumTag("test")]
    [EnumTag("predicate")]
    First,
    [EnumTag("test")]
    Second,
    Third,
}