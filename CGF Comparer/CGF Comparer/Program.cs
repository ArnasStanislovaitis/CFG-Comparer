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
            //string dataDirectory = @"C:\Users\iot3\source\repos\CGF Comparer\CGF Comparer\Data";
            string dataDirectory = @"C:\Users\Arnas\Documents\GitHub\CFG-Comparer\CGF Comparer\CGF Comparer\Data";
            var names = Directory.GetFiles(dataDirectory);

            
            FilePathUtility fp = new FilePathUtility();
            var k = fp.ChosenPathGenerator(names);
            Console.WriteLine(k.Item1);
            Console.WriteLine(k.Item2);

            stream.Position = 0;
            int bufferSize = 512;
            byte[] decompressedBytes = new byte[bufferSize];
            // using var decompressor = new GZipStream(File.Open(path,FileMode.Open), CompressionMode.Decompress);
            //int length = decompressor.Read(decompressedBytes, 0, bufferSize);

            //decompressor.Close();            
            
            Dictionary<string,string> map = new Dictionary<string,string>();
            Dictionary<string, string> map2 = new Dictionary<string, string>();
            List<ModelCFG> allData = new List<ModelCFG>();
            //StreamReader sr = new StreamReader(stream);
            TextReader textReader = File.OpenText(k.Item1);
            TextReader textReader2 = File.OpenText(k.Item2);
            //sr.Close();
            //var a = sr.Read();
            var allText = textReader.ReadToEnd();
            var allText2 = textReader2.ReadToEnd();

            string[] first = allText.Split(";");
            string[] second = allText2.Split(";");
                       
            
           
                        
            ReadCFG readCFG = new ReadCFG();
            var src = readCFG.ReadCFGFile(k.Item1);
            var tar = readCFG.ReadCFGFile(k.Item2);
            
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
                        FilterCall(all, item);
                    }
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
            void FilterCall(List<ModelCFG> data, string choice)
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
                        


            foreach (var item in all)
            {
                //Console.WriteLine($"{item.ID} {item.SourceValue} {item.TargetValue} {item.Type}");
                
            }
            

            foreach (var item in map)
            {
                if (!map2.ContainsKey(item.Key))
                {
                    //Console.WriteLine($"Nera situ antrame, bet yra pirmame{item.Key} {item.Value}");
                    
                }
            }
            Console.WriteLine(  $" Count yra {map2.Count}");
            var keysNotInTarget = map.Except(map2);//.Concat(map2.Except(map));

            foreach(var key in keysNotInTarget)
            {
                //Console.WriteLine($"Nera antram {key.Key} {key.Value}");
                
            }
            //if(map.ContainsKey())
            var o = allData.Where(x => x.ID.StartsWith("4045951")).Select(x=>x);  //Filter by ID
            var e = allData.Where(x => x.Type == "added").ToArray();
            var y = all.Where(x => x.Type == "removed").Count();
            Console.WriteLine(y);
            foreach (var key in o)
            {
                //Console.WriteLine($"Atfiltruoti {key.ID}");
            }
            foreach (var item in o)
            {
                Console.WriteLine($"{item.ID} {item.SourceValue} {item.TargetValue} {item.Type}");
            }

            Console.WriteLine();        
            
        }
    }
}
