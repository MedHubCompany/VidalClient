using System.Diagnostics;
using System.Net;
using System.Xml;
using JetBrains.Annotations;
using MedHubCompany.Extensions.Vidal.Infrastructure;
using MedHubCompany.Extensions.Vidal.Infrastructure.Http;
using MedHubCompany.Extensions.Vidal.Models;
using MedHubCompany.Extensions.Vidal.Models.Input;

namespace MedHubCompany.Extensions.Vidal.Clients;

/* ***
 * VidalProductClient.cs
 * (C) 2024 MedHubCompany
 *
 * Contains the implementation of the IVidalProductClient interface.
 */

public partial class VidalClient
{
    /// <inheritdoc />
    [MustUseReturnValue]
    public async Task<VidalProduct?> GetProductByCisAsync(int cis, CancellationToken ct = default)
    {
        if (!cis.IsValidCis())
        {
            // Invalid CIS
            throw new ArgumentException("Invalid CIS.", nameof(cis));
        }
        
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/search{new HttpQueryBuilder(
            new("code", cis.ToString()),
            new("filter", "product")
        )}");
        
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        return (await DeserializeAtomFeedAsync<VidalProduct>(response, ct)).Entries.FirstOrDefault();
    }
    
    /// <inheritdoc />
    [MustUseReturnValue]
    public async Task<VidalProduct?> GetProductByVidAsync(int vidalId, CancellationToken ct = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/product/{vidalId}");
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        if (response.StatusCode is HttpStatusCode.NoContent)
        {
            // No product found
            return null;
        }
        
        return (await DeserializeAtomFeedAsync<VidalProduct>(response, ct)).Entries.FirstOrDefault();
    }

    /// <inheritdoc />
    public async Task<VidalProduct[]> GetProductsByVidAsync(IEnumerable<int> vidalIds, CancellationToken ct = default)
    {
        XmlRequest<XmlIdList> reqInput;
        HttpRequestMessage request;
        HttpResponseMessage response;
        try
        {
            reqInput = new() { Request = new() { Ids = [..vidalIds.Select(static id => $"vidal://product/{id}")] } };

            request = new(HttpMethod.Post, "/rest/api/search/ids?aggregate=PRODUCT");
            SerializeRequestObject(in request, reqInput);

            response = await Client.SendAsync(request, ct);
            response.EnsureSuccessStatusCode();

            return (await DeserializeAtomFeedAsync<VidalProduct>(response, ct)).Entries?.ToArray() ?? [];
        }
        catch (Exception e)
        {
            Debugger.Break();
            Console.WriteLine(e);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task<VidalAdministeringRoute?> GetAdministeringRouteByVidAsync(int vidalId, CancellationToken ct = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/product/{vidalId}/routes");
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        if (response.StatusCode is HttpStatusCode.NoContent)
        {
            // No administering route found
            return null;
        }
        
        return (await DeserializeAtomFeedAsync<VidalAdministeringRoute>(response, ct)).Entries.FirstOrDefault();
    }
}