﻿using Newtonsoft.Json.Linq;

namespace specflowdemo.Utilities.Config
{
    public static class ConfigReader
    {
        private static readonly JObject _config;

        static ConfigReader()
        {
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "config.json");
            var configContent = File.ReadAllText(configPath);
            _config = JObject.Parse(configContent);
        }

        public static string GetUrl(string key)
        {
            return _config["Urls"][key].ToString();
        }

        public static string GetSetting(string key)
        {
            return _config["Settings"][key].ToString();
        }
    }
}
