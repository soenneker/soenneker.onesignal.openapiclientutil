using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.OneSignal.HttpClients.Abstract;
using Soenneker.OneSignal.OpenApiClientUtil.Abstract;
using Soenneker.OneSignal.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.OneSignal.OpenApiClientUtil;

///<inheritdoc cref="IOneSignalOpenApiClientUtil"/>
public sealed class OneSignalOpenApiClientUtil : IOneSignalOpenApiClientUtil
{
    private readonly AsyncSingleton<OneSignalOpenApiClient> _client;

    public OneSignalOpenApiClientUtil(IOneSignalOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<OneSignalOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("OneSignal:ApiKey");
            string authHeaderName = configuration["OneSignal:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["OneSignal:AuthHeaderValueTemplate"] ?? "Key {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);

            return new OneSignalOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<OneSignalOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
