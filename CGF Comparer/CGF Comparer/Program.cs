using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

                     
            /*
            Dictionary<string,string> map = new Dictionary<string,string>();
            Dictionary<string, string> map2 = new Dictionary<string, string>();
            List<ModelCFG> allData = new List<ModelCFG>();
            //StreamReader sr = new StreamReader(stream);
            TextReader textReader = File.OpenText(paths.Item1);
            TextReader textReader2 = File.OpenText(paths.Item2);
            //sr.Close();
            //var a = sr.Read();
            var allText = textReader.ReadToEnd();
            var allText2 = textReader2.ReadToEnd();

            string[] first = allText.Split(";");
            string[] second = allText2.Split(";");
            */
            
           
                        
            ReadCFG readCFG = new ReadCFG();
            var src = readCFG.ReadCFGFile(paths.Item1);
            var tar = readCFG.ReadCFGFile(paths.Item2);
            
            var sourced = readCFG.GetSourceFileValues(src);
            DataComparison dc = new();
            
           

            var all = dc.GetComparedData(tar, sourced);


            Output ou = new();
            HashSet<string> choices = new();
            string input = string.Empty;
            while(input != "6")
            {
                Console.WriteLine("1. Unchanged");
                Console.WriteLine("2. Removed");
                Console.WriteLine("3. Added");
                Console.WriteLine("4. Modified");
                Console.WriteLine("5. Print with filters");
                Console.WriteLine("6. Back");
                input = Console.ReadLine();
                Console.Clear();
                if (input == "5")
                {
                    foreach (var item in choices)
                    {
                        DisplayFiltered(all, item);
                    }
                }
                else if (choices.Contains(input))
                {
                    choices.Remove(input);
                }
                else if (!choices.Contains(input))
                {
                    choices.Add(input);
                }
                else
                {
                    Console.WriteLine("Wrong choice");
                }
                
            }
            void DisplayFiltered(List<ModelCFG> data, string choice)
            {
                if(choice == "1") {
                    var filtered = UnchangedFilter(data);
                    ou.PrintAllData(filtered);
                }
                else if(choice == "2")
                {
                    var filtered = RemovedFilter(data);
                    ou.PrintAllData(filtered);
                }
                else if(choice == "3")
                {
                    var filtered = AddedFilter(data);
                    ou.PrintAllData(filtered);
                }
                else if(choice == "4")
                {
                    var filtered = ModifiedFilter(data);
                    ou.PrintAllData(filtered);
                }
                
            }
            IEnumerable<ModelCFG> UnchangedFilter(List<ModelCFG> data)
            {
                var unchangedCount = data.Where(x => x.Type == "unchanged");

                return unchangedCount;
            }
            IEnumerable<ModelCFG> AddedFilter(List<ModelCFG> data)
            {
                var addedCount = data.Where(x => x.Type == "added");

                return addedCount;
            }
            IEnumerable<ModelCFG> ModifiedFilter(List<ModelCFG> data)
            {
                var modifiedCount = data.Where(x => x.Type == "modified");

                return modifiedCount;
            }
            IEnumerable<ModelCFG> RemovedFilter(List<ModelCFG> data)
            {
                var removedCount = data.Where(x => x.Type == "removed");

                return removedCount;
            }
                        


            ou.PrintAllData(all);
                   

          
            
            IEnumerable<ModelCFG> FilterByID(List<ModelCFG> data,string id)
            {
                 var filteredById = data.Where(x => x.ID.StartsWith(id)).Select(x=>x);

                return filteredById;
            }


            Counter counter = new Counter();
            counter.DisplayResultsCount(all);
            //2323 15 1 53
        }
    }
}
