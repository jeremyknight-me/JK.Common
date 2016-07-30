using System;

namespace DL.Core
{
    /// <summary>
    /// Class which truncates strings.
    /// </summary>
    public class StringTruncater
    {
        private readonly string originalText;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringTruncater"/> class. 
        /// </summary>
        /// <param name="originalText">
        /// Text to be truncated.
        /// </param>
        public StringTruncater(string originalText)
        {
            this.originalText = originalText;
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
            this.Indicator = indicator;
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
        public string TruncateToLength(int length)
        {
            return this.NeedsTruncation(length)
                ? this.TruncateWithIndicator(length) 
                : this.originalText;
        }

        private bool NeedsTruncation(int length)
        {
            return this.originalText.Length > length;
        }

        private string TruncateWithIndicator(int length)
        {
            int totalLength = this.HasIndicator() ? this.GetTotalLength(length) : length;
            string text = this.originalText.Substring(0, totalLength).Trim();
            int lastSpaceIndex = text.LastIndexOf(" ", StringComparison.OrdinalIgnoreCase);

            if (this.IsTruncatedInMiddleOfWord(totalLength, lastSpaceIndex))
            {
                text = text.Remove(lastSpaceIndex);
            }

            return this.AddIndicator(text);
        }

        private int GetTotalLength(int length)
        {
            return this.HasIndicator() ? (length - this.Indicator.Length) : length;
        }

        private bool HasIndicator()
        {
            return !string.IsNullOrEmpty(this.Indicator);
        }

        private bool IsTruncatedInMiddleOfWord(int length, int lastSpaceIndex)
        {
            return this.originalText[length] != ' '
                && lastSpaceIndex >= 0;
        }

        private string AddIndicator(string text)
        {
            return string.Concat(text, this.Indicator);
        }
    }
}
