namespace JK.Common.Text;

/// <summary>
/// Class which truncates strings.
/// </summary>
public sealed class StringTruncater
{
    private readonly string _originalText;

    /// <summary>
    /// Initializes a new instance of the <see cref="StringTruncater"/> class. 
    /// </summary>
    /// <param name="originalText">
    /// Text to be truncated.
    /// </param>
    public StringTruncater(string originalText)
    {
        _originalText = originalText;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringTruncater"/> class.
    /// </summary>
    /// <param name="originalText">Text to be truncated.</param>
    /// <param name="indicator">
    /// Indicator to be placed within the truncated text to indicate that 
    /// a truncation has taken place.
    /// </param>
    public StringTruncater(string originalText, string indicator)
        : this(originalText)
    {
        Indicator = indicator;
    }

    /// <summary>
    /// Gets or sets the indicator to concatenate to the end of truncated text.
    /// Ex: '...'
    /// </summary>
    public string Indicator { get; set; }

    /// <summary>
    /// Truncates the original text to a given length.
    /// </summary>
    /// <param name="length">Length of string to output.</param>
    /// <returns>Original text truncated to given length.</returns>
    public string TruncateToLength(in int length)
        => NeedsTruncation(length)
            ? TruncateWithIndicator(length)
            : _originalText;

    private bool NeedsTruncation(in int length) => _originalText.Length > length;

    private string TruncateWithIndicator(in int length)
    {
        var totalLength = HasIndicator() ? GetTotalLength(length) : length;
        var text = _originalText.Substring(0, totalLength).Trim();
        var lastSpaceIndex = text.LastIndexOf(' ');
        if (IsTruncatedInMiddleOfWord(totalLength, lastSpaceIndex))
        {
            text = text.Remove(lastSpaceIndex);
        }

        return AddIndicator(text);
    }

    private int GetTotalLength(in int length) => HasIndicator() ? length - Indicator.Length : length;

    private bool HasIndicator() => !string.IsNullOrEmpty(Indicator);

    private bool IsTruncatedInMiddleOfWord(in int length, in int lastSpaceIndex)
        => _originalText[length] != ' ' && lastSpaceIndex >= 0;

    private string AddIndicator(in string text) => string.Concat(text, Indicator);
}
