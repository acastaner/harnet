using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Net
{
    /// <summary>
    /// This object contains information about the browser that created the log.
    /// </summary>
    public class Browser
    {
        #region Properties
        /// <summary>
        /// Required. The name of the browser that created the log.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Required. The version number of the browser that created the log.
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Optional. A comment provided by the user or the browser.
        /// </summary>
        public string Comment { get; set; }
        #endregion
        #region Constructors
        public Browser() { }
        public Browser(string name, string version)
        {
            Name = name;
            Version = version;
        }
        #endregion
    }
}
