using System.Text;

namespace DL.Common.Text
{
    /// <summary>
    /// This class builds a delimited string.
    /// </summary>
    public class StringDelimiter
    {
        private readonly StringBuilder builder;

        private readonly string delimiter;

        /// <summary>
        /// Initializes a new instance of the StringDelimiter class.
        /// </summary>
        /// <param name="delimiter">The string to use when delimiting sections.</param>
        public StringDelimiter(string delimiter)
        {
            this.builder = new StringBuilder();
            this.delimiter = delimiter;
        }

        /// <summary>
        /// Gets the delimited text string.
        /// </summary>
        public string DelimitedText => this.builder.ToString();

        /// <summary>
        /// Adds a block of text to the current string and delimits if necessary.
        /// </summary>
        /// <param name="addition">The string to add to the current string.</param>
        public void AddText(string addition)
        {
            if (this.builder.Length > 0)
            {
                this.builder.Append(this.delimiter);
            }

            this.builder.Append(addition);
        }
    }
}
