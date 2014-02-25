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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HarA
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                string[] filePaths = Directory.GetFiles(@".", "*.har");
                // Using this for dev to make things easier
                if (filePaths.Length >= 1)
                {
                    foreach (string path in filePaths)
                    {
                        HandleHarFile(path);
                    }
                }
                else
                {
                    Console.WriteLine("No HAR file provided. Press any key to exit.");
                    Console.ReadKey();
                    return;
                }                
            }    
            
            Console.Write("Parsing complete. Press any key to exit.");
            Console.ReadKey();
        }

        private static void HandleHarFile(string filePath)
        {
            string content = File.ReadAllText(filePath);
            Log datLog = HarConverter.ImportHarContent(content);
            Console.WriteLine("Total Response size: " + datLog.CumulatedResponseSize + " bytes (headers: " + datLog.CumulatedResponseHeaderSize + " ; bodies: " + datLog.CumulatedResponseBodySize + " )");
            Console.WriteLine("Total Request size: " + datLog.CumulatedRequestSize + " bytes (headers: " + datLog.CumulatedRequestHeaderSize + " ; bodies: " + datLog.CumulatedRequestBodySize + " )");
            Console.WriteLine("Found " + datLog.Entries.Count + " entries in log.");
            WriteReponseFiles(datLog, Path.GetFileName(filePath));
        }
        private static void WriteReponseFiles(Log harLog, string logFileName)
        {
            string formattedDate = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
            string directory = Directory.GetCurrentDirectory() + "\\" + formattedDate + "\\"+logFileName+"\\";
            Console.WriteLine("Creating working directory at " + directory);
            Directory.CreateDirectory(directory);
            foreach (Entry entry in harLog.Entries)
            {
                Response resp = entry.Response;
                Request req = entry.Request;
                string fileName = (req.GetFileName() != null) ? req.GetFileName() : req.GetHeaderValueByName("Host") + "\\index.html";

                Console.WriteLine("\tProcessing " + fileName + " ("+resp.Content.MimeType+")");
                // If status code is < 400 it's 200 or 300, ie: not an error
                if (resp.Status < 400)
                {
                    // We keep the whole URL to build directory but need to remove special characters and query strings
                    
                    string filePath = Path.GetDirectoryName(directory + GetCleanUrl(req)) + "\\" + fileName;
                    // Windows as a limitation of 248 on path name and 260 for FQP so we truncate at 248
                    if (filePath.Length >= 248)
                    {
                        Console.WriteLine("\t WARNING! Path was too long and had to be truncated for " + filePath);
                        filePath = filePath.Substring(0, 248);                        
                    }

                    string storingDirectory = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(storingDirectory))
                        Directory.CreateDirectory(storingDirectory);

                    WriteFile(filePath, resp);
                }
            }
        }
        private static void WriteFile(string path, Response resp)
        {
            // We default to write to text (sometimes MIME Type is omitted)
            if(resp.Content.MimeType == "" | resp.Content.MimeType == null )
            {
                Console.WriteLine("\tWARNING! Media Type not specified for " + Path.GetFileName(path) + ", will be written as text.");
                resp.WriteContentToText(path);
            }
            else if (resp.IsText())
            {
                resp.WriteContentToText(path);
            }
            else
            {
                if (resp.IsImage())
                {
                    resp.WriteContentToImage(path);
                }                
            }
        }
        /// <summary>
        /// Returns a the Request.Url property cleaned from any HTTP prefix, query string or special characters
        /// </summary>
        /// <returns></returns>
        public static string GetCleanUrl(Request request)
        {
            string cleanString = request.StripQueryStringsFromUrl();
            cleanString = StripProtocolPrefix(cleanString);
            cleanString = StripTrailingSlash(cleanString);
            cleanString = EscapeSpecialCharacters(cleanString);
            return cleanString;
        }

        private static string EscapeSpecialCharacters(string path)
        {
            string ret = Regex.Replace(path, "[?!*<>|]", "_", RegexOptions.None);
            return ret.ToString();
        }
        /// <summary>
        /// This method will remove protocol (http(s)://) prefix from URLs 
        /// <param name="input"></param>
        /// <returns></returns>
        private static string StripProtocolPrefix(string input)
        {
            return Regex.Replace(input, "^(http|https)://", "", RegexOptions.None);
        }

        private static string StripTrailingSlash(string input)
        {
            return input.TrimEnd('/');
        }
    }
}
