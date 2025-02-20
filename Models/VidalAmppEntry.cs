using System.Xml.Serialization;
using MedHubCompany.Extensions.Vidal.Models.Common;

namespace MedHubCompany.Extensions.Vidal.Models;

#pragma warning disable CS8618, CS1591

[XmlRoot(ElementName="entry")]
public sealed class VidalAmppEntry : VidalEntryBase
{
	[XmlElement(ElementName="name", Namespace = VidalXmlNamespace)] 
	public string Name { get; set; } 

	[XmlElement(ElementName="itemType", Namespace = VidalXmlNamespace)] 
	public NameValuePair<string> ItemType { get; set; } 

	[XmlElement(ElementName="productId", Namespace = VidalXmlNamespace)] 
	public int ProductId { get; set; } 

	[XmlElement(ElementName="marketStatus", Namespace = VidalXmlNamespace)] 
	public NameValuePair<string> MarketStatus { get; set; } 

	[XmlElement(ElementName="exceptional", Namespace = VidalXmlNamespace)] 
	public bool Exceptional { get; set; } 

	[XmlElement(ElementName="horsGHS", Namespace = VidalXmlNamespace)] 
	public bool HorsGhs { get; set; } 

	[XmlElement(ElementName="otc", Namespace = VidalXmlNamespace)] 
	public bool Otc { get; set; } 

	[XmlElement(ElementName="isCeps", Namespace = VidalXmlNamespace)] 
	public bool IsCeps { get; set; } 

	[XmlElement(ElementName="composition", Namespace = VidalXmlNamespace)] 
	public VidalComposition[] Compositions { get; set; } 

	[XmlElement(ElementName="galenicForm", Namespace = VidalXmlNamespace)] 
	public VidalReference GalenicForm { get; set; } 

	[XmlElement(ElementName="unit", Namespace = VidalXmlNamespace)] 
	public VidalUnit[] Units { get; set; } 

	[XmlElement(ElementName="rate", Namespace = VidalXmlNamespace)] 
	public VidalRate? Rate { get; set; } 

	[XmlElement(ElementName="vmp", Namespace = VidalXmlNamespace)] 
	public VidalReference Vmp { get; set; } 

	[XmlElement(ElementName="vtm", Namespace = VidalXmlNamespace)] 
	public VidalReference Vtm { get; set; } 

	[XmlElement(ElementName="indicator", Namespace = VidalXmlNamespace)] 
	public VidalReference[] Indicators { get; set; } 

	[XmlElement(ElementName="code", Namespace = VidalXmlNamespace)] 
	public VidalEntryCode[]? Codes { get; set; }

	[XmlElement(ElementName="route", Namespace = VidalXmlNamespace)] 
	public VidalReference Route { get; set; } 

	[XmlElement(ElementName="company", Namespace = VidalXmlNamespace)] 
	public VidalReference Company { get; set; } 

	[XmlElement(ElementName="productRange", Namespace = VidalXmlNamespace)] 
	public VidalReference ProductRange { get; set; } 

	[XmlElement(ElementName="atc", Namespace = VidalXmlNamespace)] 
	public VidalNamedReference Atc { get; set; } 

	[XmlElement(ElementName="indication", Namespace = VidalXmlNamespace)] 
	public VidalNamedReference Indication { get; set; } 

	[XmlElement(ElementName="product", Namespace = VidalXmlNamespace)] 
	public VidalReference? Product { get; set; } 

	[XmlElement(ElementName="container", Namespace = VidalXmlNamespace)] 
	public VidalContainer Container { get; set; } 

	[XmlElement(ElementName="ucdv", Namespace = VidalXmlNamespace)] 
	public VidalReference Ucdv { get; set; } 

	[XmlElement(ElementName="shortLabel", Namespace = VidalXmlNamespace)] 
	public string ShortLabel { get; set; } 

	[XmlElement(ElementName="ucd", Namespace = VidalXmlNamespace)] 
	public VidalUcdReference Ucd { get; set; } 

	[XmlElement(ElementName="pharmacistPrice", Namespace = VidalXmlNamespace)] 
	public float PharmacistPrice { get; set; } 

	[XmlElement(ElementName="manufacturerPrice", Namespace = VidalXmlNamespace)] 
	public float ManufacturerPrice { get; set; } 

	[XmlElement(ElementName="pricePerDose", Namespace = VidalXmlNamespace)] 
	public float PricePerDose { get; set; } 

	[XmlElement(ElementName="ucdPrice", Namespace = VidalXmlNamespace)] 
	public float UcdPrice { get; set; } 

	[XmlElement(ElementName="vidalClassification", Namespace = VidalXmlNamespace)] 
	public VidalNamedReference VidalClassification { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

public sealed class VidalContainer
{
	[XmlElement(ElementName="uri")] 
	public string Uri { get; set; } 

	[XmlElement(ElementName="id")] 
	public int Id { get; set; } 

	[XmlElement(ElementName="name")] 
	public string Name { get; set; } 

	[XmlElement(ElementName="containerQuantity")] 
	public int ContainerQuantity { get; set; } 

	[XmlElement(ElementName="containerUnit")] 
	public VidalReference ContainerUnit { get; set; }

	[XmlElement(ElementName="item")] 
	public ContainerItem Item { get; set; }

	public sealed class ContainerItem
	{
		[XmlElement(ElementName="uri")] 
		public string Uri { get; set; } 

		[XmlElement(ElementName="id")] 
		public int Id { get; set; } 

		[XmlElement(ElementName="name")] 
		public string Name { get; set; } 

		[XmlElement(ElementName="contentUnit")] 
		public VidalReference ContentUnit { get; set; } 

		[XmlElement(ElementName="contentQuantity")] 
		public double ContentQuantity { get; set; } 
	}
}