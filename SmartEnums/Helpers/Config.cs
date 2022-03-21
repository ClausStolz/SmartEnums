// ReSharper disable once CheckNamespace
namespace SmartEnums.Helpers;

/// <summary>
/// Helper class configured main options for extensions and classes.
/// </summary>
public static class Config
{
    /// <summary>
    /// Keywords for checking latest version.
    /// </summary>
    public static readonly string[] LatestVersionFlags = new []
    {
        "latest", "newest"
    };

    /// <summary>
    /// Identifier for up-version.
    /// </summary>
    public const char UpVersionFlag = '^';

    /// <summary>
    /// Identifier for default version.
    /// </summary>
    public const string DefaultVersion = "1.0.0";
}