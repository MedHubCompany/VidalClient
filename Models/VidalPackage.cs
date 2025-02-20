using System.Xml.Serialization;
using MedHubCompany.Extensions.Vidal.Models.Common;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace MedHubCompany.Extensions.Vidal.Models;

/// <summary>
/// Represents a package on the Vidal API.
/// </summary>
/// <remarks>
/// Identifiable as this type using the <c>vidal:categories="PACKAGE"</c> XML attribute.
/// <br />
/// Canonically available via the following API reference :
/// <c>http://api.vidal.fr/rest/api/package/{id}</c>
/// </remarks>
[XmlRoot("entry")]
public class VidalPackage : VidalEntryBase
{
    [XmlElement("name", Namespace = VidalXmlNamespace)]
    public string Name { get; set; }

    [XmlElement("itemType", Namespace = VidalXmlNamespace)]
    public string ItemType { get; set; }

    [XmlElement("productId", Namespace = VidalXmlNamespace)]
    public string ProductId { get; set; }

    [XmlElement("marketStatus", Namespace = VidalXmlNamespace)]
    public NameValuePair<string> MarketStatus { get; set; }

    [XmlElement("exceptional", Namespace = VidalXmlNamespace)]
    public bool Exceptional { get; set; }

    [XmlElement("horsGHS", Namespace = VidalXmlNamespace)]
    public bool HorsGhs { get; set; }

    [XmlElement("otc", Namespace = VidalXmlNamespace)]
    public bool Otc { get; set; }

    [XmlElement("isCeps", Namespace = VidalXmlNamespace)]
    public bool IsCeps { get; set; }

    [XmlElement("dispensationPlace", Namespace = VidalXmlNamespace)]
    public string DispensationPlace { get; set; }

    [XmlElement("refundingBase", Namespace = VidalXmlNamespace)]
    public float RefundingBase { get; set; }

    [XmlElement("publicPrice", Namespace = VidalXmlNamespace)]
    public float PublicPrice { get; set; }

    [XmlElement("vatRate", Namespace = VidalXmlNamespace)]
    public NameValuePair<float> VatRate { get; set; }

    [XmlElement("pharmacistPrice", Namespace = VidalXmlNamespace)]
    public float PharmacistPrice { get; set; }

    [XmlElement("drugId", Namespace = VidalXmlNamespace)]
    public string DrugId { get; set; }

    [XmlElement("onMarketDate", Namespace = VidalXmlNamespace)]
    public string OnMarketDate { get; set; }
    
    [XmlElement("offMarketDate", Namespace = VidalXmlNamespace)]
    public string? OffMarketDate { get; set; }

    [XmlElement("cis", Namespace = VidalXmlNamespace)]
    public int Cis { get; set; }

    [XmlElement("cip13", Namespace = VidalXmlNamespace)]
    public long Cip13 { get; set; }

    [XmlElement("shortLabel", Namespace = VidalXmlNamespace)]
    public string ShortLabel { get; set; }

    [XmlElement("manufacturerPrice", Namespace = VidalXmlNamespace)]
    public float ManufacturerPrice { get; set; }

    [XmlElement("tfr", Namespace = VidalXmlNamespace)]
    public bool Tfr { get; set; }

    [XmlElement("doseUnit", Namespace = VidalXmlNamespace)]
    public VidalNamedReference DoseUnit { get; set; }

    [XmlElement("dose", Namespace = VidalXmlNamespace)]
    public string Dose { get; set; }

    [XmlElement("company", Namespace = VidalXmlNamespace)]
    public CompanyRef Company { get; set; }
    
    [XmlElement("refundRate", Namespace = VidalXmlNamespace)]
    public RefundRate RefundRate { get; set; }

    [XmlElement("drugInSport", Namespace = VidalXmlNamespace)]
    public bool DrugInSport { get; set; }

    [XmlElement("narcoticPrescription", Namespace = VidalXmlNamespace)]
    public bool NarcoticPrescription { get; set; }

    [XmlElement("pricePerDose", Namespace = VidalXmlNamespace)]
    public float PricePerDose { get; set; }

    [XmlElement("safetyAlert", Namespace = VidalXmlNamespace)]
    public bool SafetyAlert { get; set; }

    [XmlElement("ucdPrice", Namespace = VidalXmlNamespace)]
    public float UcdPrice { get; set; }

    [XmlElement("perVolume", Namespace = VidalXmlNamespace)]
    public string PerVolume { get; set; }

    [XmlElement("withoutPrescription", Namespace = VidalXmlNamespace)]
    public bool WithoutPrescription { get; set; }

    [XmlElement("ucdQuantity", Namespace = VidalXmlNamespace)]
    public int UcdQuantity { get; set; }

    [XmlElement("product", Namespace = VidalXmlNamespace)]
    public ProductRef Product { get; set; }

    [XmlElement("actCode", Namespace = VidalXmlNamespace)]
    public NameValuePair<string> ActCode { get; set; }

    [XmlElement("actCodeFee", Namespace = VidalXmlNamespace)]
    public NameValuePair<string> ActCodeFee { get; set; }

    [XmlElement("galenicForm", Namespace = VidalXmlNamespace)]
    public VidalReference GalenicForm { get; set; }

    [XmlElement("atc", Namespace = VidalXmlNamespace)]
    public VidalNamedReference Atc { get; set; }

    [XmlElement("communityAgreement", Namespace = VidalXmlNamespace)]
    public bool CommunityAgreement { get; set; }

    [XmlElement("vmp", Namespace = VidalXmlNamespace)]
    public VidalNamedReference Vmp { get; set; }

    [XmlElement("ucd", Namespace = VidalXmlNamespace)]
    public UcdRef Ucd { get; set; }

    [XmlElement("divisibility", Namespace = VidalXmlNamespace)]
    public int Divisibility { get; set; }
    
    public struct ProductRef
    {
        [XmlAttribute("codeCis")]
        public int CodeCis { get; set; }

        [XmlAttribute("vidalId")]
        public int VidalId { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
    
    public struct UcdRef
    {
        [XmlAttribute(AttributeName="code13")] 
        public long Cip13 { get; set; } 

        [XmlAttribute(AttributeName="code7")] 
        public int Cip7 { get; set; } 

        [XmlAttribute(AttributeName="id")] 
        public int Id { get; set; } 

        [XmlAttribute(AttributeName="vidalId")] 
        public int VidalId { get; set; } 

        [XmlText] 
        public string Title { get; set; } 
    }
}