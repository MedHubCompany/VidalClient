using System.Xml.Serialization;
using JetBrains.Annotations;
using MedHubCompany.Extensions.Vidal.Models.Common;

namespace MedHubCompany.Extensions.Vidal.Models.Atom;

/// <summary>
/// Represents a Atom-structured result feed, as returned by the Vidal API.
/// </summary>
/// <typeparam name="TEntry">The type of the result.</typeparam>
[PublicAPI, Serializable]
[XmlRoot("feed", Namespace = AtomXmlNamespace, IsNullable = false)]
public class AtomFeed<TEntry> where TEntry : AtomFeedEntryBase
{
    /// <summary>
    /// The Atom XML namespace.
    /// </summary>
    public const string AtomXmlNamespace = "http://www.w3.org/2005/Atom";
    
    /// <summary>
    /// The API request summary (aka feed title).
    /// </summary>
    [XmlElement("title")]
    public string Title { get; set; } = "";

    /// <summary>
    /// The canonical API request link.
    /// </summary>
    [XmlElement("link")]
    public Link Link { get; set; }

    /// <summary>
    /// The API request identifier.
    /// </summary>
    /// <remarks>
    /// This usually returns the same as the canonical link.
    /// </remarks>
    /// <seealso cref="Link"/>
    [XmlElement("id")]
    public string Id { get; set; } = "";

    /// <summary>
    /// The last time the requested information was updated.
    /// </summary>
    [XmlElement("updated")]
    public DateTimeOffset Updated { get; set; }

    /// <summary>
    /// The results of the API request.
    /// </summary>
    [XmlElement("entry")]
    public TEntry[]? Entries { get; set; } = [];
    
    /// <summary>
    /// Implicitly converts an Atom feed to its results.
    /// </summary>
    /// <param name="feed">The Atom feed to convert.</param>
    /// <returns>The results of the Atom feed.</returns>
    [Pure]
    public static implicit operator TEntry[](AtomFeed<TEntry> feed) => feed.Entries ?? [];
}