using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Harnet.Net
{
    /// <summary>
    /// This object represents an array with all exported HTTP requests. Sorting entries by startedDateTime (starting from the oldest) is preferred way how to export data since it can make importing faster. However the reader application should always make sure the array is sorted (if required for the import).
    /// </summary>
    public class Entry
    {
        #region Properties
        /// <summary>
        /// Reference to the parent page. Leave out this field if the application does not support grouping by pages.
        /// </summary>
        public string PageRef { get; set; }
        /// <summary>
        /// Date and time stamp of the request start (ISO 8601 - YYYY-MM-DDThh:mm:ss.sTZD).
        /// </summary>
        public DateTime StartedDateTime { get; set; }
        /// <summary>
        /// Total elapsed time of the request in milliseconds. This is the sum of all timings available in the timings object (i.e. not including -1 values) .
        /// </summary>
        public TimeSpan Time { get; set; }
        /// <summary>
        /// Detailed info about the request.
        /// </summary>
        public Request Request{ get; set; }
        /// <summary>
        /// Detailed info about the response.
        /// </summary>
        public Response Response {get; set;}
        /// <summary>
        /// Info about cache usage.
        /// </summary>
        public Cache Cache { get; set; }
        /// <summary>
        /// Detailed timing info about request/response round trip.
        /// </summary>
        public Timings Timings { get; set; }
        /// <summary>
        /// IP address of the server that was connected (result of DNS resolution).
        /// </summary>
        // TODO
        //public IpAddress ServerIpAddress { get; set; }
        /// <summary>
        /// Unique ID of the parent TCP/IP connection, can be the client port number. Note that a port number doesn't have to be unique identifier in cases where the port is shared for more connections. If the port isn't available for the application, any other unique connection ID can be used instead (e.g. connection index). Leave out this field if the application doesn't support this info.
        /// </summary>
        public int Connection { get; set; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string Comment { get; set; }
        #endregion
        #region Methods
        
        #endregion
    }
}
