using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harnet.Net
{
    /// <summary>
    /// This object describes various phases within request-response round trip. All times are specified in milliseconds.
    /// </summary>
    public class Timings
    {
        #region Properties
        /// <summary>
        /// Time spent in a queue waiting for a network connection. Use -1 if the timing does not apply to the current request.
        /// </summary>
        public double Blocked { get; set; }
        /// <summary>
        /// DNS resolution time. The time required to resolve a host name. Use -1 if the timing does not apply to the current request.
        /// </summary>
        public double Dns { get; set; }
        /// <summary>
        /// Time required to create TCP connection. Use -1 if the timing does not apply to the current request.
        /// </summary>
        public double Connect { get; set; }
        /// <summary>
        /// Time required to send HTTP request to the server.
        /// </summary>
        public double Send { get; set; }
        /// <summary>
        /// Time waiting for a response from the server.
        /// </summary>
        public double Wait { get; set; }
        /// <summary>
        ///  Time required to read entire response from the server (or cache).
        /// </summary>
        public double Receive { get; set; }
        /// <summary>
        ///  Time required for SSL/TLS negotiation. If this field is defined then the time is also included in the connect field (to ensure backward compatibility with HAR 1.1). Use -1 if the timing does not apply to the current request.
        /// </summary>
        public double Ssl { get; set; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string Comment { get; set; }
        #endregion
        #region Constructors
        public Timings() { }
        public Timings(int send, int wait, int receive)
        {
            Send = send;
            Wait = wait;
            Receive = receive;
        }
        #endregion
    }
}
