using System;
using System.IO;

namespace CFG_Comparer
{
    public class DataFolderUtility
    {
        public string[] GetDataFileNames()
        {
            var directoryPath = AppDomain.CurrentDomain.BaseDirectory;            
            var dataFolderPath = Path.Combine(directoryPath, "Data");
            var fileNames = Directory.GetFiles(dataFolderPath);

            return fileNames;
        }
    }
}