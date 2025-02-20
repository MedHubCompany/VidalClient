using System.Collections;
using System.Text;
using System.Text.Encodings.Web;
using System.Web;
using JetBrains.Annotations;
using Microsoft.Extensions.Primitives;

namespace MedHubCompany.Extensions.Vidal.Infrastructure.Http;

/// <summary>
/// Allows constructing a query string.
/// </summary>
/// <remarks>
/// Derived from <a href="https://github.com/dotnet/aspnetcore/blob/3f1acb59718cadf111a0a796681e3d3509bb3381/src/Http/Http.Extensions/src/QueryBuilder.cs">Microsoft.AspNetCore.Http.Extensions.QueryBuilder</a>.
/// </remarks>
public sealed class HttpQueryBuilder : IEnumerable<KeyValuePair<string, string>>
{
    private readonly IList<KeyValuePair<string, string>> _params;

    /// <summary>
    /// Initializes a new instance of <see cref="HttpQueryBuilder"/>.
    /// </summary>
    public HttpQueryBuilder()
    {
        _params = [];
    }

    /// <inheritdoc cref="HttpQueryBuilder()"/>
    /// <param name="parameters">The parameters to initialize the instance with.</param>
    public HttpQueryBuilder(params KeyValuePair<string, StringValues>[] parameters)
    {
        _params = [..parameters.SelectMany(kvp => kvp.Value, (kvp, v) => KeyValuePair.Create(kvp.Key, v ?? ""))];
    }

    /// <summary>
    /// Adds a query string token to the instance.
    /// </summary>
    /// <param name="key">The query key.</param>
    /// <param name="values">The query value, or sequence of multiple.</param>
    public void Add(string key, params string[] values)
    {
        foreach (string value in values)
        {
            _params.Add(new(key, value));
        }
    }

    /// <inheritdoc/>
    [MustUseReturnValue]
    public override string ToString()
    {
        StringBuilder builder = new();
        bool first = true;
        
        foreach (KeyValuePair<string, string> pair in _params)
        {
            builder.Append(first ? '?' : '&');
            first = false;
            builder.Append(UrlEncoder.Default.Encode(pair.Key));
            builder.Append('=');
            builder.Append(UrlEncoder.Default.Encode(pair.Value));
        }

        return builder.ToString();
    }

    /// <inheritdoc/>
    [MustUseReturnValue, MustDisposeResource]
    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        return _params.GetEnumerator();
    }

    [MustUseReturnValue, MustDisposeResource]
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _params.GetEnumerator();
    }
    
    /// <summary>
    /// Parses a query string into a HttpQueryBuilder object.
    /// </summary>
    /// <param name="query">The query string to parse.</param>
    /// <returns>The parsed HttpQueryBuilder object.</returns>
    [MustUseReturnValue]
    public static HttpQueryBuilder FromQuery(string query)
    {
        if (query is null or "" or "?" or "&")
        {
            return new();
        }

        if (query is not ['?' or '&', ..])
        {
            throw new FormatException("Query string must start with '?' or '&'.");
        }
        
        string[] pairs = query[1..].Split('&');
        KeyValuePair<string, StringValues>[] parameters = new KeyValuePair<string, StringValues>[pairs.Length];
        
        for (int i = 0; i < pairs.Length; i++)
        {
            string[] pair = pairs[i].Split('=', 2);
            parameters[i] = new(pair[0], pair.Length > 1 ? HttpUtility.UrlDecode(pair[1]) : "");
        }
        
        return new(parameters);
    }
}