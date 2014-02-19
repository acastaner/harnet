using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harnet.Net
{
    /// <summary>
    /// This objects contains info about a request coming from browser cache.
    /// </summary>
    public class Cache
    {
        #region Properties
        /// <summary>
        ///  State of a cache entry before the request. Leave out this field if the information is not available.
        /// </summary>
        public BeforeRequest BeforeRequest { get; set; }
        /// <summary>
        ///  State of a cache entry after the request. Leave out this field if the information is not available.
        /// </summary>
        public AfterRequest AfterRequest { get; set; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string Comment { get; set; }
        #endregion
    }
}
