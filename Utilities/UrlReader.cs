using Newtonsoft.Json.Linq;

public static class UrlReader
{
    public static string? Get(string key)
    {
        var json = File.ReadAllText("config.json");
        var jsonObj = JObject.Parse(json);
        return jsonObj["Urls"]?[key]?.ToString();
    }
}