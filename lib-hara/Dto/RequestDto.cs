using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Dto
{
    public class RequestDto
    {
        public string method { get; set; }
        public string url { get; set; }
        public string httpVersion { get; set; }
        public List<object> headers { get; set; }
        public List<object> queryString { get; set; }
        public List<object> cookies { get; set; }
        public int headersSize { get; set; }
        public int bodySize { get; set; }
        public PostDataDto postData { get; set; }
        public string comment { get; set; }
    }
}
