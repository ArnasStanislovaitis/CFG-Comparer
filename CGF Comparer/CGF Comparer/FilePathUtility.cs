using System;

namespace CGF_Comparer
{
    public class FilePathUtility
    {       
        string sourcePath = string.Empty;
        string targetPath = string.Empty;
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
            sourcePath = fileNames[choice - 1];
            choice = inputValidator.ValidPathChoice(fileNames, choice);                
            targetPath = fileNames[choice - 1];            
            
            return (sourcePath, targetPath);
        }                
    }        
}