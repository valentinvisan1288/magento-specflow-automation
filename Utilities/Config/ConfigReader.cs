using Newtonsoft.Json.Linq;

namespace specflowdemo.Utilities.Configuration
{
    public static class ConfigReader
    {
        private static JObject configData;

        static ConfigReader()
        {
            var configFile = File.ReadAllText("Configuration/config.json");
            configData = JObject.Parse(configFile);
        }

        public static string BaseUrl => configData["BaseUrl"].ToString();
        public static string ValidEmail => configData["Credentials"]["Email"].ToString();
        public static string ValidPassword => configData["Credentials"]["Password"].ToString();
        public static string InvalidEmail => configData["Credentials"]["InvalidEmail"].ToString();
        public static string InvalidPassword => configData["Credentials"]["InvalidPassword"].ToString();
    }
}
