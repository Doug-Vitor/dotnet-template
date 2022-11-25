using System.Text.Json;

public static class JsonHelpers
{
    public static T FromJson<T>(this string json) => JsonSerializer.Deserialize<T>(json);
    public static string ToJson<T>(this T serializable) => JsonSerializer.Serialize<T>(serializable);
}