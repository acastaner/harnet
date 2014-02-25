using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Tools
{
    public class MediaTypeHelper
    {
        public Dictionary<string, MediaTypes> Mappings { get; set; }

        public MediaTypeHelper()
        {
            Mappings = new Dictionary<string, MediaTypes>();
            PopulateMappings();
        }

        /// <summary>
        /// Populates the Media Type mappings using the Common Media Types from RFC 1700 - http://tools.ietf.org/html/rfc1700
        /// Extra Media Types missing from RFC 1700 have been added based on community usage (e.g. : image/png)
        /// </summary>
        private void PopulateMappings()
        {
            // Try to order sub-types by alphabetical order
            // Text
            Mappings.Add("text/css", MediaTypes.TEXT);
            Mappings.Add("text/html", MediaTypes.TEXT);
            Mappings.Add("text/plain", MediaTypes.TEXT);
            Mappings.Add("text/richtext", MediaTypes.TEXT);
            Mappings.Add("text/tab-separated-values", MediaTypes.TEXT);            

            // Multipart
            Mappings.Add("multipart/alternative", MediaTypes.MULTIPART);
            Mappings.Add("multipart/appledouble", MediaTypes.MULTIPART);
            Mappings.Add("multipart/digest", MediaTypes.MULTIPART);
            Mappings.Add("multipart/header-set", MediaTypes.MULTIPART);
            Mappings.Add("multipart/mixed", MediaTypes.MULTIPART);            
            Mappings.Add("multipart/parallel", MediaTypes.MULTIPART);

            // Message
            Mappings.Add("message/external-body", MediaTypes.MESSAGE);
            Mappings.Add("message/news", MediaTypes.MESSAGE);
            Mappings.Add("message/partial", MediaTypes.MESSAGE);
            Mappings.Add("message/rfc822", MediaTypes.MESSAGE);
            
            // Application
            Mappings.Add("application/activemessage", MediaTypes.APPLICATION);
            Mappings.Add("application/andrew-inset", MediaTypes.APPLICATION);
            Mappings.Add("application/applefile", MediaTypes.APPLICATION);
            Mappings.Add("application/atomicmail", MediaTypes.APPLICATION);            
            Mappings.Add("application/dca-rft", MediaTypes.APPLICATION);
            Mappings.Add("application/dec-dx", MediaTypes.APPLICATION);
            Mappings.Add("application/javascript", MediaTypes.APPLICATION);
            Mappings.Add("application/mac-binhex40", MediaTypes.APPLICATION);
            Mappings.Add("application/macwriteii", MediaTypes.APPLICATION);
            Mappings.Add("application/msword", MediaTypes.APPLICATION);
            Mappings.Add("application/news-message-id", MediaTypes.APPLICATION);
            Mappings.Add("application/news-transmission", MediaTypes.APPLICATION);
            Mappings.Add("application/octet-stream", MediaTypes.APPLICATION);
            Mappings.Add("application/oda", MediaTypes.APPLICATION);
            Mappings.Add("application/pdf", MediaTypes.APPLICATION);
            Mappings.Add("application/postscript", MediaTypes.APPLICATION);
            Mappings.Add("application/remote-printing", MediaTypes.APPLICATION);
            Mappings.Add("application/rtf", MediaTypes.APPLICATION);
            Mappings.Add("application/slate", MediaTypes.APPLICATION);
            Mappings.Add("application/wita", MediaTypes.APPLICATION);
            Mappings.Add("application/wordperfect5.1", MediaTypes.APPLICATION);
            Mappings.Add("application/zip", MediaTypes.APPLICATION);

            // Image
            Mappings.Add("image/gif", MediaTypes.IMAGE);
            Mappings.Add("image/ief", MediaTypes.IMAGE);
            Mappings.Add("image/jpeg", MediaTypes.IMAGE);
            Mappings.Add("image/png", MediaTypes.IMAGE);            
            Mappings.Add("image/tiff", MediaTypes.IMAGE);            
            Mappings.Add("image/webp", MediaTypes.IMAGE);

            // Audio
            Mappings.Add("audio/basic", MediaTypes.AUDIO);

            // Video
            Mappings.Add("video/mpeg", MediaTypes.VIDEO);
            Mappings.Add("video/quicktime", MediaTypes.VIDEO);

        }
    }

    // Content Types are used as in RFC 2046 - http://tools.ietf.org/html/rfc2046
    public enum MediaTypes
    {
        TEXT,
        IMAGE,
        AUDIO,
        VIDEO,
        APPLICATION,
        MULTIPART,
        MESSAGE,
        EXPERIMENTAL
    }
}
