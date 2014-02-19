using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet.Dto
{
    public class TimingsDto
    {
        public double blocked { get; set; }
        public double dns { get; set; }
        public double connect { get; set; }
        public double send { get; set; }
        public double wait { get; set; }
        public double receive { get; set; }
        public double ssl { get; set; }
        public string comment { get; set; }
    }
}
