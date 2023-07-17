using System;
using System.IO;

namespace CGF_Comparer
{
    public class DataFolderUtility
    {
        public string[] GetDataFileNames()
        {
            var directoryPath = Environment.CurrentDirectory;
            var projectFolderPath = new DirectoryInfo(directoryPath).Parent.Parent.Parent.ToString();
            var dataFolderPath = Path.Combine(projectFolderPath, "Data");
            var fileNames = Directory.GetFiles(dataFolderPath);

            return fileNames;
        }
    }
}