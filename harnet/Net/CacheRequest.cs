using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harnet.Net
{
    public class CacheRequest
    {
        public DateTime Expires { get; set; }
        public DateTime LastAccess { get; set; }
        public string ETag { get; set; }
        public int HitCount { get; set; }
        public string Comment { get; set; }
    }
}
