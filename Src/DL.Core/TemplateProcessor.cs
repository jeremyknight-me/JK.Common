using System;
using System.Collections.Generic;
using System.Reflection;

namespace DL.Core
{
    /// <summary>
    /// Class which places values from objects into a given template.
    /// </summary>
    public class TemplateProcessor
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
            Dictionary<string, string> pairs = this.GetKeyValuePairs();
            string returnValue = this.template;

            foreach (string key in pairs.Keys)
            {
                string token = this.GetTokenFromTokenKey(key);
                returnValue = returnValue.Replace(token, pairs[key]);
            }

            return returnValue;
        }

        #region Private Methods - Get Token Key List and Helpers

        private List<string> GetTokenKeyList()
        {
            var tokenKeys = new List<string>();

            int position = 0;
            while (this.ContainsToken(position))
            {
                int tokenStartIndex = this.GetTokenStartIndex(position);
                int tokenEndIndex = this.GetTokenEndIndex(position);
                string tokenKey = this.GetTokenKeyFromTemplate(tokenStartIndex, tokenEndIndex);

                if (!tokenKeys.Contains(tokenKey))
                {
                    tokenKeys.Add(tokenKey);    
                }
                
                position = tokenEndIndex + this.TokenEnd.Length;
            }

            return tokenKeys;
        }

        private int GetTokenStartIndex(int startIndex)
        {
            return this.template.IndexOf(this.TokenStart, startIndex, StringComparison.OrdinalIgnoreCase);
        }

        private int GetTokenEndIndex(int startIndex)
        {
            return this.template.IndexOf(this.TokenEnd, startIndex, StringComparison.OrdinalIgnoreCase);
        }

        private string GetTokenKeyFromTemplate(int tokenStartIndex, int tokenEndIndex)
        {
            int startPosition = tokenStartIndex + this.TokenStart.Length;
            int length = tokenEndIndex - tokenStartIndex - this.TokenEnd.Length;
            return this.template.Substring(startPosition, length);
        }

        private bool ContainsToken(int startIndex)
        {
            return this.template.Substring(startIndex).Contains(this.TokenStart)
                   && this.template.Substring(startIndex).Contains(this.TokenEnd);
        }

        #endregion

        #region Private Methods - ProcessTemplate Helpers

        private Dictionary<string, string> GetKeyValuePairs()
        {
            var pairs = new Dictionary<string, string>();

            foreach (object item in this.Objects)
            {
                Type t = item.GetType();
                foreach (PropertyInfo property in t.GetProperties())
                {
                    string propertyFullName = string.Concat(t.Name, ".", property.Name);
                    foreach (string key in this.tokens)
                    {
                        if (key != propertyFullName)
                        {
                            continue;
                        }

                        object propertyValue = property.GetValue(item, null);
                        if (propertyValue != null)
                        {
                            pairs.Add(key, propertyValue.ToString());
                        }
                    }
                }
            }

            return pairs;
        }

        private string GetTokenFromTokenKey(string tokenKey)
        {
            return string.Concat(this.TokenStart, tokenKey, this.TokenEnd);
        }

        #endregion
    }
}
