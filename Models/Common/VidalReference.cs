using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

/// <summary>
/// Represents a reference within the Vidal API.
/// </summary>
[DataContract, DebuggerDisplay("{VidalId} - {Value}")]
public struct VidalReference
{
    /// <summary>
    /// The Vidal ID.
    /// </summary>
    [XmlAttribute("vidalId")]
    public int VidalId { get; set; }

    /// <summary>
    /// The value.
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}