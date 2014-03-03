using Harnet.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Harnet.Net
{
    public class Response
    {
        #region Properties
        #region HAR specification properties
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
        public Dictionary<string, string> Headers { get; set; }
        /// <summary>
        /// List of cookie objects.
        /// </summary>
        public Dictionary<string, string> Cookies { get; set; }
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
        #endregion
        #endregion
        #region Methods
        /// <summary>
        /// Returns whether or not the current response is of Media Type text, based on MIME Type.
        /// </summary>
        /// <returns></returns>
        public bool IsText()
        {
            bool isText = false;
            MediaTypeHelper mt = new MediaTypeHelper();

            // Put this in two different conditions to catch unknown Media Types
            if (mt.Mappings.ContainsKey(Content.MimeType))
            {
                if(mt.Mappings[Content.MimeType] == MediaTypes.TEXT)
                {
                    isText = true;
                }
            }
            else
            {
                throw new NotImplementedException("The provided Media Type ("+Content.MimeType+") is unknown.");
            }

            return isText;
        }
        /// <summary>
        /// Returns whether or not the current response is of Media Type image, based on MIME Type.
        /// </summary>
        /// <returns></returns>
        public bool IsImage()
        {
            bool isImage = false;
            MediaTypeHelper mt = new MediaTypeHelper();

            // Put this in two different conditions to catch unknown Media Types
            if (mt.Mappings.ContainsKey(Content.MimeType))
            {
                if (mt.Mappings[Content.MimeType] == MediaTypes.IMAGE)
                {
                    isImage = true;
                }
            }
            else
            {
                throw new NotImplementedException("The provided Media Type (" + Content.MimeType + ") is unknown.");
            }            
            return isImage;
        }
        /// <summary>
        /// Writes the content of this response as an image to the specified path, if the reponse is an image.
        /// </summary>
        /// <param name="path"></param>
        public void WriteToImage(string path)
        {
            if (this.IsImage())
            {
                ForceWriteToImage(path);
            }
            else
            {
                throw new Exception("According to its Media Type, this response is not an image. Ensure Media Type, or use ForceWriteToImage() to write.");
            }
        }
        /// <summary>
        /// Writes the content of this response as an image to the specificied path without checking for its Media Type.
        /// </summary>
        /// <param name="path"></param>
        public void ForceWriteToImage(string path)
        {
            Byte[] data = Convert.FromBase64String(Content.Text);
            using (var dstFile = new FileStream(path, FileMode.Create))
            {
                dstFile.Write(data, 0, data.Length);
                dstFile.Flush();
            }
        }
        /// <summary>
        /// Writes the content of this response to the specified path, including the file name.
        /// </summary>
        /// <param name="path"></param>
        public void WriteContentToText(string path)
        {
            File.WriteAllText(path, Content.Text);
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
        /// Returns whether or not this request contains headers.
        /// </summary>
        /// <returns></returns>
        public bool HasCookies()
        {
            return (this.Cookies.Count > 0) ? true : false;
        }
        #endregion
    }
}
