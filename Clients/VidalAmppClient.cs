using System.Runtime.CompilerServices;
using System.Threading.Channels;
using MedHubCompany.Extensions.Vidal.Models;
using MedHubCompany.Extensions.Vidal.Models.Atom;

namespace MedHubCompany.Extensions.Vidal.Clients;

/* ***
 * VidalAmppClient.cs
 * (C) 2024 MedHubCompany
 *
 * Contains the implementation of the IVidalAmppClient interface.
 */

public partial class VidalClient
{
    /// <inheritdoc />
    public async Task<AtomOpenSearchFeed<VidalAmppEntry>> GetAmppDumpPageAsync(int page, int size = 100, CancellationToken ct = default)
    {
        if (page <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(page), "The page number must be greater than zero.");
        }
        
        using HttpRequestMessage request = new(HttpMethod.Get, $"/rest/api/dump/ampps?start-page={page}&page-size={size}");
        using HttpResponseMessage response = await Client.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();
        
        AtomOpenSearchFeed<VidalAmppEntry> feed = await DeserializeAtomOpenSearchFeedAsync<VidalAmppEntry>(response, ct);

        return feed;
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<VidalAmppEntry> GetAllAmppDumpPagesAsync(int size = 100, int degreeOfParallelism = 1, [EnumeratorCancellation] CancellationToken ct = default)
    {
        // Start by requesting the first page, so we can calculate the total number of pages.
        AtomOpenSearchFeed<VidalAmppEntry> firstPage = await GetAmppDumpPageAsync(1, size, ct);
        
        // Calculate the total number of pages.
        int totalPages = (int)Math.Ceiling((double)firstPage.TotalResults / size);
        
        // Return those we already have.
        foreach (VidalAmppEntry entry in firstPage.Entries!)
        {
            yield return entry;
        }
        
        // For the remainder, we want to request the pages on a need basis, so we'll use an IAsyncEnumerable for that.
        foreach (int page in Enumerable.Range(2, totalPages - 1).AsParallel().WithCancellation(ct).WithDegreeOfParallelism(degreeOfParallelism))
        {
            AtomOpenSearchFeed<VidalAmppEntry> currentPage = await GetAmppDumpPageAsync(page, size, ct);
            
            foreach (VidalAmppEntry entry in currentPage.Entries!)
            {
                yield return entry;
            }
        }
    }
}