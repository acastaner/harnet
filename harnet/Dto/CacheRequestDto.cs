using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Dto
{
    public class CacheRequestDto
    {
        public string expires { get; set; }
        public string lastaccess { get; set; }
        public string etag { get; set; }
        public int hitcount { get; set; }
        public string comment { get; set; }
    }
}
