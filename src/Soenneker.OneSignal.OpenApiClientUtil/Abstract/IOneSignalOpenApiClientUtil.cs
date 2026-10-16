using Soenneker.OneSignal.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.OneSignal.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IOneSignalOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<OneSignalOpenApiClient> Get(CancellationToken cancellationToken = default);
}
