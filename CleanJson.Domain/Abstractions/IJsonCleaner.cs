using Newtonsoft.Json.Linq;

namespace CleanJson.Domain.Abstractions;

public interface IJsonCleaner
{
    /// <summary>
    /// Cleans a JSON token in-place according to domain rules.
    /// </summary>
    /// <param name="token">Mutable JSON token (JObject/JArray/JValue).</param>
    void CleanToken(JToken token);
}
