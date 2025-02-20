using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Common;

/// <summary>
/// Represents an XML name-value pair.
/// </summary>
/// <typeparam name="TValue">The type of the value.</typeparam>
public struct NameValuePair<TValue>
{
    /// <summary>
    /// The name.
    /// </summary>
    [XmlAttribute("name")]
    public string Name { get; set; }

    /// <summary>
    /// The value.
    /// </summary>
    [XmlText]
    public TValue Value { get; set; }
}