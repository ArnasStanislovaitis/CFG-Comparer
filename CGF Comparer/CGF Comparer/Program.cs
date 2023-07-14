using System;
using System.IO;

namespace CGF_Comparer
{
    internal class Program
    {
       
        static void Main(string[] args)
        {            
            using var stream = new MemoryStream();

            // File names
            string dataDirectory = @"C:\Users\iot3\source\repos\CGF Comparer\CGF Comparer\Data";
            //string dataDirectory = @"C:\Users\Arnas\Documents\GitHub\CFG-Comparer\CGF Comparer\CGF Comparer\Data";
            var names = Directory.GetFiles(dataDirectory);

            
            FilePathUtility fp = new FilePathUtility();
            var paths = fp.ChosenPathGenerator(names);
            Console.WriteLine(paths.Item1);
            Console.WriteLine(paths.Item2);            
            
           
                        
            ReadCFG readCFG = new ReadCFG();
            var src = readCFG.ReadCFGFile(paths.Item1);
            var tar = readCFG.ReadCFGFile(paths.Item2);
            
            var sourced = readCFG.GetSourceFileValues(src);
            DataComparison dc = new();
            
           

            var all = dc.GetComparedData(tar, sourced);


            FilterMenu filterMenu = new();
            filterMenu.DisplayFilterMenu(all);
            
                   

          
            


            Counter counter = new Counter();
            counter.DisplayResultsCount(all);
            //2323 15 1 53
        }
    }
}
