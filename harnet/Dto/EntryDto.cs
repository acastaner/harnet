using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Dto
{
    public class EntryDto
    {
        public string pageref { get; set; }
        public string startedDateTime { get; set; }
        public double time { get; set; }
        public RequestDto request { get; set; }
        public ResponseDto response { get; set; }
        public CacheDto cache { get; set; }
        public TimingsDto timings { get; set; }
        public string connection { get; set; }
    }
}
