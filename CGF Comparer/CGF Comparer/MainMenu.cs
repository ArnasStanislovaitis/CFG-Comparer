using System;
using CGF_Comparer.Models;

namespace CGF_Comparer
{
    public class MainMenu
    {
        public void Menu()
        {           
            
            FilterMenu filterMenu = new();
            ResultsFilter resultsFilter = new();
            
            DataFolderUtility dataFolderUtility = new();
            var fileNames = dataFolderUtility.GetDataFileNames();

            if (fileNames[0] == string.Empty && fileNames[1] == string.Empty)
            {
                Console.WriteLine("Data folder is empty");
                return;
            }

            FilePathUtility filePathUtility = new();
            var chosenFilePaths = filePathUtility.GetChosenPaths(fileNames);
            ReadCFG readCFG = new();
            var sourceCfgFile = readCFG.ReadCFGFile(chosenFilePaths.Item1);
            var targetCfgFile = readCFG.ReadCFGFile(chosenFilePaths.Item2);
            CfgModel allData = new();
            DataComparison dataComparison = new();
            allData = dataComparison.GetComparedData(sourceCfgFile, targetCfgFile);            

            bool exitRequested = false;

            while (!exitRequested)
            {
                Output output = new();
                output.DisplayMenu();
                InputValidator validator = new();
                var choice = validator.ValidMenuChoice();

                Console.Clear();
                
                switch (choice)
                {
                    case 1:
                        
                        filterMenu.DisplayFilterMenu(allData);
                        break;

                    case 2:
                        output.PrintFilesHeadings(allData);
                        output.PrintAllCfgData(allData.ComparedData);
                        Counter counter = new();
                        counter.DisplayResultsCount(allData.ComparedData);
                        break;

                    case 3:
                        Console.WriteLine("Enter filter value");
                        var filter = Console.ReadLine();
                        var results = resultsFilter.FilterByID(allData.ComparedData, filter);
                        output.PrintFilesHeadings(allData);
                        output.PrintAllCfgData(results);
                        break;

                    case 4: 
                        exitRequested = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                if (!exitRequested)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        /*
        public void Menu()
        {            
            
            
            FilterMenu filterMenu = new ();
            
            DataComparison dataComparison = new ();
            
            InputValidator validator = new ();
            ResultsFilter resultsFilter = new ();
            Counter counter = new ();
                                  
            DataFolderUtility dataFolderUtility = new ();
            var fileNames = dataFolderUtility.GetDataFileNames();

            if (fileNames[0] == string.Empty && fileNames[1] == string.Empty) 
            {
                Console.WriteLine("Data folder is empty");

                return;
            }
            FilePathUtility filePathUtility = new ();
            var chosenFilePaths = filePathUtility.GetChosenPaths(fileNames);
            ReadCFG readCFG = new ();
            var sourceCfgFile = readCFG.ReadCFGFile(chosenFilePaths.Item1);            
            var targetCfgFile = readCFG.ReadCFGFile(chosenFilePaths.Item2);            
            CfgModel allData = new (); 
            allData = dataComparison.GetComparedData(sourceCfgFile, targetCfgFile);
            Console.WriteLine(allData.SourceMetaInfo.Count);
            foreach (var item in allData.TargetMetaInfo)
            {
                Console.WriteLine(item.ID);
            }
            Output output = new ();
            output.DisplayMenu();
            var choice = validator.ValidMenuChoice();   

            Console.Clear();  
            if(choice == 1)
            {                
                filterMenu.DisplayFilterMenu(allData);
                Console.ReadKey();
            }
            if(choice == 2)
            {
                //Console.Clear();
                output.PrintFilesHeadings(allData);                
                output.PrintAllCfgData(allData.ComparedData);
                counter.DisplayResultsCount(allData.ComparedData);
                Console.ReadKey();
            }     
            if (choice == 3) 
            {
                //Console.Clear();
                Console.WriteLine("Enter filter value");
                var filter = Console.ReadLine();
                var results = resultsFilter.FilterByID(allData.ComparedData,filter);
                output.PrintFilesHeadings(allData);
                output.PrintAllCfgData(results);
                Console.ReadKey();
            } 
        }*/
    }
}
