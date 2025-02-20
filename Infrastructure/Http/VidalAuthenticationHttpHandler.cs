using JetBrains.Annotations;
using Microsoft.Extensions.Options;

namespace MedHubCompany.Extensions.Vidal.Infrastructure.Http;

/// <summary>
/// Represents an HTTP handler for Vidal authentication.
/// </summary>
[UsedImplicitly(ImplicitUseTargetFlags.Itself)]
public sealed class VidalAuthenticationHttpHandler : DelegatingHandler
{
    private readonly IOptionsSnapshot<VidalClientOptions> _options;

    /// <inheritdoc />
    public VidalAuthenticationHttpHandler(IOptionsSnapshot<VidalClientOptions> options)
    {
        _options = options;
    }
    
    /// <inheritdoc />
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        // Modify the request query string to include the AppId and AppKey in query
        UriBuilder uriBuilder = new(request.RequestUri ?? throw new InvalidOperationException("Request URI is null"));
        HttpQueryBuilder queryBuilder = HttpQueryBuilder.FromQuery(uriBuilder.Query);
        queryBuilder.Add("app_id", _options.Value.AppId);
        queryBuilder.Add("app_key", _options.Value.AppKey);
        
        uriBuilder.Query = queryBuilder.ToString();
        request.RequestUri = uriBuilder.Uri;
        
        return await base.SendAsync(request, ct);
    }
}