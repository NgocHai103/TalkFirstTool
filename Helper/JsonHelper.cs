using System.Text.Json;

namespace TF_ClassRegistry.Helper;

public static class JsonHelper
{
    public static T Deserialize<T>(this string jsonString)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        return JsonSerializer.Deserialize<T>(jsonString, options);
    }

    public static string Serialize<T>(this T obj)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        return JsonSerializer.Serialize<T>(obj, options);
    }
}
