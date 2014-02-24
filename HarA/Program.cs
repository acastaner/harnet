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
                    Console.WriteLine("No HAR file provided. Press any key to exit.");
                    Console.ReadKey();
                    return;
                }                
            }           

            Log datLog = HarConverter.ImportHarContent(content);
            Console.WriteLine("Total Response size: " + datLog.CumulatedResponseSize + " bytes (headers: "+datLog.CumulatedResponseHeaderSize+" ; bodies: "+datLog.CumulatedResponseBodySize+" )");
            Console.WriteLine("Total Request size: " + datLog.CumulatedRequestSize + " bytes (headers: " + datLog.CumulatedRequestHeaderSize + " ; bodies: " + datLog.CumulatedRequestBodySize + " )");
            Console.WriteLine("Found " + datLog.Entries.Count + " entries in log.");
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
            // Create log file
            string logFile = directory + "run.log";
            File.CreateText(logFile).Close();
            File.AppendAllText(logFile, "Starting to write files.");
            foreach (Entry entry in harLog.Entries)
            {
                Response resp = entry.Response;
                Request req = entry.Request;
                Console.WriteLine("\tProcessing " + req.Url);
                // If status code is < 400 it's 200 or 300, ie: not an error
                if (resp.Status < 400)
                {
                    if (resp.BodySize == 0)
                    {
                        Console.WriteLine("\t\tBody size is 0, file will be empty.\n");
                    }
                    // If the URL with the stripped protocol prefix is the same as the hostname, we know we don't have a file name
                    // so we append a index.html as *some* file name is required
                    string filePath;
                    string strippedSrotocolString = StripProtocolPrefix(req.Url);
                    if (req.GetHeaderValueByName("Host") == StripTrailingSlash(strippedSrotocolString))
                    {
                        filePath = directory + strippedSrotocolString + "\\" + "index.html";
                    }
                    else
                    {
                        filePath = directory + strippedSrotocolString;
                    }
                    
                    // Windows as a limitation of 248 on path name and 260 for FQP so we truncate at 248
                    if (filePath.Length >= 248)
                    {
                        File.AppendAllText(logFile, "File `" + filePath + "` was too long and was truncated to ");
                        filePath = filePath.Substring(0, 248);
                        File.AppendAllText(logFile, filePath + "\n");                        
                    }
                    
                    string directoryPath = Path.GetDirectoryName(filePath);
                    
                    // We make sure the file name doesn't contain special characters
                    string fileName = EscapeSpecialCharacters(Path.GetFileName(filePath));
                    filePath = directoryPath + "\\" + fileName;

                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }                    
                    File.WriteAllText(filePath, resp.Content.Text);
                }
            }
        }
        private static void WriteFile(string path, string content, string mimeType)
        {
            
        }
        private static string EscapeSpecialCharacters(string path)
        {
            string ret = Regex.Replace(path, "[?!\\/*<>|]", "_", RegexOptions.None);
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
