using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Dto
{
    public class ContentDto
    {
        public int size { get; set; }
        public string mimeType { get; set; }
        public int compression { get; set; }
        public string text { get; set; }
        public string comment { get; set; }
    }
}
