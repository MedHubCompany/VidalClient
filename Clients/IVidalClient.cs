using JetBrains.Annotations;

namespace MedHubCompany.Extensions.Vidal.Clients;

/// <summary>
/// Specifies the Vidal client, using its sub-interface contracts.
/// </summary>
[PublicAPI]
public interface IVidalClient :
    IVidalAmppClient,
    IVidalGalenicClient,
    IVidalPackageClient,
    IVidalProductClient,
    IVidalRouteClient,
    IVidalSearchClient;