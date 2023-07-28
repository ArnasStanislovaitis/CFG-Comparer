using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace CGF_Comparer
{
    public class ReadCFG
    {
        public string[] ReadCFGFile(string path)
        {
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Open))
                {                    
                    using (var gzipStream = new GZipStream(fileStream, CompressionMode.Decompress))
                    {
                        using (var streamReader = new StreamReader(gzipStream))
                        {
                            var allIdValuePairs = streamReader.ReadToEnd().Split(";");

                            return allIdValuePairs;
                        }
                    }                              
                }
            }           
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the CFG file: {ex.Message}");

                return Array.Empty<string>();
            }
        }
        public string[] GetFileInformation(string[] cfgData)
        {
            string[] fileInformation = new string[6];

            for (int i = 0; i < 5; i++)
            {
                fileInformation[i] = cfgData[i];
            }

            return fileInformation;
        }
        public Dictionary<string,string> GetSourceFileValues(string[] cfgData)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            birb bi = new birb();
            

            for (int i = 6; i < cfgData.Length - 1; i++)
            {
                
                var a = cfgData[i].Split(":");
                if(double.TryParse(a[0],out double o))
                {
                    bi.files.Add(a[i]);
                }


                keyValuePairs.Add(a[0], a[1]);
            }

            return keyValuePairs;
        }
        public birb GetSourceFileValuestest(string[] cfgData)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            birb bi = new birb();


            for (int i = 0; i < cfgData.Length - 1; i++)
            {

                var a = cfgData[i].Split(":");
                if (!int.TryParse(a[0], out int o))
                {
                    bi.files.Add(cfgData[i]);
                }


                keyValuePairs.Add(a[0], a[1]);
            }

            return bi;
        }
    }
    public class birb
    {
       public List<string> files = new List<string>();
    }
}