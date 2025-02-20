using JetBrains.Annotations;
using MedHubCompany.Extensions.Vidal.Clients;
using MedHubCompany.Extensions.Vidal.Infrastructure.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MedHubCompany.Extensions.Vidal;

/// <summary>
/// Provides extensions for registering the Vidal HTTP client.
/// </summary>
[PublicAPI]
public static class VidalClientExtensions
{
    /// <summary>
    /// Registers the Vidal HTTP client.
    /// </summary>
    /// <param name="services">The services collection.</param>
    public static void AddVidalClient(this IServiceCollection services)
    {
        // Register the Vidal client + HTTP
        services.AddHttpClient<IVidalClient, VidalClient>(static client =>
        {
            client.BaseAddress = new("https://api.vidal.fr");
        })
            .AddHttpMessageHandler<VidalAuthenticationHttpHandler>();
        
        // Register HTTP handlers
        services.AddTransient<VidalAuthenticationHttpHandler>();
        
        // Register the Vidal client subtypes as lambdas
        services.AddTransient<IVidalAmppClient>(static services => services.GetRequiredService<IVidalClient>());
        services.AddTransient<IVidalPackageClient>(static services => services.GetRequiredService<IVidalClient>());
        services.AddTransient<IVidalProductClient>(static services => services.GetRequiredService<IVidalClient>());
        services.AddTransient<IVidalRouteClient>(static services => services.GetRequiredService<IVidalClient>());
        services.AddTransient<IVidalGalenicClient>(static services => services.GetRequiredService<IVidalClient>());
        services.AddTransient<IVidalSearchClient>(static services => services.GetRequiredService<IVidalClient>());
    }
}