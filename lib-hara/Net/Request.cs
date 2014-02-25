using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harnet.Net
{
    public class Request
    {
        #region Properties
        /// <summary>
        /// Request method (GET, POST, ...).
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// Absolute URL of the request (fragments are not included).
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Request HTTP Version.
        /// </summary>
        public string HttpVersion { get; set; }
        /// <summary>
        /// List of header objects.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }
        /// <summary>
        /// List of query parameter objects.
        /// </summary>
        public List<string> QueryStrings { get; set; }
        /// <summary>
        /// List of cookie objects.
        /// </summary>
        public List<string> Cookies { get; set; }
        /// <summary>
        /// Total number of bytes from the start of the HTTP request message until (and including) the double CRLF before the body. Set to -1 if the info is not available.
        /// </summary>
        public int HeaderSize { get; set; }
        /// <summary>
        /// Size of the request body (POST data payload) in bytes. Set to -1 if the info is not available.
        /// </summary>
        public int BodySize { get; set; }
        /// <summary>
        /// Posted data info.
        /// </summary>
        public PostData PostData { get; set; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string Comment { get; set; }
        #endregion
        #region Methods
        public string GetHeaderValueByName(string name)
        {
            string value = null;
            if (Headers.ContainsKey(name))
            {
                value = Headers[name];
            }
            return value;
        }
        /// <summary>
        /// Attempts to retrieve the filename from the request.
        /// </summary>
        /// <returns>Returns the filename. If no filename is found, returns null.</returns>
        public string GetFileName()
        {
            string fileName = null;
            // Isolate what's after the trailing slash and before any query string
            int index = this.Url.LastIndexOf("/");

            // If difference between index and length is < 1, it means we have no file name
            // e.g.: http://www.fsf.org/
            int diff = Url.Length - index;
            if (index > 0 && diff > 1)
            {
                fileName = this.Url.Substring(index +1, diff -1);
                // If we have query strings we remove them too
                if (this.QueryStrings.Count > 1)
                    fileName = fileName.Substring(0, fileName.IndexOf("?"));
            }
            return fileName;
        }
        #endregion
    }
}
