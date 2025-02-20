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
public interface IVidalPackageClient
{
    /// <summary>
    /// Gets a package by its CIP13.
    /// </summary>
    /// <param name="cip13">The package's CIP13 identifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The package, if found.</returns>
    /// <exception cref="ArgumentException">Thrown when the given CIP13 is invalid.</exception>
    [MustUseReturnValue]
    Task<VidalPackage?> GetPackageByCip13Async(long cip13, CancellationToken ct = default);
    
    /// <summary>
    /// Gets a package by its CIP7.
    /// </summary>
    /// <param name="cip7">The package's CIP7 identifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The package, if found.</returns>
    /// <exception cref="ArgumentException">Thrown when the given CIP7 is invalid.</exception>
    [MustUseReturnValue]
    Task<VidalPackage?> GetPackageByCip7Async(int cip7, CancellationToken ct = default);
    
    /// <summary>
    /// Gets a package by its Vidal identifier.
    /// </summary>
    /// <param name="vidalId">The package's Vidal identifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The package, if found.</returns>
    [MustUseReturnValue]
    Task<VidalPackage?> GetPackageByVidAsync(int vidalId, CancellationToken ct = default);
}