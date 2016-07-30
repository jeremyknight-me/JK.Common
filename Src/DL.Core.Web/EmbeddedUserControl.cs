using System;
using System.IO;
using System.Reflection;
using System.Web.UI;

namespace DL.Core.Web
{
    /// <summary>Class used to inflate embedded user control file templates into valid controls.</summary>
    /// <remarks>Cannot use Eval() in data bound control templates. Must use Bind()</remarks>
    public abstract class EmbeddedUserControl : UserControl
    {
        /// <summary>
        /// Name of the User Control template file. Must include .ascx
        /// </summary>
        private readonly string userControlFileName;

        /// <summary>
        /// Initializes a new instance of the EmbeddedUserControl class.
        /// </summary>
        /// <param name="userControlFileNameToUse">Name of the User Control template file. Must include .ascx</param>
        protected EmbeddedUserControl(string userControlFileNameToUse)
        {
            this.userControlFileName = userControlFileNameToUse;
        }

        /// <summary>
        /// Gets or sets the embedded control.
        /// </summary>
        protected Control EmbeddedControl { get; set; }

        /// <summary>
        /// Override of the OnInit method.
        /// </summary>
        /// <param name="e">EventArgs of the OnInit method.</param>
        protected override void OnInit(EventArgs e)
        {
            this.EmbeddedControl = this.GetUserControlFromAssembly(this.userControlFileName);
            Controls.Add(this.EmbeddedControl);
        }

        /// <summary>
        /// Uses the given file template to create a valid control object.
        /// </summary>
        /// <param name="ascxFile">Name of the User Control template file. Must include .ascx</param>
        /// <returns>Control parsed from the given user control template.</returns>
        private Control GetUserControlFromAssembly(string ascxFile)
        {
            Stream stream 
                = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), ascxFile);

            if (stream != null)
            {
                string content;
                using (var reader = new StreamReader(stream))
                {
                    content = reader.ReadToEnd();
                }

                Control userControl = Page.ParseControl(content);
                return userControl;    
            }

            return null;
        }
    }
}
