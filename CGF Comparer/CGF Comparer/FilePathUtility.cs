using System;

namespace CFG_Comparer
{
    public class FilePathUtility
    {       
        private string _sourcePath = string.Empty;
        private string _targetPath = string.Empty;
        public (string,string) GetChosenPaths (string[] fileNames)
        {
            InputValidator inputValidator = new();
            int choice = 0; 
            
            if(fileNames == null || fileNames.Length <= 0)
            {
                Console.WriteLine("Data folder is empty");

                return default;
            }
            choice = inputValidator.ValidPathChoice(fileNames, choice);                       
            _sourcePath = fileNames[choice - 1];
            choice = inputValidator.ValidPathChoice(fileNames, choice);                
            _targetPath = fileNames[choice - 1];            
            
            return (_sourcePath, _targetPath);
        }                
    }        
}