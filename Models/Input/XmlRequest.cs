using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MedHubCompany.Extensions.Vidal.Models.Input;

/// <summary>
/// Represents an XML request, as sent to the Vidal API.
/// </summary>
/// <typeparam name="TRequest">The type of the request object.</typeparam>
[Serializable, XmlRoot(ElementName="request")]
public sealed class XmlRequest<TRequest> : IXmlSerializable
{
    /// <summary>
    /// The request object.
    /// </summary>
    [XmlElement(ElementName="request")]
    public TRequest Request { get; set; } = default!;

    /// <inheritdoc />
    public XmlSchema? GetSchema() => null;

    /// <inheritdoc />
    public void ReadXml(XmlReader reader)
    {
        throw new NotImplementedException();
    }

    public void WriteXml(XmlWriter writer) => new XmlSerializer(typeof(TRequest)).Serialize(writer, Request);
}