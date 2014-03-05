using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harnet.Net
{
    public class PostData
    {
        public string MimeType { get; set; }
        public string Text { get; set; }
        public List<Param> Params { get; set; }
        public string Comment { get; set; }
    }
}
