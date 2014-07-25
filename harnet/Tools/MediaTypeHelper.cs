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
        /// Extra Media Types missing from RFC 1700 have been added from various public lists of Media Types
        /// </summary>
        private void PopulateMappings()
        {
            // Try to order sub-types by alphabetical order
            // Text
            Mappings.Add("text/asp", MediaTypes.TEXT);
            Mappings.Add("text/css", MediaTypes.TEXT);
            Mappings.Add("text/html", MediaTypes.TEXT);
            Mappings.Add("text/javascript", MediaTypes.TEXT);
            Mappings.Add("text/mcf", MediaTypes.TEXT);
            Mappings.Add("application/x-javascript", MediaTypes.TEXT);  // Is actually text
            Mappings.Add("application/javascript", MediaTypes.TEXT);    // Is actually text
            Mappings.Add("application/json", MediaTypes.TEXT);          // Is actually text
            Mappings.Add("text/json", MediaTypes.TEXT);
            Mappings.Add("text/plain", MediaTypes.TEXT);
            Mappings.Add("text/richtext", MediaTypes.TEXT);
            Mappings.Add("text/tab-separated-values", MediaTypes.TEXT);
            Mappings.Add("text/vnd.abc", MediaTypes.TEXT);
            Mappings.Add("text/vnd.fmi.flexstor", MediaTypes.TEXT);
            Mappings.Add("text/webviewhtml", MediaTypes.TEXT);
            Mappings.Add("text/xml", MediaTypes.TEXT);

            Mappings.Add("text/x-audiosoft-intra", MediaTypes.TEXT);
            Mappings.Add("text/x-asm", MediaTypes.TEXT);
            Mappings.Add("text/x-c", MediaTypes.TEXT);
            Mappings.Add("text/x-component", MediaTypes.TEXT);
            Mappings.Add("text/x-fortran", MediaTypes.TEXT);
            Mappings.Add("text/x-h", MediaTypes.TEXT);
            Mappings.Add("text/x-la-asf", MediaTypes.TEXT);
            Mappings.Add("text/x-m", MediaTypes.TEXT);
            Mappings.Add("text/x-setext", MediaTypes.TEXT);
            Mappings.Add("text/x-script", MediaTypes.TEXT);
            Mappings.Add("text/x-script.elisp", MediaTypes.TEXT);
            Mappings.Add("text/x-script.csh", MediaTypes.TEXT);
            Mappings.Add("text/x-script.ksh", MediaTypes.TEXT);
            Mappings.Add("text/x-script.lisp", MediaTypes.TEXT);
            Mappings.Add("text/x-pointplus", MediaTypes.TEXT);
            
            Mappings.Add("application/xml", MediaTypes.TEXT);           // Is actually text
            Mappings.Add("application/rss+xml", MediaTypes.TEXT);       // Is actually text            

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
            Mappings.Add("application/acad", MediaTypes.APPLICATION);
            Mappings.Add("application/activemessage", MediaTypes.APPLICATION);
            Mappings.Add("application/andrew-inset", MediaTypes.APPLICATION);
            Mappings.Add("application/applefile", MediaTypes.APPLICATION);
            Mappings.Add("application/arj", MediaTypes.APPLICATION);
            Mappings.Add("application/atomicmail", MediaTypes.APPLICATION);
            Mappings.Add("application/base64", MediaTypes.APPLICATION);
            Mappings.Add("application/binhex", MediaTypes.APPLICATION);
            Mappings.Add("application/binhex4", MediaTypes.APPLICATION);
            Mappings.Add("application/book", MediaTypes.APPLICATION);
            Mappings.Add("application/cdf", MediaTypes.APPLICATION);
            Mappings.Add("application/clariscad", MediaTypes.APPLICATION);
            Mappings.Add("application/commonground", MediaTypes.APPLICATION);
            Mappings.Add("application/dca-rft", MediaTypes.APPLICATION);
            Mappings.Add("application/dec-dx", MediaTypes.APPLICATION);
            Mappings.Add("application/drafting", MediaTypes.APPLICATION);
            Mappings.Add("application/dxf", MediaTypes.APPLICATION);
            Mappings.Add("application/envoy", MediaTypes.APPLICATION);
            Mappings.Add("application/excel", MediaTypes.APPLICATION);
            Mappings.Add("application/fractals", MediaTypes.APPLICATION);
            Mappings.Add("application/freeloader", MediaTypes.APPLICATION);
            Mappings.Add("application/hlp", MediaTypes.APPLICATION);
            Mappings.Add("application/hta", MediaTypes.APPLICATION);
            Mappings.Add("application/iges", MediaTypes.APPLICATION);
            Mappings.Add("application/inf", MediaTypes.APPLICATION);
            Mappings.Add("application/java", MediaTypes.APPLICATION);
            Mappings.Add("application/java-byte-code", MediaTypes.APPLICATION);
            Mappings.Add("application/lha", MediaTypes.APPLICATION);
            Mappings.Add("application/lzx", MediaTypes.APPLICATION);
            Mappings.Add("application/mac-binary", MediaTypes.APPLICATION);
            Mappings.Add("application/mac-binhex", MediaTypes.APPLICATION);
            Mappings.Add("application/mac-binhex40", MediaTypes.APPLICATION);
            Mappings.Add("application/mac-compactpro", MediaTypes.APPLICATION);
            Mappings.Add("application/macbinary", MediaTypes.APPLICATION);
            Mappings.Add("application/macwriteii", MediaTypes.APPLICATION);
            Mappings.Add("application/marc", MediaTypes.APPLICATION);
            Mappings.Add("application/mcad", MediaTypes.APPLICATION);
            Mappings.Add("application/mbedlet", MediaTypes.APPLICATION);
            Mappings.Add("application/mime", MediaTypes.APPLICATION);
            Mappings.Add("application/mspowerpoint", MediaTypes.APPLICATION);
            Mappings.Add("application/msword", MediaTypes.APPLICATION);
            Mappings.Add("application/mswrite", MediaTypes.APPLICATION);
            Mappings.Add("application/netmc", MediaTypes.APPLICATION);
            Mappings.Add("application/news-message-id", MediaTypes.APPLICATION);
            Mappings.Add("application/news-transmission", MediaTypes.APPLICATION);
            Mappings.Add("application/octet-stream", MediaTypes.APPLICATION);
            Mappings.Add("application/oda", MediaTypes.APPLICATION);
            Mappings.Add("application/pdf", MediaTypes.APPLICATION);
            Mappings.Add("application/pkcs-crl", MediaTypes.APPLICATION);
            Mappings.Add("application/pkix-cert", MediaTypes.APPLICATION);
            Mappings.Add("application/pkcs10", MediaTypes.APPLICATION);
            Mappings.Add("application/pkcs-12", MediaTypes.APPLICATION);
            Mappings.Add("application/postscript", MediaTypes.APPLICATION);
            Mappings.Add("application/powerpoint", MediaTypes.APPLICATION);
            Mappings.Add("application/remote-printing", MediaTypes.APPLICATION);            
            Mappings.Add("application/rtf", MediaTypes.APPLICATION);
            Mappings.Add("application/slate", MediaTypes.APPLICATION);
            Mappings.Add("application/vnd.ms-pki.seccat", MediaTypes.APPLICATION);
            Mappings.Add("application/vnd.fdf", MediaTypes.APPLICATION);
            Mappings.Add("application/vnd.hp-hpgl", MediaTypes.APPLICATION);
            Mappings.Add("application/wita", MediaTypes.APPLICATION);
            Mappings.Add("application/wordperfect5.1", MediaTypes.APPLICATION);
            Mappings.Add("application/wordperfect", MediaTypes.APPLICATION);
            Mappings.Add("application/wordperfect6.0", MediaTypes.APPLICATION);
            Mappings.Add("application/zip", MediaTypes.APPLICATION);

            Mappings.Add("application/x-shockwave-flash", MediaTypes.APPLICATION);
            Mappings.Add("application/x-aim", MediaTypes.APPLICATION);
            Mappings.Add("application/x-authorware-bin", MediaTypes.APPLICATION);
            Mappings.Add("application/x-authorware-map", MediaTypes.APPLICATION);
            Mappings.Add("application/x-authorware-seg", MediaTypes.APPLICATION);
            Mappings.Add("application/x-bcpio", MediaTypes.APPLICATION);
            Mappings.Add("application/x-binary", MediaTypes.APPLICATION);
            Mappings.Add("application/x-binhex40", MediaTypes.APPLICATION);
            Mappings.Add("application/x-bsh", MediaTypes.APPLICATION);
            Mappings.Add("application/x-bzip", MediaTypes.APPLICATION);
            Mappings.Add("application/x-bytecode.elisp", MediaTypes.APPLICATION);
            Mappings.Add("application/x-bzip2", MediaTypes.APPLICATION);
            Mappings.Add("application/x-c", MediaTypes.APPLICATION);
            Mappings.Add("application/x-cdf", MediaTypes.APPLICATION);
            Mappings.Add("application/x-chat", MediaTypes.APPLICATION);
            Mappings.Add("application/x-cocoa", MediaTypes.APPLICATION);
            Mappings.Add("application/x-compactpro", MediaTypes.APPLICATION);
            Mappings.Add("application/x-compressed", MediaTypes.APPLICATION);
            Mappings.Add("application/x-cpt", MediaTypes.APPLICATION);
            Mappings.Add("application/x-cpio", MediaTypes.APPLICATION);
            Mappings.Add("application/x-csh", MediaTypes.APPLICATION);
            Mappings.Add("application/x-deepv", MediaTypes.APPLICATION);
            Mappings.Add("application/x-director", MediaTypes.APPLICATION);
            Mappings.Add("application/x-elc", MediaTypes.APPLICATION);
            Mappings.Add("application/x-envoy", MediaTypes.APPLICATION);
            Mappings.Add("application/x-esrehber", MediaTypes.APPLICATION);
            Mappings.Add("application/x-excel", MediaTypes.APPLICATION);
            Mappings.Add("application/x-frame", MediaTypes.APPLICATION);
            Mappings.Add("application/x-gsp", MediaTypes.APPLICATION);
            Mappings.Add("application/x-gss", MediaTypes.APPLICATION);
            Mappings.Add("application/x-gtar", MediaTypes.APPLICATION);
            Mappings.Add("application/x-gzip", MediaTypes.APPLICATION);
            Mappings.Add("application/x-ksh", MediaTypes.APPLICATION);
            Mappings.Add("application/x-java-commerce", MediaTypes.APPLICATION);
            Mappings.Add("application/x-java-source", MediaTypes.APPLICATION);
            Mappings.Add("application/x-helpfile", MediaTypes.APPLICATION);
            Mappings.Add("application/x-hdf", MediaTypes.APPLICATION);
            Mappings.Add("application/x-httpd-imap", MediaTypes.APPLICATION);
            Mappings.Add("application/x-ima", MediaTypes.APPLICATION);
            Mappings.Add("application/x-internett-signup", MediaTypes.APPLICATION);
            Mappings.Add("application/x-inventor", MediaTypes.APPLICATION);
            Mappings.Add("application/x-ip2", MediaTypes.APPLICATION);
            Mappings.Add("application/x-java-class", MediaTypes.APPLICATION);
            Mappings.Add("application/x-latex", MediaTypes.APPLICATION);
            Mappings.Add("application/x-lha", MediaTypes.APPLICATION);
            Mappings.Add("application/x-lisp", MediaTypes.APPLICATION);
            Mappings.Add("application/x-livescreen", MediaTypes.APPLICATION);
            Mappings.Add("application/x-lzh", MediaTypes.APPLICATION);
            Mappings.Add("application/x-lzx", MediaTypes.APPLICATION);
            Mappings.Add("application/x-macbinary", MediaTypes.APPLICATION);
            Mappings.Add("application/x-mac-binhex40", MediaTypes.APPLICATION);
            Mappings.Add("application/x-magic-cap-package-1.0", MediaTypes.APPLICATION);
            Mappings.Add("application/x-mathcad", MediaTypes.APPLICATION);
            Mappings.Add("application/x-meme", MediaTypes.APPLICATION);
            Mappings.Add("application/x-midi", MediaTypes.APPLICATION);
            Mappings.Add("application/x-mif", MediaTypes.APPLICATION);
            Mappings.Add("application/x-mplayer2", MediaTypes.APPLICATION);
            Mappings.Add("application/x-navi-animation", MediaTypes.APPLICATION);
            Mappings.Add("application/x-navimap", MediaTypes.APPLICATION);
            Mappings.Add("application/x-netcdf", MediaTypes.APPLICATION);
            Mappings.Add("application/x-nokia-9000-communicator-add-on-software", MediaTypes.APPLICATION);
            Mappings.Add("application/x-pkcs10", MediaTypes.APPLICATION);
            Mappings.Add("application/x-pkcs12", MediaTypes.APPLICATION);
            Mappings.Add("application/x-project", MediaTypes.AUDIO);
            Mappings.Add("application/x-rtf", MediaTypes.APPLICATION);
            Mappings.Add("application/x-troff-man", MediaTypes.APPLICATION);
            Mappings.Add("application/x-troff-me", MediaTypes.APPLICATION);
            Mappings.Add("application/x-troff-ms", MediaTypes.APPLICATION);
            Mappings.Add("application/x-troff-msvideo", MediaTypes.APPLICATION);
            Mappings.Add("application/x-visio", MediaTypes.APPLICATION);
            Mappings.Add("application/x-winhelp", MediaTypes.APPLICATION);
            Mappings.Add("application/x-x509-ca-cert", MediaTypes.APPLICATION);
            Mappings.Add("application/x-x509-user-cert", MediaTypes.APPLICATION);
            Mappings.Add("application/x-zip", MediaTypes.APPLICATION);

            Mappings.Add("font/woff", MediaTypes.APPLICATION); // This should be application/font-woff but some servers will return this
            
            // Image
            Mappings.Add("image/bmp", MediaTypes.IMAGE);
            Mappings.Add("image/fif", MediaTypes.IMAGE);
            Mappings.Add("image/florian", MediaTypes.IMAGE);
            Mappings.Add("image/g3fax", MediaTypes.IMAGE);
            Mappings.Add("image/gif", MediaTypes.IMAGE);
            Mappings.Add("image/ief", MediaTypes.IMAGE);
            Mappings.Add("image/jpeg", MediaTypes.IMAGE);
            Mappings.Add("image/jpg", MediaTypes.IMAGE);
            Mappings.Add("image/jutvision", MediaTypes.IMAGE);
            Mappings.Add("image/pict", MediaTypes.IMAGE);
            Mappings.Add("image/pjpeg", MediaTypes.IMAGE);
            Mappings.Add("image/png", MediaTypes.IMAGE);
            Mappings.Add("image/svg+xml", MediaTypes.IMAGE);
            Mappings.Add("image/tiff", MediaTypes.IMAGE);
            Mappings.Add("image/vasa", MediaTypes.IMAGE);
            Mappings.Add("image/vnd.dwg", MediaTypes.IMAGE);
            Mappings.Add("image/vnd.fpx", MediaTypes.IMAGE);
            Mappings.Add("image/vnd.net-fpx", MediaTypes.IMAGE);
            Mappings.Add("image/webp", MediaTypes.IMAGE);

            Mappings.Add("image/x-dwg", MediaTypes.IMAGE);
            Mappings.Add("image/x-icon", MediaTypes.IMAGE);
            Mappings.Add("image/x-jg", MediaTypes.IMAGE);
            Mappings.Add("image/x-jps", MediaTypes.IMAGE);
            Mappings.Add("image/x-tiff", MediaTypes.IMAGE);
            Mappings.Add("image/x-portable-bitmap", MediaTypes.IMAGE);
            Mappings.Add("image/x-windows-bmp", MediaTypes.IMAGE);

            // Audio
            Mappings.Add("audio/basic", MediaTypes.AUDIO);
            Mappings.Add("audio/aiff", MediaTypes.AUDIO);
            Mappings.Add("audio/it", MediaTypes.AUDIO);
            Mappings.Add("audio/make", MediaTypes.AUDIO);
            Mappings.Add("audio/midi", MediaTypes.AUDIO);
            Mappings.Add("audio/mpeg", MediaTypes.AUDIO);
            Mappings.Add("audio/mpeg3", MediaTypes.AUDIO);
            Mappings.Add("audio/mod", MediaTypes.AUDIO);
            Mappings.Add("audio/nspaudio", MediaTypes.AUDIO);
            Mappings.Add("audio/wav", MediaTypes.AUDIO);

            Mappings.Add("audio/x-aiff", MediaTypes.AUDIO);
            Mappings.Add("audio/x-au", MediaTypes.AUDIO);
            Mappings.Add("audio/x-gsm", MediaTypes.AUDIO);
            Mappings.Add("audio/x-jam", MediaTypes.AUDIO);
            Mappings.Add("audio/x-midi", MediaTypes.AUDIO);
            Mappings.Add("audio/x-mid", MediaTypes.AUDIO);
            Mappings.Add("audio/x-mpeg", MediaTypes.AUDIO);
            Mappings.Add("audio/x-mpeg3", MediaTypes.AUDIO);
            Mappings.Add("audio/x-mod", MediaTypes.AUDIO);
            Mappings.Add("audio/x-pn-realaudio", MediaTypes.AUDIO);
            Mappings.Add("audio/x-pn-realaudio-plugin", MediaTypes.AUDIO);
            Mappings.Add("audio/x-liveaudio", MediaTypes.AUDIO);
            Mappings.Add("audio/x-mpequrl", MediaTypes.AUDIO);
            Mappings.Add("audio/x-nspaudio", MediaTypes.AUDIO);

            // Video
            Mappings.Add("video/animaflex", MediaTypes.VIDEO);
            Mappings.Add("video/avi", MediaTypes.VIDEO);
            Mappings.Add("video/avs-video", MediaTypes.VIDEO);
            Mappings.Add("video/dl", MediaTypes.VIDEO);
            Mappings.Add("video/fli", MediaTypes.VIDEO);
            Mappings.Add("video/gl", MediaTypes.VIDEO);
            Mappings.Add("video/make", MediaTypes.VIDEO);
            Mappings.Add("video/mpeg", MediaTypes.VIDEO);
            Mappings.Add("video/msvideo", MediaTypes.VIDEO);
            Mappings.Add("video/quicktime", MediaTypes.VIDEO);
            Mappings.Add("video/vivo", MediaTypes.VIDEO);

            Mappings.Add("video/x-atomic3d-feature", MediaTypes.VIDEO);
            Mappings.Add("video/x-dl", MediaTypes.VIDEO);
            Mappings.Add("video/x-dv", MediaTypes.VIDEO);
            Mappings.Add("video/x-dvi", MediaTypes.VIDEO);
            Mappings.Add("video/x-dwf", MediaTypes.VIDEO);
            Mappings.Add("video/x-fli", MediaTypes.VIDEO);
            Mappings.Add("video/x-flv", MediaTypes.VIDEO);
            Mappings.Add("video/x-gl", MediaTypes.VIDEO);
            Mappings.Add("video/x-isvideo", MediaTypes.VIDEO);
            Mappings.Add("video/x-mpeg", MediaTypes.VIDEO);
            Mappings.Add("video/x-mpeg2", MediaTypes.VIDEO);
            Mappings.Add("video/x-ms-asf", MediaTypes.VIDEO);
            Mappings.Add("video/x-ms-asf-plugin", MediaTypes.VIDEO);
            Mappings.Add("video/x-msvideo", MediaTypes.VIDEO);
            Mappings.Add("video/x-motion-jpeg", MediaTypes.VIDEO);
            Mappings.Add("video/x-sgi-movie", MediaTypes.VIDEO);

            // Experimental
            // I've put here what doesn't 'fit' in other categories
            Mappings.Add("i-world/i-vrml", MediaTypes.VIDEO);
            Mappings.Add("music/crescendo", MediaTypes.VIDEO);
            Mappings.Add("music/x-karaoke", MediaTypes.VIDEO);
            
            Mappings.Add("ww/mime", MediaTypes.VIDEO);
            Mappings.Add("x-conference/x-cooltalk", MediaTypes.VIDEO);
            Mappings.Add("x-music/x-midi", MediaTypes.VIDEO);

            Mappings.Add("x-unknown", MediaTypes.EXPERIMENTAL); // Yes, servers actually send this sometimes
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
