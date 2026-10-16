using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.OneSignal.HttpClients.Registrars;
using Soenneker.OneSignal.OpenApiClientUtil.Abstract;

namespace Soenneker.OneSignal.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class OneSignalOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="OneSignalOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddOneSignalOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddOneSignalOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IOneSignalOpenApiClientUtil, OneSignalOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="OneSignalOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddOneSignalOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddOneSignalOpenApiHttpClientAsSingleton()
                .TryAddScoped<IOneSignalOpenApiClientUtil, OneSignalOpenApiClientUtil>();

        return services;
    }
}
