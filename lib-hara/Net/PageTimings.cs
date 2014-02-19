using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harnet.Net
{
    /// <summary>
    /// This object describes timings for various events (states) fired during the page load. All times are specified in milliseconds. If a time info is not available appropriate field is set to -1.
    /// </summary>
    public class PageTimings
    {
        /// <summary>
        /// Content of the page loaded. Number of milliseconds since page load started (page.startedDateTime). Use -1 if the timing does not apply to the current request.
        /// </summary>
        public double OnContentLoad { get; set; }
        /// <summary>
        /// Page is loaded (onLoad event fired). Number of milliseconds since page load started (page.startedDateTime). Use -1 if the timing does not apply to the current request.
        /// </summary>
        public double OnLoad { get; set; }
        /// <summary>
        /// (new in 1.2) - A comment provided by the user or the application.
        /// </summary>
        public string Comment { get; set; }
    }
}
