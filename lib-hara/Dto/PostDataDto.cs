using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Dto
{
    public class PostDataDto
    {
        public string mimeType { get; set; }
        public string text { get; set; }
        public ParamDto[] @params { get; set; }
        public string comment { get; set; }
    }
}
