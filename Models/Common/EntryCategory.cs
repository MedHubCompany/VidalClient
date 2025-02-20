using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

/// <summary>
/// Specifies the type of entry, or its category.
/// </summary>
public struct EntryCategory
{
    /// <summary>
    /// The category name.
    /// </summary>
    [XmlAttribute(AttributeName="term")]
    public string Term { get; set; }
}