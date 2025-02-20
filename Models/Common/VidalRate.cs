using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

#pragma warning disable CS8618, CS1591
public sealed class VidalRate
{
    [XmlAttribute(AttributeName="denominator")] 
    public float Denominator { get; set; } 

    [XmlAttribute(AttributeName="numerator")] 
    public int Numerator { get; set; } 

    [XmlAttribute(AttributeName="ref_unit")] 
    public int RefUnit { get; set; } 

    [XmlAttribute(AttributeName="unit")] 
    public int Unit { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}