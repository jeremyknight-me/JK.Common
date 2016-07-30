using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DL.Core.Web.TypeExtensions
{
    public class WebControlUtility
    {
        public void AddCssClass(WebControl control, string cssClass)
        {
            ICollection<string> controlClasses = this.GetClasses(control.CssClass);
            IEnumerable<string> classesToAdd = this.GetClasses(cssClass);

            foreach (string classToAdd in classesToAdd)
            {
                this.AddClassToList(controlClasses, classToAdd);
            }

            control.CssClass = this.MergeClasses(controlClasses);
        }

        public void ReplaceCssClass(WebControl control, string removeClass, string addClass)
        {
            ICollection<string> controlClasses = this.GetClasses(control.CssClass);
            this.RemoveClassFromList(controlClasses, removeClass);
            this.AddClassToList(controlClasses, addClass);
            control.CssClass = this.MergeClasses(controlClasses);
        }

        public void RemoveCssClass(WebControl control, string cssClass)
        {
            ICollection<string> controlClasses = this.GetClasses(control.CssClass);
            IEnumerable<string> classesToRemove = this.GetClasses(cssClass);

            foreach (string classToAdd in classesToRemove)
            {
                this.RemoveClassFromList(controlClasses, classToAdd);
            }

            control.CssClass = this.MergeClasses(controlClasses);
        }

        /// <summary>Finds a control by ID.</summary>
        /// <param name="root">System.Web.UI.Control object to use as the root of the find control search.</param>
        /// <param name="idToFind">ID of the control you wish to find within the root control.</param>
        /// <returns>The Control object with the given ID or null if not found.</returns>
        public Control FindControlRecursive(Control root, string idToFind)
        {
            if (root.ID == idToFind)
            {
                return root;
            }

            return (from Control control in root.Controls
                    select FindControlRecursive(control, idToFind))
                    .FirstOrDefault(childControl => childControl != null);
        }

        #region Private Methods - CSS Class Manipulation Helpers

        private string MergeClasses(IEnumerable<string> classes)
        {
            var stringDelimiter = new StringDelimiter(" ");

            foreach (string cssClass in classes)
            {
                stringDelimiter.AddText(cssClass);
            }

            return stringDelimiter.DelimitedText;
        }

        private ICollection<string> GetClasses(string classes)
        {
            return classes
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .ToList();
        }

        private void AddClassToList(ICollection<string> controlClasses, string cssClass)
        {
            if (!controlClasses.Contains(cssClass))
            {
                controlClasses.Add(cssClass);
            }
        }

        private void RemoveClassFromList(ICollection<string> controlClasses, string cssClass)
        {
            if (controlClasses.Contains(cssClass))
            {
                controlClasses.Remove(cssClass);
            }
        }

        #endregion
    }
}
