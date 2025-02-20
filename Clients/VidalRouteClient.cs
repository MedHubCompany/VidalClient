using System.Net;
using MedHubCompany.Extensions.Vidal.Infrastructure.Http;
using MedHubCompany.Extensions.Vidal.Models;
using Microsoft.Extensions.Primitives;

namespace MedHubCompany.Extensions.Vidal.Clients;

/* ***
 * VidalRouteClient.cs
 * (C) 2024 MedHubCompany
 *
 * Contains the implementation of the IVidalRouteClient interface.
 */


public partial class VidalClient
{
    /// <inheritdoc />
    public async Task<VidalAdministeringRoute[]> GetAdministeringRoutesAsync(CancellationToken ct = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/routes{new HttpQueryBuilder(
            new KeyValuePair<string, StringValues>("page-size", ushort.MaxValue.ToString())
        )}");
        
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        return await DeserializeAtomFeedAsync<VidalAdministeringRoute>(response, ct);
    }
    
    /// <inheritdoc />
    public async Task<VidalAdministeringRoute?> GetAdministeringRouteAsync(int routeId, CancellationToken ct = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/route/{routeId}");
        
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        if (response.StatusCode is HttpStatusCode.NoContent)
        {
            // No route found
            return null;
        }

        return (await DeserializeAtomFeedAsync<VidalAdministeringRoute>(response, ct)).Entries.Single();
    }
}