using System;
using System.IO;
using System.IO.Compression;

namespace CFG_Comparer
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
    }
}