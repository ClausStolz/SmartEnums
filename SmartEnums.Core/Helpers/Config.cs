namespace SmartEnums.Core.Helpers
{
    public static class Config
    {
        public static readonly string[] LatestVersionFlags = new []
        {
            "latest", "newest"
        };

        public const char UpVersionFlag = '^';

        public const string DefaultVersion = "1.0.0";
    }
}