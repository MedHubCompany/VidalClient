using System.Net;
using JetBrains.Annotations;
using MedHubCompany.Extensions.Vidal.Infrastructure.Http;
using MedHubCompany.Extensions.Vidal.Models;
using MedHubCompany.Extensions.Vidal.Models.Atom;
using Microsoft.Extensions.Primitives;

namespace MedHubCompany.Extensions.Vidal.Clients;

/* ***
 * VidalSearchClient.cs
 * (C) 2024 MedHubCompany
 *
 * Contains the implementation of the IVidalSearchClient interface.
 */

public partial class VidalClient
{
    /// <inheritdoc />
    [MustUseReturnValue]
    public async Task<AtomFeed<SearchResult>> SearchElementsAsync(string query, uint page = 1, uint pageSize = 100, CancellationToken ct = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/search{new HttpQueryBuilder(
            new("q", query),
            new("start-page", page.ToString()),
            new("page-size", pageSize.ToString())
        )}");
        
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        // Read response as Atom XML
        return await DeserializeAtomFeedAsync<SearchResult>(response, ct);
    }

    /// <inheritdoc />
    [MustUseReturnValue]
    public async Task<SearchResult?> SearchElementAsync(string elementId, CancellationToken ct = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/search{new HttpQueryBuilder(
            new KeyValuePair<string, StringValues>("code", elementId)
        )}");
        
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        if (response.StatusCode is HttpStatusCode.NoContent)
        {
            // No element found
            return null;
        }
        
        return (await DeserializeAtomFeedAsync<SearchResult>(response, ct)).Entries!.Single();
    }
    
    /// <inheritdoc />
    public async Task<AtomFeed<VidalPackage>> SearchPackagesAsync(string query, uint page = 1, uint pageSize = 100, CancellationToken ct = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/packages{new HttpQueryBuilder(
            new("q", query),
            new("start-page", page.ToString()),
            new("page-size", pageSize.ToString())
        )}");
        
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        // Read response as Atom XML
        return await DeserializeAtomFeedAsync<VidalPackage>(response, ct);
    }

    /// <inheritdoc />
    public async Task<AtomFeed<VidalProduct>> SearchProductsAsync(string query, uint page = 1, uint pageSize = 100, CancellationToken ct = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/products{new HttpQueryBuilder(
            new("q", query),
            new("start-page", page.ToString()),
            new("page-size", pageSize.ToString())
        )}");
        
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        // Read response as Atom XML
        return await DeserializeAtomFeedAsync<VidalProduct>(response, ct);
    }
}