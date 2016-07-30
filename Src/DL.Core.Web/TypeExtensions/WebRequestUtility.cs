using System.Text.RegularExpressions;
using System.Web;

namespace DL.Core.Web.TypeExtensions
{
    public class WebRequestUtility
    {
        /// <summary>
        /// Gets the current user of the ASP.NET application.
        /// </summary>
        /// <param name="context">The HttpContext object to use.</param>
        /// <returns>User information or empty string if not found.</returns>
        public string GetUserFromContext(HttpContext context)
        {
            string userIdentity = context.User.Identity.Name;
            if (!string.IsNullOrEmpty(userIdentity))
            {
                return userIdentity;
            }

            string logonUser = this.GetRequestLogonUser(context.Request);
            if (!string.IsNullOrEmpty(logonUser))
            {
                return logonUser;
            }

            string remoteUser = this.GetRequestRemoteUser(context.Request);
            if (!string.IsNullOrEmpty(remoteUser))
            {
                return remoteUser;
            }

            return string.Empty;
        }

        /// <summary>
        /// Determines whether or not a query string key is valid.
        /// </summary>
        /// <param name="request">Current HttpRequest object.</param>
        /// <param name="key">Key of the query string to validate.</param>
        /// <returns>True if valid, otherwise false.</returns>
        public bool IsQueryStringValid(HttpRequest request, string key)
        {
            return request.QueryString[key] != null
                   && !string.IsNullOrEmpty(request.QueryString[key]);
        }

        /// <summary>
        /// Ensures that the given file name is valid in a request header.
        /// </summary>
        /// <param name="name">File name to check.</param>
        /// <returns>Valid request header file name.</returns>
        public string EnsureValidRequestFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]+", invalidChars);
            string replace = Regex.Replace(name, invalidReStr, "_").Replace(";", "").Replace(",", "");
            return replace;
        }

        /// <summary>
        /// Gets the correct MIME type for the given file extension.
        /// </summary>
        /// <param name="fileExtension">File extension</param>
        /// <returns>
        /// The correct MIME type for the given file extension. 
        /// For example, a .jpg file will return the type of 'image/jpeg'.
        /// </returns>
        public string GetMimeType(string fileExtension)
        {
            string fileName = string.Concat("file.", fileExtension); // .NET Library needs full file name
            return MimeMapping.GetMimeMapping(fileName);
        }

        private string GetRequestLogonUser(HttpRequest request)
        {
            string user = request.ServerVariables["LOGON_USER"];
            return string.IsNullOrEmpty(user) ? string.Empty : user;
        }

        private string GetRequestRemoteUser(HttpRequest request)
        {
            string user = request.ServerVariables["REMOTE_USER"];
            return string.IsNullOrEmpty(user) ? string.Empty : user;
        }
    }
}
