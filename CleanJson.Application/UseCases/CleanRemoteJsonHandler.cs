using CleanJson.Domain.Abstractions;
using Newtonsoft.Json.Linq;

namespace CleanJson.Application.UseCases;

/// <summary>
/// Application service (use case) orchestrating the fetch + clean.
/// </summary>
public sealed class CleanRemoteJsonHandler
{
    private readonly IRemoteJsonSource _source;
    private readonly IJsonCleaner _cleaner;

    public CleanRemoteJsonHandler(IRemoteJsonSource source, IJsonCleaner cleaner)
    {
        _source = source;
        _cleaner = cleaner;
    }

    public async Task<JToken> HandleAsync(CancellationToken ct = default)
    {
        var token = await _source.FetchAsync(ct);
        _cleaner.CleanToken(token);
        return token; // keep original types; cleaned in-place
    }
}
