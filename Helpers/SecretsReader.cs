using Newtonsoft.Json.Linq;

public static class ConfigHelper
{
    public static string? GetSecret(string section, string key)
    {
        var json = File.ReadAllText("secrets.json");
        var secrets = JObject.Parse(json);
        return secrets[section]?[key]?.ToString();
    }
}