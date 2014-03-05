using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Dto
{
    public class LogDto
    {
        public string version { get; set; }
        public CreatorDto creator { get; set; }
        public List<PageDto> pages { get; set; }
        public List<EntryDto> entries { get; set; }
        public BrowserDto browser { get; set; }
        public string comment { get; set; }
    }
}
