using System.Text;

namespace JK.Common.Text;

/// <summary>
/// This class builds a delimited string.
/// </summary>
public sealed class StringDelimiter
{
    private readonly StringBuilder _builder = new();
    private readonly string _delimiter;

    /// <summary>
    /// Initializes a new instance of the StringDelimiter class.
    /// </summary>
    /// <param name="delimiter">The string to use when delimiting sections.</param>
    public StringDelimiter(string delimiter)
    {
        _delimiter = delimiter;
    }

    /// <summary>
    /// Gets the delimited text string.
    /// </summary>
    public string DelimitedText => _builder.ToString();

    /// <summary>
    /// Adds a block of text to the current string and delimits if necessary.
    /// </summary>
    /// <param name="addition">The string to add to the current string.</param>
    public void AddText(in string addition)
    {
        if (_builder.Length > 0)
        {
            _builder.Append(_delimiter);
        }

        _builder.Append(addition);
    }
}
