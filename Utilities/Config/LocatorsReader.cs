using Newtonsoft.Json;


public static class LocatorsReader
{
    private static Dictionary<string, string> _locators;

    static LocatorsReader()
    {
        var locatorsText = File.ReadAllText("Utilities/Config/Locators.json");
        _locators = JsonSerializer.Deserialize<Dictionary<string, string>>(locatorsText);
    }

    public static string Get(string key)
    {
        if (_locators.ContainsKey(key))
            return _locators[key];

        throw new KeyNotFoundException($"Locator key '{key}' not found in Locators.json.");
    }
}