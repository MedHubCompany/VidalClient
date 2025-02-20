using System.ComponentModel;
using System.Xml.Serialization;
using MedHubCompany.Extensions.Vidal.Models.Common;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace MedHubCompany.Extensions.Vidal.Models;

/// <summary>
/// Represents a product on the Vidal API.
/// </summary>
/// <remarks>
/// Identifiable as this type using the <c>vidal:categories="PRODUCT"</c> XML attribute.
/// <br />
/// Canonically available via the following API reference :
/// <c>http://api.vidal.fr/rest/api/product/{id}</c>
/// </remarks>
[XmlRoot("entry")]
public class VidalProduct : VidalEntryBase
{
    [XmlElement("name", Namespace = VidalXmlNamespace)]
    public string Name { get; set; }

    [XmlElement("horsGHS", Namespace = VidalXmlNamespace)]
    public bool HorsGhs { get; set; }

    [XmlElement("midwife", Namespace = VidalXmlNamespace)]
    public bool Midwife { get; set; }

    [XmlElement("drugInSport", Namespace = VidalXmlNamespace)]
    public bool DrugInSport { get; set; }

    [XmlElement("retrocession", Namespace = VidalXmlNamespace)]
    public bool Retrocession { get; set; }

    [XmlElement("itemType", Namespace = VidalXmlNamespace)]
    public string ItemType { get; set; }

    [XmlElement("marketStatus", Namespace = VidalXmlNamespace)]
    public NameValuePair<string> MarketStatus { get; set; }

    [XmlElement("exceptional", Namespace = VidalXmlNamespace)]
    public bool Exceptional { get; set; }

    [XmlElement("hasPublishedDoc", Namespace = VidalXmlNamespace)]
    public bool HasPublishedDoc { get; set; }

    [XmlElement("withoutPrescription", Namespace = VidalXmlNamespace)]
    public bool WithoutPrescription { get; set; }

    [XmlElement("ammType", Namespace = VidalXmlNamespace)]
    public VidalNamedReference AmmType { get; set; }

    [XmlElement("dispensationPlace", Namespace = VidalXmlNamespace)]
    public NameValuePair<string> DispensationPlace { get; set; }

    [XmlElement("beCareful", Namespace = VidalXmlNamespace)]
    public bool BeCareful { get; set; }

    [XmlElement("vigilance", Namespace = VidalXmlNamespace)]
    public NameValuePair<string>? Vigilance { get; set; }
    
    [XmlElement("list", Namespace = VidalXmlNamespace)]
    public NameValuePair<string>? List { get; set; }
    
    [XmlElement("refundRate", Namespace = VidalXmlNamespace)]
    public RefundRate RefundRate { get; set; }

    [XmlElement("bestDocType", Namespace = VidalXmlNamespace)]
    public string BestDocType { get; set; }

    [XmlElement("perVolume", Namespace = VidalXmlNamespace)]
    public string PerVolume { get; set; }

    [XmlElement("safetyAlert", Namespace = VidalXmlNamespace)]
    public bool SafetyAlert { get; set; }

    [XmlElement("activePrinciples", Namespace = VidalXmlNamespace), EditorBrowsable(EditorBrowsableState.Advanced)]
    public string ActivePrinciplesRaw { get; set; } = "";
    
    [XmlIgnore]
    public string[] ActivePrinciples => ActivePrinciplesRaw.Split("; ");

    [XmlElement("onMarketDate", Namespace = VidalXmlNamespace)]
    public string OnMarketDate { get; set; }
    
    [XmlElement("offMarketDate", Namespace = VidalXmlNamespace)]
    public string? OffMarketDate { get; set; }

    [XmlElement("cis", Namespace = VidalXmlNamespace, IsNullable = true)]
    public int? Cis { get; set; }

    [XmlElement("minUcdRangePrice", Namespace = VidalXmlNamespace)]
    public float MinUcdRangePrice { get; set; }

    [XmlElement("maxUcdRangePrice", Namespace = VidalXmlNamespace)]
    public float MaxUcdRangePrice { get; set; }

    [XmlElement("divisibility", Namespace = VidalXmlNamespace)]
    public int Divisibility { get; set; }

    [XmlElement("company", Namespace = VidalXmlNamespace)]
    public CompanyRef Company { get; set; }

    [XmlElement("vmp", Namespace = VidalXmlNamespace)]
    public VidalNamedReference Vmp { get; set; }

    [XmlElement("galenicForm", Namespace = VidalXmlNamespace)]
    public VidalNamedReference GalenicForm { get; set; }
}