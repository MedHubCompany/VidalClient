using System.ComponentModel;
using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Input;

/// <summary>
/// Defines a list of XML IDs, for use in XML serialization.
/// </summary>
/// <param name="Ids">The list of XML IDs.</param>
[Serializable, XmlRoot(ElementName="ids")]
public sealed record XmlIdList
{
    /// <summary>
    /// The list of XML IDs.
    /// </summary>
    [XmlElement(ElementName = "id")]
    public string[] Ids { get; init; } = [];
}