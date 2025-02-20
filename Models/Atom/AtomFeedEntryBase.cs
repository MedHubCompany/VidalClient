using System.Xml;
using System.Xml.Serialization;
using MedHubCompany.Extensions.Vidal.Models.Common;

namespace MedHubCompany.Extensions.Vidal.Models.Atom;

/// <summary>
/// Represents the base class for an Atom feed entry.
/// </summary>
/// <seealso cref="AtomFeed{TEntry}"/>
public abstract class AtomFeedEntryBase
{
    /// <summary>
    /// The entry title.
    /// </summary>
    [XmlElement("title")]
    public string Title { get; set; } = "";

    /// <summary>
    /// The entry related links.
    /// </summary>
    [XmlElement("link")]
    public Link[]? Links { get; set; }

    /// <summary>
    /// The entry category.
    /// </summary>
    [XmlElement("category")]
    public FeedCategory AtomCategory { get; set; } 

    /// <summary>
    /// The entry author.
    /// </summary>
    [XmlElement("author")]
    public FeedAuthor Author { get; set; }

    /// <summary>
    /// The entry identifier.
    /// </summary>
    [XmlElement("id")]
    public string Id { get; set; } = "";

    /// <summary>
    /// The entry last update time.
    /// </summary>
    [XmlElement("updated")]
    public DateTimeOffset Updated { get; set; } 

    /// <summary>
    /// A summary of the entry.
    /// </summary>
    [XmlElement("summary")]
    public FeedSummary? Summary { get; set; }

    /// <summary>
    /// The entry content.
    /// </summary>
    [XmlElement("content")]
    public object? Content { get; set; }

    /// <summary>
    /// Any additional entry properties that aren't covered by the base class or derivatives.
    /// </summary>
    [XmlAnyElement]
    public XmlElement[]? AdditionalProperties { get; set; } = [];
    
    /// <summary>
    /// Represents the Category of an Atom feed entry.
    /// </summary>
    public struct FeedCategory
    {
        /// <summary>
        /// The category term.
        /// </summary>
        [XmlAttribute("term")]
        public string Term { get; set; }
    }
    
    /// <summary>
    /// Represents the author of an Atom feed entry.
    /// </summary>
    public struct FeedAuthor
    {
        /// <summary>
        /// The author name.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Represents the summary of an Atom feed entry.
    /// </summary>
    public struct FeedSummary
    {
        /// <summary>
        /// The summary type.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// The summary.
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}