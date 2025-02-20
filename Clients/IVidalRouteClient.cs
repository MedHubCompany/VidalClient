using JetBrains.Annotations;
using MedHubCompany.Extensions.Vidal.Models;

namespace MedHubCompany.Extensions.Vidal.Clients;

/// <summary>
/// Specifies the administering routes contract for the Vidal client.
/// </summary>
[PublicAPI]
public interface IVidalRouteClient
{
    /// <summary>
    /// Gets all administering routes from the Vidal API.
    /// </summary>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of administering routes.</returns>
    [MustUseReturnValue]
    Task<VidalAdministeringRoute[]> GetAdministeringRoutesAsync(CancellationToken ct = default);
    
    /// <summary>
    /// Gets a specific administering route from the Vidal API.
    /// </summary>
    /// <param name="routeId">The Vidal ID of the administering route.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The administering route.</returns>
    [MustUseReturnValue]
    Task<VidalAdministeringRoute?> GetAdministeringRouteAsync(int routeId, CancellationToken ct = default);
}