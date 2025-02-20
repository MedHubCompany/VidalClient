using System.Net;
using JetBrains.Annotations;
using MedHubCompany.Extensions.Vidal.Infrastructure.Http;
using MedHubCompany.Extensions.Vidal.Models;
using Microsoft.Extensions.Primitives;

namespace MedHubCompany.Extensions.Vidal.Clients;

/* ***
 * VidalGalenicClient.cs
 * (C) 2024 MedHubCompany
 *
 * Contains the implementation of the IVidalGalenicClient interface.
 */

public partial class VidalClient
{
    /// <inheritdoc />
    [MustUseReturnValue]
    public async Task<VidalGalenicForm[]> GetGalenicFormsAsync(CancellationToken ct = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/galenic-forms{new HttpQueryBuilder(
            new KeyValuePair<string, StringValues>("page-size", ushort.MaxValue.ToString())
        )}");
        
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        return await DeserializeAtomFeedAsync<VidalGalenicForm>(response, ct);
    }

    /// <inheritdoc />
    [MustUseReturnValue]
    public async Task<VidalGalenicForm?> GetGalenicFormAsync(int galenicFormId, CancellationToken ct = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/galenic-form/{galenicFormId}");
        
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        if (response.StatusCode is HttpStatusCode.NoContent)
        {
            // No galenic form found
            return null;
        }

        /* NB: We're always assuming that a ./{id} response will contain only one entry ; that of the requested ID.
         * However, this particular API endpoint returns the requested entity by ID as first entry,
         * but also related entities as subsequent entries.
         * 
         * Ergo, use First() instead of Single().
         */
        return (await DeserializeAtomFeedAsync<VidalGalenicForm>(response, ct)).Entries.First();
    }
}