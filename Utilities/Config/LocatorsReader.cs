using Newtonsoft.Json.Linq;

public static class LocatorReader
{
    public static string Get(string key)
    {
        var json = File.ReadAllText("locators.json");
        var jsonObj = JObject.Parse(json);
        return jsonObj["Locators"]?[key]?.ToString();
    }
}