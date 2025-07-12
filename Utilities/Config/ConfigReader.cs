using Newtonsoft.Json;

namespace specflowdemo.Utilities.Configuration
{
    public static class ConfigReader
    {
        private static Dictionary<string, string> _config;

        static ConfigReader()
        {
            var configText = File.ReadAllText("Utilities/Config/config.json");
            _config = JsonSerializer.Deserialize<Dictionary<string, string>>(configText);
        }

        public static string GetUrl(string key)
        {
            if (_config.ContainsKey(key))
                return _config[key];

            throw new KeyNotFoundException($"Key '{key}' not found in config.json.");
        }

        public static string BaseUrl => configData["BaseUrl"].ToString();
        public static string ValidEmail => configData["Credentials"]["Email"].ToString();
        public static string ValidPassword => configData["Credentials"]["Password"].ToString();
        public static string InvalidEmail => configData["Credentials"]["InvalidEmail"].ToString();
        public static string InvalidPassword => configData["Credentials"]["InvalidPassword"].ToString();
    }
}
