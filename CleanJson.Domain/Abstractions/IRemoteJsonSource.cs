using Newtonsoft.Json.Linq;

namespace CleanJson.Domain.Abstractions;

public interface IRemoteJsonSource
{
    Task<JToken> FetchAsync(CancellationToken ct = default);
}
