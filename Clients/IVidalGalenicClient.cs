using JetBrains.Annotations;
using MedHubCompany.Extensions.Vidal.Models;

namespace MedHubCompany.Extensions.Vidal.Clients;

/// <summary>
/// Specifies the Galenic forms contract for the Vidal client.
/// </summary>
public interface IVidalGalenicClient
{
    /// <summary>
    /// Gets all Galenic forms from the Vidal API.
    /// </summary>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of Galenic forms.</returns>
    [MustUseReturnValue]
    Task<VidalGalenicForm[]> GetGalenicFormsAsync(CancellationToken ct = default);
    
    /// <summary>
    /// Gets a specific Galenic form from the Vidal API.
    /// </summary>
    /// <param name="galenicFormId">The Vidal ID of the Galenic form.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The Galenic form.</returns>
    [MustUseReturnValue]
    Task<VidalGalenicForm?> GetGalenicFormAsync(int galenicFormId, CancellationToken ct = default);
}