using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using DL.Core.Web.TypeExtensions;

namespace DL.Core.UI.WebForms.Pages
{
    public partial class MimeTypes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var utility = new WebRequestUtility();
                var text = DataTextBox;
                text.Text = string.Empty;

                foreach (var extension in this.FileExtensions())
                {
                    string fileName = string.Concat("file.", extension);
                    string mimeType = MimeMapping.GetMimeMapping(fileName);
                    
                    text.Text += "Extension: " + extension + Environment.NewLine;
                    text.Text += "MIME Type: " + utility.GetMimeType(extension) + Environment.NewLine + Environment.NewLine;
                }
            }
        }

        private IEnumerable<string> FileExtensions()
        {
            return new List<string> {"jpg", "jpeg", "txt", "docx", "doc", "pdf", "gif", "png", "xls", "xlsx", "csv"};
        }
    }
}