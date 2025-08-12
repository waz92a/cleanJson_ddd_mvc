using CleanJson.Domain.Abstractions;
using CleanJson.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CleanJson.Infrastructure.Http;

public sealed class RemoteJsonSource : IRemoteJsonSource
{
    private readonly HttpClient _http;
    private readonly string _endpoint;

    public RemoteJsonSource(HttpClient http, IOptions<RemoteJsonOptions> options)
    {
        _http = http;
        _endpoint = options.Value.Endpoint ?? string.Empty;
    }

    public async Task<JToken> FetchAsync(CancellationToken ct = default)
    {
        var json = await _http.GetStringAsync(_endpoint, ct);
        return JsonConvert.DeserializeObject<JToken>(json) ?? new JObject();
    }
}
