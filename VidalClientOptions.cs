using JetBrains.Annotations;

namespace MedHubCompany.Extensions.Vidal;

/// <summary>
/// Represents an options DTO to configure the <see cref="VidalClientBase"/>.
/// </summary>
[PublicAPI]
public class VidalClientOptions
{
    /// <summary>
    /// Gets or sets the AppId.
    /// </summary>
    public string AppId { get; set; } = "";

    /// <summary>
    /// Gets or sets the AppKey.
    /// </summary>
    public string AppKey { get; set; } = "";
}