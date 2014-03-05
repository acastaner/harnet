using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harnet.Net
{
    public class Content
    {
        /// <summary>
        /// Length of the returned content in bytes. Should be equal to response.bodySize if there is no compression and bigger when the content has been compressed.
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// MIME type of the response text (value of the Content-Type response header). The charset attribute of the MIME type is included (if available).
        /// </summary>
        public string MimeType { get; set; }
        /// <summary>
        /// Number of bytes saved. Leave out this field if the information is not available.
        /// </summary>
        public int Compression { get; set; }
        /// <summary>
        ///  Response body sent from the server or loaded from the browser cache. This field is populated with textual content only. The text field is either HTTP decoded text or a encoded (e.g. "base64") representation of the response body. Leave out this field if the information is not available.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string Comment { get; set; }
    }
}
