// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.

using System.Xml.Serialization;
using MedHubCompany.Extensions.Vidal.Models.Common;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace MedHubCompany.Extensions.Vidal.Models;

/// <remarks/>
[XmlRoot("entry")]
public class SearchResult : VidalEntryBase
{
    /// <remarks/>
    [XmlElement("regulatoryGenericPrescription", Namespace = VidalXmlNamespace)]
    public bool RegulatoryGenericPrescription { get; set; }

    /// <remarks/>
    [XmlElement("indicator", Namespace = VidalXmlNamespace)]
    public Indicator[]? Indicator { get; set; }

    /// <remarks/>
    [XmlElement("itemType", Namespace = VidalXmlNamespace)]
    public NameValuePair<string>? ItemType { get; set; }
}

public sealed class FeedEntryAuthor
{
    [XmlElement("name")]
    public string Name { get; set; }
}

public sealed class Indicator
{
    /// <remarks/>
    [XmlAttribute]
    public byte VidalId { get; set; }

    /// <remarks/>
    [XmlText]
    public string Value { get; set; }
}