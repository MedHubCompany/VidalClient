using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

#pragma warning disable CS8618, CS1591
public sealed class VidalComposition
{
    [XmlAttribute(AttributeName="itemType")] 
    public string ItemType { get; set; } 

    [XmlAttribute(AttributeName="moleculeId")] 
    public int MoleculeId { get; set; } 

    [XmlAttribute(AttributeName="moleculeName")] 
    public string MoleculeName { get; set; } 

    [XmlAttribute(AttributeName="perVolumeUnit")] 
    public string PerVolumeUnit { get; set; } 

    [XmlAttribute(AttributeName="perVolumeUnitId")] 
    public int PerVolumeUnitId { get; set; } 

    [XmlAttribute(AttributeName="perVolumeValue")] 
    public float PerVolumeValue { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}