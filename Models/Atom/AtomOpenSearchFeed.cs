using System.Xml.Serialization;
using JetBrains.Annotations;

namespace MedHubCompany.Extensions.Vidal.Models.Atom;

/// <summary>
/// Represents an Atom-based feed with Open Search properties, as returned by the Vidal API.
/// </summary>
/// <seealso cref="AtomFeed" />
[PublicAPI, Serializable]
[XmlRoot("feed", Namespace = AtomXmlNamespace, IsNullable = false)]
public class AtomOpenSearchFeed<TEntry> : AtomFeed<TEntry> where TEntry : AtomFeedEntryBase
{
    /// <summary>
    /// The XML namespace for Open Search properties.
    /// </summary>
    public const string OpenSearchNamespace = "http://a9.com/-/spec/opensearch/1.1/";
    
    /// <summary>
    /// Gets or sets the total number of results.
    /// </summary>
    [XmlElement(ElementName = "totalResults", Namespace = OpenSearchNamespace)]
    public int TotalResults { get; set; }

    /// <summary>
    /// Gets or sets the number of results per page.
    /// </summary>
    [XmlElement(ElementName = "itemsPerPage", Namespace = OpenSearchNamespace)]
    public int ItemsPerPage { get; set; }

    /// <summary>
    /// Gets or sets the start index of the current page.
    /// </summary>
    [XmlElement(ElementName = "startIndex", Namespace = OpenSearchNamespace)]
    public int StartIndex { get; set; }
}