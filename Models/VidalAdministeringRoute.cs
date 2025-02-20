using System.Xml.Serialization;
using MedHubCompany.Extensions.Vidal.Models.Common;

namespace MedHubCompany.Extensions.Vidal.Models;

/// <summary>
/// Represents the administering route of a product on the Vidal API.
/// </summary>
public sealed class VidalAdministeringRoute : VidalEntryBase
{
    /// <summary>
    /// The Vidal ID of the administering route.
    /// </summary>
    [XmlElement("routeId", Namespace = VidalXmlNamespace)]
    public int RouteId { get; set; }
    
    /// <summary>
    /// The Parent ID of the administering route.
    /// </summary>
    [XmlElement("parentId", Namespace = VidalXmlNamespace)]
    public int? ParentId { get; set; }
    
    /// <summary>
    /// The localised name of the administering route.
    /// </summary>
    [XmlElement("name", Namespace = VidalXmlNamespace)]
    public string Name { get; set; } = "";
    
    /// <summary>
    /// Whether the administering route is systemic.
    /// </summary>
    [XmlElement("systemic", Namespace = VidalXmlNamespace)]
    public bool IsSystemic { get; set; }
    
    /// <summary>
    /// Whether the administering route is topical.
    /// </summary>
    [XmlElement("topical", Namespace = VidalXmlNamespace)]
    public bool IsTopical { get; set; }
}