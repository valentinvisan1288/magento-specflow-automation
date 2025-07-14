using System;

namespace specflowdemo.Utilities
{
    public static class UniqueEmailGenerator
    {
        public static string GenerateUniqueEmail()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            return $"magentovalentin+{timestamp}@test123.com";
        }
    }
}
