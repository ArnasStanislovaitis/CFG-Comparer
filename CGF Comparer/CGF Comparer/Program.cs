using System;

namespace CGF_Comparer
{
    internal class Program
    {       
        static void Main(string[] args)
        {     
            /*
            MainMenu mainMenu = new MainMenu();
            while (true)
            {
                mainMenu.Menu();
            }*/
            DataFolderUtility dataFolderUtility = new DataFolderUtility();
            var fileNames = dataFolderUtility.GetDataFileNames();
            ReadCFG readCFG = new ReadCFG();
            FilePathUtility filePathUtility = new FilePathUtility();

            var chosenFilePaths = filePathUtility.GetChosenPaths(fileNames);
            var sourceFileCfgData = readCFG.ReadCFGFile(chosenFilePaths.Item1);
            
            var o = readCFG.GetSourceFileValuestest(sourceFileCfgData);
            foreach ( var c in o.files ) {
                Console.WriteLine( c);
            }
        }
    }    
}