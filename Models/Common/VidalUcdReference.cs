using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

#pragma warning disable CS8618, CS1591
public struct VidalUcdReference
{
    [XmlAttribute(AttributeName="code13")] 
    public double Code13 { get; set; } 

    [XmlAttribute(AttributeName="code7")] 
    public int Code7 { get; set; } 

    [XmlAttribute(AttributeName="id")] 
    public int Id { get; set; } 

    [XmlAttribute(AttributeName="vidalId")] 
    public int VidalId { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}