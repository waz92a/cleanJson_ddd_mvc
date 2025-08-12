namespace CleanJson.Domain.Model;

/// <summary>
/// Domain rules for what string values are considered empty/invalid.
/// </summary>
public static class CleaningRules
{
    public static readonly HashSet<string> InvalidStrings = new(StringComparer.Ordinal)
    {
        string.Empty,
        "-",
        "N/A"
    };
}
