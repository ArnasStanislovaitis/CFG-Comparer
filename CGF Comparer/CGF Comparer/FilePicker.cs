
using System.IO;
using System;

namespace CGF_Comparer
{
    public class FilePicker
    {
        Output output = new();
        string sourcePath = string.Empty;
        string targetPath = string.Empty;
        public (string,string) ChosenPathGenerator (string[] fileNames,int choice)
        {
            
            Console.WriteLine("Choose a source file:");            
            output.PrintFileNames(fileNames, choice);
            while (!int.TryParse(Console.ReadLine(), out choice) || choice > fileNames.Length || choice < 1 || choice == choice)
            {
                Console.WriteLine($"Invalid input. Please enter an integer value between {1} and {fileNames.Length} : ");
                output.PrintFileNames(fileNames, choice);
            }
            sourcePath = fileNames[choice - 1];



            int previousChoice = choice;
            
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
        
    }
}
