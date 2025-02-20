using System.Net;
using MedHubCompany.Extensions.Vidal.Infrastructure;
using MedHubCompany.Extensions.Vidal.Infrastructure.Http;
using MedHubCompany.Extensions.Vidal.Models;
using Microsoft.Extensions.Primitives;

namespace MedHubCompany.Extensions.Vidal.Clients;

/* ***
 * VidalPackageClient.cs
 * (C) 2024 MedHubCompany
 *
 * Contains the implementation of the IVidalPackageClient interface.
 */

public partial class VidalClient
{
    /// <inheritdoc />
    public async Task<VidalPackage?> GetPackageByCip13Async(long cip13, CancellationToken ct = default)
    {
        if (!cip13.IsValidCip13())
        {
            // Invalid CIP13
            throw new ArgumentException("Invalid CIP13.", nameof(cip13));
        }
        
        return await GetPackageByCipAsync(cip13.ToString(), ct);
    }

    /// <inheritdoc />
    public async Task<VidalPackage?> GetPackageByCip7Async(int cip7, CancellationToken ct = default)
    {
        if (!cip7.IsValidCip7())
        {
            // Invalid CIP7
            throw new ArgumentException("Invalid CIP7.", nameof(cip7));
        }
        
        return await GetPackageByCipAsync(cip7.ToString(), ct);
    }

    /// <inheritdoc />
    public async Task<VidalPackage?> GetPackageByVidAsync(int vidalId, CancellationToken ct = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/package/{vidalId}");
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        if (response.StatusCode is HttpStatusCode.NoContent)
        {
            // No package found
            return null;
        }
        
        return (await DeserializeAtomFeedAsync<VidalPackage>(response, ct)).Entries.Single();
    }
    
    private async Task<VidalPackage?> GetPackageByCipAsync(string cip, CancellationToken ct = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/search{new HttpQueryBuilder(
            new KeyValuePair<string, StringValues>("code", cip),
            new KeyValuePair<string, StringValues>("filter", "package")
        )}");
        
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();

        if (response.StatusCode is HttpStatusCode.NoContent)
        {
            // No package found
            return null;
        }
        
        return (await DeserializeAtomFeedAsync<VidalPackage>(response, ct)).Entries.First();
    }
}