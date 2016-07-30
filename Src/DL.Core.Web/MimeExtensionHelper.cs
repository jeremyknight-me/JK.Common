using System;
using System.Reflection;
using System.Web;

namespace DL.Core.Web
{
    /// <summary>Static class which calls the internal MimeMapping functionality of .NET 4.0</summary>
    /// <remarks>In the future (.NET 4.5), System.Web.MimeMapping.GetMimeMapping can be used.</remarks>
    public static class MimeExtensionHelper
    {
        private static readonly object locker = new object();
        private static readonly MethodInfo getMimeMappingMethodInfo;
        private static object mimeMapping;

        static MimeExtensionHelper()
        {
            Type mimeMappingType = Assembly.GetAssembly(typeof(HttpRuntime)).GetType("System.Web.MimeMapping");

            if (mimeMappingType == null)
            {
                throw new SystemException("Couldnt find MimeMapping type");
            }

            getMimeMappingMethodInfo = mimeMappingType.GetMethod("GetMimeMapping", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            if (getMimeMappingMethodInfo == null)
            {
                throw new SystemException("Couldnt find GetMimeMapping method");
            }

            if (getMimeMappingMethodInfo.ReturnType != typeof(string))
            {
                throw new SystemException("GetMimeMapping method has invalid return type");
            }

            if (getMimeMappingMethodInfo.GetParameters().Length != 1
                && getMimeMappingMethodInfo.GetParameters()[0].ParameterType != typeof(string))
            {
                throw new SystemException("GetMimeMapping method has invalid parameters");
            }
        }

        /// <summary>Gets the MIME type of the given file name.</summary>
        /// <param name="filename">The file name to use for finding the MIME type.</param>
        /// <returns>The MIME type for the file or application/octet-stream if not found.</returns>
        public static string GetMimeType(string filename)
        {
            lock (locker)
                return (string)getMimeMappingMethodInfo.Invoke(mimeMapping, new object[] { filename });
        }
    }
}