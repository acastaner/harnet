using Harnet.Dto;
using Harnet.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harnet
{
    public class HarConverter
    {
        public HarConverter() { }

        public static Log ImportHarContent(string content)
        {
            return JsonConvert.DeserializeObject<RootObjectDto>(content).Log.FromDto();
        }
    }
}
