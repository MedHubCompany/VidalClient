using System.Net.Http.Headers;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using JetBrains.Annotations;
using MedHubCompany.Extensions.Vidal.Models.Atom;

namespace MedHubCompany.Extensions.Vidal.Clients;

/* ***
 * VidalClientBase.cs
 * (C) 2024 MedHubCompany
 *
 * Contains the base class for the Vidal API client.
 */

/// <summary>
/// Represents an HTTP client that communicates with the Vidal API.
/// </summary>
public sealed partial class VidalClient : IVidalClient, IDisposable
{
    internal readonly HttpClient Client;

    /// <summary>
    /// Initializes a new instance of the <see cref="VidalClient"/> class.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    public VidalClient(HttpClient client)
    {
        Client = client;
    }

    /// <summary>
    /// Disposes the HTTP client.
    /// </summary>
    public void Dispose()
    {
        Client.Dispose();
        
        // ReSharper disable once GCSuppressFinalizeForTypeWithoutDestructor
        GC.SuppressFinalize(this);
    }

    [GeneratedRegex(@"<[^>]+/>", RegexOptions.Compiled | RegexOptions.NonBacktracking, 100)]
    private static partial Regex XmlEmptyTagRegex();
    
    /// <summary>
    /// Deserializes the Atom XML response as a <see cref="AtomFeed{TEntry}"/> object.
    /// </summary>
    /// <typeparam name="TEntry">The type of the entry.</typeparam>
    /// <param name="response">The HTTP response message.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The Atom feed.</returns>
    [MustUseReturnValue]
    private static async Task<AtomFeed<TEntry>> DeserializeAtomFeedAsync<TEntry>(HttpResponseMessage response, CancellationToken ct) where TEntry : AtomFeedEntryBase
    {
        // Read response as Atom XML
        await using Stream stream = await response.Content.ReadAsStreamAsync(ct);
        using StreamReader smr = new(stream);
        
        // Clean empty XML tags first
        string cleaned = XmlEmptyTagRegex().Replace(await smr.ReadToEndAsync(ct), "");
        
        XmlSerializer serializer = new(typeof(AtomFeed<TEntry>));
        using StringReader sgr = new(cleaned);
        
        return (AtomFeed<TEntry>)serializer.Deserialize(sgr)!;
    }
    
    /// <summary>
    /// Deserializes the Atom XML response as a <see cref="AtomOpenSearchFeed{TEntry}"/> object.
    /// </summary>
    /// <inheritdoc cref="DeserializeAtomFeedAsync{TEntry}" />
    [MustUseReturnValue]
    private static async Task<AtomOpenSearchFeed<TEntry>> DeserializeAtomOpenSearchFeedAsync<TEntry>(HttpResponseMessage response, CancellationToken ct) where TEntry : AtomFeedEntryBase
    {
        // Read response as Atom XML
        await using Stream stream = await response.Content.ReadAsStreamAsync(ct);
        XmlSerializer serializer = new(typeof(AtomOpenSearchFeed<TEntry>));
        return (AtomOpenSearchFeed<TEntry>)serializer.Deserialize(stream)!;
    }
    
    /// <summary>
    /// Serializes a given object in XML to a HttpRequestMessage.
    /// </summary>
    /// <typeparam name="TObject">The type of the object to serialize.</typeparam>
    /// <param name="request">The initial HTTP request message.</param>
    /// <param name="obj">The object to serialize.</param>
    /// <returns>The HTTP request message with the <paramref name="obj"/> serialized as XML.</returns>
    private static void SerializeRequestObject<TObject>(in HttpRequestMessage request, TObject obj)
    {
        // Serialize object as XML
        MemoryStream stream = new();
        XmlSerializer serializer = new(typeof(TObject));
        serializer.Serialize(stream, obj, namespaces: null);
        stream.Seek(0, SeekOrigin.Begin);
        
        // Attach XML to request
        request.Content = new StreamContent(stream);
        
        // Set content type to text/xml. Turns out the Vidal API doesn't like application/xml, and throws a 415.
        request.Content.Headers.ContentType = new(MediaTypeNames.Text.Xml);
    }
}