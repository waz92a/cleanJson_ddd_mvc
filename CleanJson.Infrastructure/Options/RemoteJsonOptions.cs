namespace CleanJson.Infrastructure.Options;

public sealed class RemoteJsonOptions
{
    public const string SectionName = "RemoteJson";
    public string Endpoint { get; set; } = string.Empty;
}
