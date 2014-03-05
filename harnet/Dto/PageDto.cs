using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Dto
{
    public class PageDto
    {
        public string startedDateTime { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public PageTimingsDto pageTimings { get; set; }
        public string comment { get; set; }
    }
}
