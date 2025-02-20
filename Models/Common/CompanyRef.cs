using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

/// <summary>
/// Represents a reference to a company.
/// </summary>
public struct CompanyRef
{
    /// <summary>
    /// The relationship of the company, compared to its parent.
    /// </summary>
    [XmlAttribute("type")]
    public string Type { get; set; }

    /// <summary>
    /// The Vidal ID of the company.
    /// </summary>
    [XmlAttribute("vidalId")]
    public int VidalId { get; set; }

    /// <summary>
    /// The name of the company.
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}