using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

#pragma warning disable CS8618, CS1591
public struct RefundRate
{
    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("rate")]
    public int Rate { get; set; }

    [XmlText]
    public string Value { get; set; }
}