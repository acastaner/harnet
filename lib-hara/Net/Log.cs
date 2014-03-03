/* Implements Http Archive Version 1.2 (Work In Progress) as described here: http://dvcs.w3.org/hg/webperf/raw-file/tip/specs/HAR/Overview.html
 * Custom Fields WILL be ignored as per the specification ("Custom Fields")
 * Arnaud Castaner - arnaud.castaner@outlook.com
 * 01/23/2014
 */

using Harnet.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Net
{
    /// <summary>
    /// This object represents the root of the exported data.
    /// </summary>
    public class Log
    {
        #region Properties
        #region Native HAR properties
        /// <summary>
        /// Required. Version number of the format.
        /// </summary>
        public float Version { get; set; }
        /// <summary>
        /// Required. An object of type creator that contains the name and version information of the log creator application.
        /// </summary>
        public Creator Creator { get; set; }
        /// <summary>
        /// Optional. An array of objects of type page, each representing one exported (tracked) page. Leave out this field if the application does not support grouping by pages.
        /// </summary>
        public List<Page> Pages { get; set; }
        /// <summary>
        /// Required. An array of objects of type entry, each representing one exported (tracked) HTTP request.
        /// </summary>
        public List<Entry> Entries { get; set; }
        /// <summary>
        /// Optional. An object of type browser that contains the name and version information of the user agent.
        /// </summary>
        public Browser Browser { get; set; }       
        /// <summary>
        /// Optional. A comment provided by the user or the application.
        /// </summary>
        public string Comment { get; set; }
        #endregion
        #region HarA properties
        /// <summary>
        /// The cumulated size, in bytes, of all response bodies
        /// </summary>
        public int CumulatedResponseBodySize
        {
            get
            {
                return GetCumulatedResponseBodySize();
            }
            set
            {
                CumulatedResponseBodySize = value;
            }
        }
        /// <summary>
        ///  The cumulated size, in bytes, of all response headers
        /// </summary>
        public int CumulatedResponseHeaderSize
        {
            get
            {
                return GetCumulatedResponseHeaderSize();
            }
            set
            {
                CumulatedResponseHeaderSize = value;
            }
        }
        /// <summary>
        /// The cumulated size, in bytes, of all reponses (headers + bodies)
        /// </summary>
        public int CumulatedResponseSize
        {
            get
            {
                return GetCumulatedReponseSize();
            }
            set
            {
                CumulatedResponseSize = value;
            }
        }
        /// <summary>
        /// The cumulated size, in bytes, of all request bodies
        /// </summary>
        public int CumulatedRequestBodySize
        {
            get
            {
                return GetCumulatedRequestBodySize();
            }
            set
            {
                CumulatedRequestBodySize = value;
            }
        }
        /// <summary>
        /// The cumulated size, in bytes, of all request headers
        /// </summary>
        public int CumulatedRequestHeaderSize
        {
            get
            {
                return GetCumulatedRequestHeaderSize();
            }
            set
            {
                CumulatedRequestHeaderSize = value;
            }
        }
        /// <summary>
        /// The cumulated size, in bytes, of all requests (body + headers)
        /// </summary>
        public int CumulatedRequestSize
        {
            get
            {
                return GetCumulatedRequestSize();
            }
            set
            {
                CumulatedRequestSize = value;
            }
        }
        #endregion HarA properties
        #endregion Properties
        #region Constructors
        public Log() { }
        public Log(int version, Creator creator, Browser browser, List<Page> pages, List<Entry> entries) 
        {
            Version = version;
            Creator = creator;
            Browser = browser;
            Pages = pages;
            Entries = entries;
        }
        /// <summary>
        /// Constructor including all the required properties.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="creator"></param>
        /// <param name="pages"></param>
        public Log(int version, Creator creator, List<Page> pages)
        {
            Version = version;
            Creator = creator;
            Pages = pages;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Returns the cumulated size, in bytes, of all request bodies
        /// </summary>
        /// <returns></returns>
        private int GetCumulatedRequestBodySize()
        {
            int size = 0;
            foreach (Entry entry in Entries)
            {
                size += entry.Request.BodySize;
            }
            return size;
        }
        /// <summary>
        ///  Returns the cumulated size, in bytes, of all request headers
        /// </summary>
        /// <returns></returns>
        private int GetCumulatedRequestHeaderSize()
        {
            int size = 0;
            foreach (Entry entry in Entries)
            {
                size += entry.Request.HeaderSize;
            }
            return size;
        }
        /// <summary>
        ///  Returns the cumulated size, in bytes, of all requests (body + headers)
        /// </summary>
        /// <returns></returns>
        private int GetCumulatedRequestSize()
        {
            return GetCumulatedRequestBodySize() + GetCumulatedRequestHeaderSize();
        }
        /// <summary>
        /// Returns the cumulated size, in bytes, of all response bodies
        /// </summary>
        /// <returns></returns>
        private int GetCumulatedResponseBodySize()
        {
            int size = 0;
            foreach (Entry entry in Entries)
            {
                size += entry.Response.BodySize;
            }
            return size;
        }
        /// <summary>
        /// Returns the cumulated size, in bytes, of all the response headers 
        /// </summary>
        /// <returns></returns>
        private int GetCumulatedResponseHeaderSize()
        {
            int size = 0;
            foreach (Entry entry in Entries)
            {
                size += entry.Response.HeadersSize;
            }
            return size;
        }
        /// <summary>
        /// Returns the cumulated size, in bytes, of both the response headers and bodies
        /// </summary>
        /// <returns></returns>
        private int GetCumulatedReponseSize()
        {
            return GetCumulatedResponseBodySize() + GetCumulatedResponseHeaderSize();
        }
        
        #endregion
    }
}
