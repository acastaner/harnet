using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harnet.Net
{
    /// <summary>
    /// This object represents list of exported pages.
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Date and time stamp for the beginning of the page load (ISO 8601 - YYYY-MM-DDThh:mm:ss.sTZD, e.g. 2009-07-24T19:20:30.45+01:00).
        /// </summary>
        public DateTime StartedDateTime { get; set; }
        /// <summary>
        /// Unique identifier of a page within the ?. Entries use it to refer the parent page.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Page title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Detailed timing info about page load.
        /// </summary>
        public PageTimings PageTimings { get; set; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string Comment { get; set; }
    }
}
