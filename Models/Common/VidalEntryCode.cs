using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

#pragma warning disable CS8618, CS1591
public struct VidalEntryCode
{
    public const string Cip13CodeType = "CIP13";
    public const string Cip7CodeType = "CIP7";
    
    [XmlAttribute(AttributeName="codeTypeDefaultCode")] 
    public bool CodeTypeDefaultCode { get; set; } 

    [XmlAttribute(AttributeName="globalDefaultCode")] 
    public bool GlobalDefaultCode { get; set; } 

    [XmlAttribute(AttributeName="type")] 
    public string Type { get; set; } 

    [XmlAttribute(AttributeName="typeId")] 
    public int TypeId { get; set; } 

    [XmlText] 
    public long Text { get; set; } 
}