using SmartEnums.Core.Data;

namespace SmartEnums.Tests.Data
{
    public enum Gender
    {
        [EnumValue("Description", "he/him")]
        Male,
        [EnumValue("Description", "she/her")]
        Female,
    }
}