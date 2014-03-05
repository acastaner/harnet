using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
        public Dictionary<string, List<string>> Headers { get; set; }
        /// <summary>
        /// List of query parameter objects.
        /// </summary>
        public Dictionary<string, List<string>> QueryStrings { get; set; }
        /// <summary>
        /// List of cookie objects.
        /// </summary>
        public Dictionary<string, List<string>> Cookies { get; set; }
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
        public List<string> GetHeaderValueByHeaderName(string name)
        {
            List<string> value = null;
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

            // If we have query strings we remove them first because sometimes they get funky
            if (this.QueryStrings.Count >= 1)
                {
                    fileName = StripQueryStringsFromUrl();
                }
            else
                fileName = Url;

            // Isolate what's after the trailing slash and before any query string
            int index = fileName.LastIndexOf("/");

            // If difference between index and length is < 1, it means we have no file name
            // e.g.: http://www.fsf.org/
            int diff = fileName.Length - index;
            if (index > 0 && diff > 1)
                fileName = fileName.Substring(index +1, diff - 1);
            else
                fileName = null;
            return fileName;
        }
        
        /// <summary>
        /// Strips the Url of all query strings and returns it (e.g. www.fsf.org/index.html?foo=bar returns www.fsg.org/index.html).
        /// </summary>
        /// <returns></returns>
        public string StripQueryStringsFromUrl()
        {
            int indexOf = Url.IndexOf("?");
            if (indexOf >= 1)
                return Url.Substring(0, indexOf);
            else
                return Url;
        }
        /// <summary>
        /// Returns whether or not this request contains cookies.
        /// </summary>
        /// <returns></returns>
        public bool HasCookies()
        {
            return (this.Cookies.Count > 0) ? true : false;
        }
        /// <summary>
        /// Returns whether or not this request contains headers.
        /// </summary>
        /// <returns></returns>
        public bool HasHeaders()
        {
            return (this.Headers.Count > 0) ? true : false;
        }
        /// <summary>
        /// Returns whether or not this request contains query strings.
        /// </summary>
        /// <returns></returns>
        public bool HasQueryStrings()
        {
            return (this.QueryStrings.Count > 0) ? true : false;
        }
        #endregion
    }
}
