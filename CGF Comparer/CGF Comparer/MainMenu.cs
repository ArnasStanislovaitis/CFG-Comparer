using System;
using System.Collections.Generic;
using CGF_Comparer.Models;

namespace CGF_Comparer
{
    public class MainMenu
    {
        public void Menu()
        {            
            DataFolderUtility dataFolderUtility = new ();
            FilePathUtility filePathUtility = new ();
            FilterMenu filterMenu = new ();
            ReadCFG readCFG = new ();
            DataComparison dataComparison = new ();
            Output output = new ();
            InputValidator validator = new ();
            ResultsFilter resultsFilter = new ();
            Counter counter = new ();

            List<string> dataHeadings = new List<string>();
            List<ModelCFG> allComparedCfgData = new List<ModelCFG>();            

            var fileNames = dataFolderUtility.GetDataFileNames();

            if (fileNames[0] == string.Empty && fileNames[1] == string.Empty) 
            {
                Console.WriteLine("Data folder is empty");

                return;
            }

            var chosenFilePaths = filePathUtility.GetChosenPaths(fileNames);    
            var sourceFileCfgData = readCFG.ReadCFGFile(chosenFilePaths.Item1);
            var targetFileCfgData = readCFG.ReadCFGFile(chosenFilePaths.Item2);
            var sourceFileHeading = readCFG.GetFileInformation(sourceFileCfgData);
            var targetFileHeading = readCFG.GetFileInformation(targetFileCfgData);
            dataHeadings.AddRange(sourceFileHeading);
            dataHeadings.AddRange(targetFileHeading);
            var sourceCfgDataDictionary = readCFG.GetSourceFileValues(sourceFileCfgData);
            allComparedCfgData = dataComparison.GetComparedData(targetFileCfgData, sourceCfgDataDictionary);

            output.DisplayMenu();
            var choice = validator.ValidMenuChoice();   

            Console.Clear();  
            if(choice == 1)
            {
                
                filterMenu.DisplayFilterMenu(allComparedCfgData,dataHeadings);
                Console.ReadKey();
            }
            if(choice == 2)
            {
                //Console.Clear();
                output.PrintFilesHeadings(dataHeadings);                
                output.PrintAllCfgData(allComparedCfgData);
                counter.DisplayResultsCount(allComparedCfgData);
                Console.ReadKey();
            }     
            if (choice == 3) 
            {
                //Console.Clear();
                Console.WriteLine("Enter filter value");
                var filter = Console.ReadLine();
                var results = resultsFilter.FilterByID(allComparedCfgData,filter);
                output.PrintFilesHeadings(dataHeadings);
                output.PrintAllCfgData(results);
                Console.ReadKey();
            } 
        }
    }
}
