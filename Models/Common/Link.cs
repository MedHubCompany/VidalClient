using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

/// <summary>
/// Represents a link in an Atom feed.
/// </summary>
[XmlRoot(ElementName="link")]
public struct Link 
{ 
    /// <summary>
    /// The relationship of the link.
    /// </summary>
    [XmlAttribute(AttributeName="rel")] 
    public string? Rel { get; set; } 

    /// <summary>
    /// The MIME type of the link.
    /// </summary>
    [XmlAttribute(AttributeName="type")] 
    public string? Type { get; set; }

    /// <summary>
    /// The URI of the link.
    /// </summary>
    [XmlAttribute("href")]
    public string Href { get; set; }

    /// <summary>
    /// The title of the link.
    /// </summary>
    [XmlAttribute(AttributeName="title")] 
    public string? Title { get; set; } 
}