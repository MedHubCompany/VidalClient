using System.Runtime.Serialization;
using System.Xml.Serialization;
using MedHubCompany.Extensions.Vidal.Models.Atom;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

/// <summary>
/// Represents the base class for a Vidal Api specific Atom entry.
/// </summary>
public abstract class VidalEntryBase : AtomFeedEntryBase
{
    /// <summary>
    /// The DateOnly format for Vidal date values.
    /// </summary>
    [XmlIgnore, IgnoreDataMember]
    public const string VidalDateFormat = "yyyy-MM-dd";

    /// <summary>
    /// The namespace declared by the Vidal API for its XML elements.
    /// </summary>
    public const string? VidalXmlNamespace = "http://api.vidal.net/-/spec/vidal-api/1.0/";

    /// <summary>
    /// The Vidal ID of the entry.
    /// </summary>
    [XmlElement("id", Namespace = VidalXmlNamespace)]
    public int VidalId { get; set; }
    
    /// <summary>
    /// The Vidal API object category.
    /// </summary>
    [XmlAttribute("categories", Namespace = VidalXmlNamespace)]
    public string VidalCategory { get; set; } = "";
}