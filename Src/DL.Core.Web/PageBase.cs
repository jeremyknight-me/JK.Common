using System.Web.UI;
using DL.Core.Web.TypeExtensions;

namespace DL.Core.Web
{
    public abstract class PageBase : Page
    {
        /// <summary>Gets the current user of the ASP.NET application.</summary>
        /// <returns>User information or empty string if not found.</returns>
        protected string GetCurrentUser()
        {
            return (new WebRequestUtility()).GetUserFromContext(this.Context);
        }       

        /// <summary>Determines whether or not a query string key is valid.</summary>
        /// <param name="key">Key of the query string to validate.</param>
        /// <returns>True if valid, otherwise false.</returns>
        protected bool IsQueryStringValid(string key)
        {
            return (new WebRequestUtility()).IsQueryStringValid(this.Request, key);
        }

        protected bool IsTitleEmpty()
        {
            return string.IsNullOrEmpty(this.Title);
        }
    }
}
