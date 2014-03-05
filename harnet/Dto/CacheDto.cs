using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Dto
{
    public class CacheDto
    {
        public BeforeRequestDto beforerequest{get;set;}
        public AfterRequestDto afterrequest{get;set;}
        public string comment {get;set;}
    }
}
