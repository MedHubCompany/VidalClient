using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

/// <summary>
/// Represents a ID/Value pair with an optional name, within the Vidal API.
/// </summary>
[DataContract, DebuggerDisplay("{VidalId}:{Name} - {Value}")]
public struct VidalNamedReference
{
    /// <summary>
    /// The Vidal ID.
    /// </summary>
    [XmlAttribute("vidalId")]
    public int VidalId { get; set; }

    /// <summary>
    /// The name.
    /// </summary>
    [XmlAttribute("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The value.
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}