using JetBrains.Annotations;
using MedHubCompany.Extensions.Vidal.Models;

namespace MedHubCompany.Extensions.Vidal.Clients;

/// <summary>
/// Specifies the packages contract for the Vidal client.
/// </summary>
/// <remarks>
/// API Reference : http://editeur.vidal.fr/demo/restplayer2/help
/// </remarks>
[PublicAPI]
public interface IVidalProductClient
{
    /// <summary>
    /// Gets the product by its identifier.
    /// </summary>
    /// <param name="productId">The product's CIS.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The product.</returns>
    /// <exception cref="ArgumentException">Thrown when the given CIS is invalid.</exception>
    [MustUseReturnValue]
    Task<VidalProduct?> GetProductByCisAsync(int productId, CancellationToken ct = default);
    
    /// <summary>
    /// Gets the product by its Vidal identifier.
    /// </summary>
    /// <param name="vidalId">The product's Vidal identifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The product.</returns>
    [MustUseReturnValue]
    Task<VidalProduct?> GetProductByVidAsync(int vidalId, CancellationToken ct = default);
    
    /// <summary>
    /// Gets several products by their Vidal identifiers.
    /// </summary>
    /// <param name="vidalIds">The products' Vidal identifiers.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The products that were found.</returns>
    [MustUseReturnValue]
    Task<VidalProduct[]> GetProductsByVidAsync(IEnumerable<int> vidalIds, CancellationToken ct = default);
    
    /// <summary>
    /// Gets a product's administering route by its Vidal identifier.
    /// </summary>
    /// <param name="vidalId">The product's Vidal identifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The administering route.</returns>
    [MustUseReturnValue]
    Task<VidalAdministeringRoute?> GetAdministeringRouteByVidAsync(int vidalId, CancellationToken ct = default);
}