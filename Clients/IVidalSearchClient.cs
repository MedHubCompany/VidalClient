using JetBrains.Annotations;
using MedHubCompany.Extensions.Vidal.Models;
using MedHubCompany.Extensions.Vidal.Models.Atom;

namespace MedHubCompany.Extensions.Vidal.Clients;

/// <summary>
/// Specifies the search contract for the Vidal client.
/// </summary>
/// <remarks>
/// API Reference : http://editeur.vidal.fr/demo/restplayer2/help
/// </remarks>
[PublicAPI]
public interface IVidalSearchClient
{
    /// <summary>
    /// Searches for elements by the specified query, page count and page size.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="page">The page count.</param>
    /// <param name="pageSize">The page size.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The search results.</returns>
    [MustUseReturnValue]
    Task<AtomFeed<SearchResult>> SearchElementsAsync(string query, uint page = 1, uint pageSize = 100, CancellationToken ct = default);
    
    /// <summary>
    /// Searches for packages by the specified query, page count and page size.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="page">The page count.</param>
    /// <param name="pageSize">The page size.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The search results.</returns>
    [MustUseReturnValue]
    Task<AtomFeed<VidalPackage>> SearchPackagesAsync(string query, uint page = 1, uint pageSize = 100, CancellationToken ct = default);
    
    /// <summary>
    /// Searches for products by the specified query, page count and page size.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="page">The page count.</param>
    /// <param name="pageSize">The page size.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The search results.</returns>
    [MustUseReturnValue]
    Task<AtomFeed<VidalProduct>> SearchProductsAsync(string query, uint page = 1, uint pageSize = 100, CancellationToken ct = default);
    
    /// <summary>
    /// Gets a specific element by its identifier.
    /// </summary>
    /// <param name="elementId">The element's identifier. May be a CIP13, UCD13, EAN, CIP7, UCD7, CIS, LPPR, EPHMRA, ATC, CIM10, or MEDICABASE.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The search result, if found; otherwise, <see langword="null"/>.</returns>
    [MustUseReturnValue]
    Task<SearchResult?> SearchElementAsync(string elementId, CancellationToken ct = default);
}