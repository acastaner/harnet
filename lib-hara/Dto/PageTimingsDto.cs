using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Dto
{
    public class PageTimingsDto
    {
        public double onContentLoad { get; set; }
        public double onLoad { get; set; }
        public string comment { get; set; }
    }
}
