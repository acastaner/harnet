using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harnet.Net
{
    public class Response
    {
        /// <summary>
        /// Response status.
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Response status description.
        /// </summary>
        public string StatusText { get; set; }
        /// <summary>
        ///  Response HTTP Version.
        /// </summary>
        public string HttpVersion { get; set; }
        /// <summary>
        /// List of header objects.
        /// </summary>
        public List<string> Headers { get; set; }
        /// <summary>
        /// List of cookie objects.
        /// </summary>
        public List<string> Cookies { get; set; }
        /// <summary>
        /// Details about the response body.
        /// </summary>
        public Content Content { get; set; }
        /// <summary>
        /// Redirection target URL from the Location response header.
        /// </summary>
        public string RedirectUrl { get; set; }
        /// <summary>
        /// Total number of bytes from the start of the HTTP response message until (and including) the double CRLF before the body. Set to -1 if the info is not available.
        /// </summary>
        public int HeadersSize { get; set; }
        /// <summary>
        /// Size of the received response body in bytes. Set to zero in case of responses coming from the cache (304). Set to -1 if the info is not available.
        /// </summary>
        public int BodySize { get; set; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string Comment { get; set; }

    }
}
