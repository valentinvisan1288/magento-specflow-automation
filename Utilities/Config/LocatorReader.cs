using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace specflowdemo.Utilities.Config
{
    public static class LocatorReader
    {
        private static Dictionary<string, string> _locators;

        static LocatorReader()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "locators.json");
            var locatorsText = File.ReadAllText(path);
            _locators = JsonConvert.DeserializeObject<Dictionary<string, string>>(locatorsText);
        }

        public static string Get(string key)
        {
            if (_locators.ContainsKey(key))
                return _locators[key];

            throw new KeyNotFoundException($"Locator key '{key}' not found in locators.json.");
        }
    }
}
