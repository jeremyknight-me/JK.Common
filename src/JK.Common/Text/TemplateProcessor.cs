using System;
using System.Collections.Generic;

namespace JK.Common.Text;

/// <summary>
/// Class which places values from objects into a given template.
/// </summary>
public sealed class TemplateProcessor
{
    private readonly string _template;
    private readonly HashSet<string> _tokens = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="TemplateProcessor"/> class.
    /// </summary>
    /// <param name="template">Template place data values into.</param>
    public TemplateProcessor(string template)
        : this(template, "{{", "}}")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TemplateProcessor"/> class.
    /// </summary>
    /// <param name="template">Template place data values into.</param>
    /// <param name="tokenStart">Starting value of the tokens used in the template.</param>
    /// <param name="tokenEnd">Ending value of the tokens used in the template.</param>
    public TemplateProcessor(string template, string tokenStart, string tokenEnd)
    {
        Objects = [];
        TokenStart = tokenStart;
        TokenEnd = tokenEnd;
        _template = template;
        LoadTokenKeys();
    }

    /// <summary>
    /// Gets or sets the list of objects containing the data to be used in the template.
    /// </summary>
    public List<object> Objects { get; set; }

    /// <summary>
    /// Gets or sets the starting value of the tokens used in the template.
    /// </summary>
    public string TokenStart { get; set; }

    /// <summary>
    /// Gets or sets the ending value of the tokens used in the template.
    /// </summary>
    public string TokenEnd { get; set; }

    /// <summary>
    /// Processes the template using the given objects.
    /// </summary>
    /// <returns>Template format with data inserted where tokens existed.</returns>
    public string ProcessTemplate()
    {
        Dictionary<string, string> pairs = GetKeyValuePairs();
        var returnValue = _template;

        foreach (var key in pairs.Keys)
        {
            var token = GetTokenFromTokenKey(key);
            returnValue = returnValue.Replace(token, pairs[key]);
        }

        return returnValue;
    }

    private void LoadTokenKeys()
    {
        _tokens.Clear();
        var position = 0;
        while (ContainsToken(position))
        {
            var tokenStartIndex = GetTokenStartIndex(position);
            var tokenEndIndex = GetTokenEndIndex(position);
            var tokenKey = GetTokenKeyFromTemplate(tokenStartIndex, tokenEndIndex);

            _tokens.Add(tokenKey);
            position = tokenEndIndex + TokenEnd.Length;
        }
    }

    private int GetTokenStartIndex(in int startIndex)
        => _template.IndexOf(TokenStart, startIndex, StringComparison.OrdinalIgnoreCase);

    private int GetTokenEndIndex(in int startIndex)
        => _template.IndexOf(TokenEnd, startIndex, StringComparison.OrdinalIgnoreCase);

    private string GetTokenKeyFromTemplate(in int tokenStartIndex, in int tokenEndIndex)
    {
        var startPosition = tokenStartIndex + TokenStart.Length;
        var length = tokenEndIndex - tokenStartIndex - TokenEnd.Length;
        return _template.Substring(startPosition, length);
    }

    private bool ContainsToken(in int startIndex)
        => _template.Substring(startIndex).Contains(TokenStart)
           && _template.Substring(startIndex).Contains(TokenEnd);

    private Dictionary<string, string> GetKeyValuePairs()
    {
        var pairs = new Dictionary<string, string>();
        foreach (var item in Objects)
        {
            Type t = item.GetType();
            foreach (System.Reflection.PropertyInfo property in t.GetProperties())
            {
                var propertyFullName = string.Concat(t.Name, ".", property.Name);
                foreach (var key in _tokens)
                {
                    if (key != propertyFullName)
                    {
                        continue;
                    }

                    var propertyValue = property.GetValue(item, null);
                    pairs.Add(key, propertyValue?.ToString() ?? string.Empty);
                }
            }
        }

        return pairs;
    }

    private string GetTokenFromTokenKey(in string tokenKey)
        => string.Concat(TokenStart, tokenKey, TokenEnd);
}
