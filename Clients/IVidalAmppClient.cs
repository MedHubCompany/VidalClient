using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using MedHubCompany.Extensions.Vidal.Models;
using MedHubCompany.Extensions.Vidal.Models.Atom;

namespace MedHubCompany.Extensions.Vidal.Clients;



/// <summary>
/// Represents a client for the Vidal AMPP API.
/// </summary>
[PublicAPI]
public interface IVidalAmppClient
{
    /// <summary>
    /// Requests a given page of the Vidal AMPPs Dump API.
    /// </summary>
    /// <param name="page">The page number to request.</param>
    /// <param name="size">The size of the page to request.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The response from the API.</returns>
    /// <remarks>
    /// Requests with large sizes will take exponentially longer to process.
    /// It is recommended that you use a size of 100 or less.
    /// </remarks>
    Task<AtomOpenSearchFeed<VidalAmppEntry>> GetAmppDumpPageAsync(int page, int size = 100, CancellationToken ct = default);

    /// <summary>
    /// Requests all pages of the Vidal AMPPs Dump API.
    /// </summary>
    /// <param name="size">
    /// The size of each page to request.
    /// Unless you have a specific reason to change this, it is recommended to leave this at 100.
    /// </param>
    /// <param name="degreeOfParallelism">The number of pages to request in parallel.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The response from the API.</returns>
    /// <remarks>
    /// This method will request all pages of the API, which may take a long time.
    /// It is recommended that you use <see cref="GetAmppDumpPageAsync"/> instead.
    /// </remarks>
    /// <seealso cref="GetAmppDumpPageAsync"/>
    IAsyncEnumerable<VidalAmppEntry> GetAllAmppDumpPagesAsync(int size = 100, int degreeOfParallelism = 1, CancellationToken ct = default);
}