using Harnet;
using Harnet.Dto;
using Harnet.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace HarA
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = null;
            if (args.Length == 0)
            {
                // Using this for dev to make things easier
                if (File.Exists(@".\www.fsf.org.har"))
                {

                    content = File.ReadAllText(@".\www.fsf.org.har");
                }
                else
                {
                    Console.Write("No HAR file provided.");
                    return;
                }                
            }           

            Log datLog = HarConverter.ImportHarContent(content);
            Console.WriteLine("Total Response size: " + datLog.CumulatedResponseSize + " bytes (headers: "+datLog.CumulatedResponseHeaderSize+" ; bodies: "+datLog.CumulatedResponseBodySize+" )");
            Console.WriteLine("Total Request size: " + datLog.CumulatedRequestSize + " bytes (headers: " + datLog.CumulatedRequestHeaderSize + " ; bodies: " + datLog.CumulatedRequestBodySize + " )");
            WriteReponseFiles(datLog);
            Console.Write("Parsing complete. Press any key to exit.");
            Console.ReadKey();
        }
        private static void WriteReponseFiles(Log harLog)
        {
            string formattedDate = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
            string directory = Directory.GetCurrentDirectory() + "\\" + formattedDate + "\\haranet\\";
            Console.WriteLine("Creating working directory at " + directory);
            Directory.CreateDirectory(directory);
            foreach (Entry entry in harLog.Entries)
            {
                Response r = entry.Response;
                Request req = entry.Request;
                // If status code is < 400 it's 200 or 300, ie: not an error
                if (r.Status < 400)
                {
                    // Store all files under their hostname so we check if it already exists
                    string hostDirectory = directory + req.GetHeaderValueByName("Host") + "\\";
                    if (!Directory.Exists(hostDirectory))
                    {
                        Directory.CreateDirectory(hostDirectory);
                    }


                }
            }
        }
    }
}
