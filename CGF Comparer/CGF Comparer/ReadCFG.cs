using System;
using System.Collections.Generic;
using System.IO;

namespace CGF_Comparer
{
    public class ReadCFG
    {
        public string[] ReadCFGFile(string path)
        {
            try
            {
                using (TextReader textReader = File.OpenText(path))
                {
                    var allIdValuePairs = textReader.ReadToEnd().Split(";");

                    return allIdValuePairs;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the CFG file: {ex.Message}");

                return default;
            }
        }
        string[] GetFileInformation(string[] cfgData)
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

            for (int i = 6; i < cfgData.Length - 1; i++)
            {

                var a = cfgData[i].Split(":");
                keyValuePairs.Add(a[0], a[1]);
            }

            return keyValuePairs;
        }
    }
}