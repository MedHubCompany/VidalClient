using System.Xml.Serialization;
using MedHubCompany.Extensions.Vidal.Models.Common;

namespace MedHubCompany.Extensions.Vidal.Models;

/// <summary>
/// Represents a Galenic form within the Vidal API.
/// </summary>
public sealed class VidalGalenicForm : VidalEntryBase
{
    /// <summary>
    /// The full localised name of the Galenic form.
    /// </summary>
    [XmlElement("name", Namespace = VidalXmlNamespace)]
    public string FullName { get; set; } = "";
    
    /// <summary>
    /// The short localised name of the Galenic form.
    /// </summary>
    [XmlElement("shortName", Namespace = VidalXmlNamespace)]
    public string ShortName { get; set; } = "";
    
    /// <summary>
    /// The classification of the Galenic form.
    /// </summary>
    [XmlElement("class", Namespace = VidalXmlNamespace)]
    public string Class { get; set; } = "";
}