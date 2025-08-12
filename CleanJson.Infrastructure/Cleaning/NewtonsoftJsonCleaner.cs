using CleanJson.Domain.Abstractions;
using CleanJson.Domain.Model;
using Newtonsoft.Json.Linq;

namespace CleanJson.Infrastructure.Cleaning;

/// <summary>
/// Implements the domain cleaning rules using Newtonsoft JSON.
/// - Remove all object properties whose value is "", "-", or "N/A".
/// - From arrays, remove elements equal to those invalid strings.
/// - Preserve original number/bool types (we only strip invalid strings).
/// </summary>
public sealed class NewtonsoftJsonCleaner : IJsonCleaner
{
    public void CleanToken(JToken token)
    {
        if (token is JObject obj)
        {
            // Copy properties first because we'll mutate
            foreach (var prop in obj.Properties().ToList())
            {
                var val = prop.Value;

                // If the value is a string and is invalid -> remove property
                if (val.Type == JTokenType.String && CleaningRules.InvalidStrings.Contains(val.ToString()))
                {
                    prop.Remove();
                    continue;
                }

                // Recurse into objects/arrays
                if (val is JObject || val is JArray)
                {
                    CleanToken(val);
                }
            }
        }
        else if (token is JArray arr)
        {
            for (int i = arr.Count - 1; i >= 0; i--)
            {
                var val = arr[i];
                if (val.Type == JTokenType.String && CleaningRules.InvalidStrings.Contains(val.ToString()))
                {
                    arr.RemoveAt(i);
                    continue;
                }
                if (val is JObject || val is JArray)
                {
                    CleanToken(val);
                }
            }
        }
        // primitives (numbers, bools, non-invalid strings) are left as-is
    }
}
