using System;
using System.Collections.Generic;

namespace JK.Common.Text;

/// <summary>
/// Class which places values from objects into a given template.
/// </summary>
public sealed class TemplateProcessor
{
    private readonly string template;

    private readonly List<string> tokens;

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
        this.Objects = new List<object>();
        this.TokenStart = tokenStart;
        this.TokenEnd = tokenEnd;
        this.template = template;
        this.tokens = this.GetTokenKeyList();
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
        var pairs = this.GetKeyValuePairs();
        var returnValue = this.template;

        foreach (var key in pairs.Keys)
        {
            var token = this.GetTokenFromTokenKey(key);
            returnValue = returnValue.Replace(token, pairs[key]);
        }

        return returnValue;
    }

    #region Private Methods - Get Token Key List and Helpers

    private List<string> GetTokenKeyList()
    {
        var tokenKeys = new List<string>();

        var position = 0;
        while (this.ContainsToken(position))
        {
            var tokenStartIndex = this.GetTokenStartIndex(position);
            var tokenEndIndex = this.GetTokenEndIndex(position);
            var tokenKey = this.GetTokenKeyFromTemplate(tokenStartIndex, tokenEndIndex);

            if (!tokenKeys.Contains(tokenKey))
            {
                tokenKeys.Add(tokenKey);
            }

            position = tokenEndIndex + this.TokenEnd.Length;
        }

        return tokenKeys;
    }

    private int GetTokenStartIndex(in int startIndex)
        => this.template.IndexOf(this.TokenStart, startIndex, StringComparison.OrdinalIgnoreCase);

    private int GetTokenEndIndex(in int startIndex)
        => this.template.IndexOf(this.TokenEnd, startIndex, StringComparison.OrdinalIgnoreCase);

    private string GetTokenKeyFromTemplate(in int tokenStartIndex, in int tokenEndIndex)
    {
        var startPosition = tokenStartIndex + this.TokenStart.Length;
        var length = tokenEndIndex - tokenStartIndex - this.TokenEnd.Length;
        return this.template.Substring(startPosition, length);
    }

    private bool ContainsToken(in int startIndex)
        => this.template.Substring(startIndex).Contains(this.TokenStart)
           && this.template.Substring(startIndex).Contains(this.TokenEnd);

    #endregion

    #region Private Methods - ProcessTemplate Helpers

    private Dictionary<string, string> GetKeyValuePairs()
    {
        var pairs = new Dictionary<string, string>();

        foreach (var item in this.Objects)
        {
            var t = item.GetType();
            foreach (var property in t.GetProperties())
            {
                var propertyFullName = string.Concat(t.Name, ".", property.Name);
                foreach (var key in this.tokens)
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
        => string.Concat(this.TokenStart, tokenKey, this.TokenEnd);

    #endregion
}
