using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

#pragma warning disable CS8618, CS1591
public sealed class VidalUnit
{
    [XmlAttribute(AttributeName="name")] 
    public string Name { get; set; } 

    [XmlAttribute(AttributeName="pluralname")] 
    public string Pluralname { get; set; } 

    [XmlAttribute(AttributeName="rank")] 
    public int Rank { get; set; } 

    [XmlAttribute(AttributeName="shortname")] 
    public string Shortname { get; set; } 

    [XmlAttribute(AttributeName="singularname")] 
    public string Singularname { get; set; } 

    [XmlAttribute(AttributeName="type")] 
    public string Type { get; set; } 

    [XmlAttribute(AttributeName="vidalId")] 
    public int VidalId { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}