using System;
using System.IO;

namespace CGF_Comparer
{
    public class FilePathUtility
    {
        Output output = new();
        string sourcePath = string.Empty;
        string targetPath = string.Empty;
        public (string,string) ChosenPathGenerator (string[] fileNames)
        {
            
            int choice = 0;
            int previousChoice = -1;
            
            Console.WriteLine("Choose a source file:");
            output.PrintFileNames(fileNames, choice);
            while (!int.TryParse(Console.ReadLine(), out choice) || choice > fileNames.Length || choice < 1 || choice == previousChoice)
            {
                Console.WriteLine($"Invalid input. Please enter an integer value between {1} and {fileNames.Length} : ");
                output.PrintFileNames(fileNames, choice);
            }
            sourcePath = fileNames[choice - 1];
                
                
            

            previousChoice = choice;

            Console.WriteLine("Choose a target file");
            output.PrintFileNames(fileNames, choice);
            while (!int.TryParse(Console.ReadLine(), out choice) || choice > fileNames.Length || choice < 1 || choice == previousChoice)
            {
                Console.WriteLine($"Invalid input. Please enter an integer value between {1} and {fileNames.Length} : ");
                output.PrintFileNames(fileNames, previousChoice);
            }
            targetPath = fileNames[choice - 1];
            
            
            return (sourcePath, targetPath);
        }
        public string ChosenFilePath(string[] fileNames, int choice)
        {
            Console.WriteLine("Choose a target file");
            output.PrintFileNames(fileNames, choice);
            while (!int.TryParse(Console.ReadLine(), out choice) || choice > fileNames.Length || choice < 1)
            {
                Console.WriteLine($"Invalid input. Please enter an integer value between {1} and {fileNames.Length} : ");                
            }
            string path = fileNames[choice - 1];

            return path;
        }
        public string[] GetDataFileNames()
        {
            string dataDirectory = @"C:\Users\iot3\source\repos\CGF Comparer\CGF Comparer\Data";            
            var fileNames = Directory.GetFiles(dataDirectory);

            return fileNames;
        }
    }
        
}