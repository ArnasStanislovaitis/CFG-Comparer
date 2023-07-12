using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Diagnostics;

namespace CGF_Comparer
{
    internal class Program
    {
        public class ConfigurationData
        {
            public ConfigurationData() { }
            public string ID { get; set; }
            public string SourceValue { get; set; } = string.Empty;
            public string TargetValue { get; set; } = string.Empty;
            public string Type { get; set; }
        }
        static void Main(string[] args)
        {            
            using var stream = new MemoryStream();
            string path = @"C:\Users\iot3\source\repos\CGF Comparer\CGF Comparer\Data\FMB001-default";
            string pathSecond = @"C:\Users\iot3\source\repos\CGF Comparer\CGF Comparer\Data\FMB920-default";
            // File names
            //string dataDirectory = @"C:\Users\iot3\source\repos\CGF Comparer\CGF Comparer\Data";
            string dataDirectory = @"C:\Users\Arnas\Documents\GitHub\CFG-Comparer\CGF Comparer\CGF Comparer\Data";
            var names = Directory.GetFiles(dataDirectory);

            int choice = 0;
            for (int i = 0; i < names.Length; i++) {
                //Console.WriteLine(Path.GetFileName(names[i]));                
            }
            // Menu
            /*
            Console.WriteLine("Choose a source file:");
            //var input = Console.ReadLine();
            PrintFileNames(names,choice);
            while (!int.TryParse(Console.ReadLine(), out choice) || choice > names.Length || choice < 1 )
            {
                Console.WriteLine($"Invalid input. Please enter an integer value between {1} and {names.Length} : ");
                PrintFileNames(names,choice);
            }

            Console.WriteLine( choice);

            void PrintFileNames(string[] names,int choice)
            { 
                for (int i = 0; i < names.Length; i++)
                {
                    if(choice - 1 == i) { continue; }
                    Console.WriteLine($"{i + 1}. {Path.GetFileName(names[i])}");
                }
            }
            
            string sourcePath = string.Empty;
            string targetPath = string.Empty;

            sourcePath = names[choice - 1];
            int previousChoice = 0;
            previousChoice = choice;
            choice = 0;

            Console.WriteLine( sourcePath);
            Console.WriteLine("Choose a target file");
            PrintFileNames(names, previousChoice);
            while (!int.TryParse(Console.ReadLine(), out choice) || choice > names.Length || choice < 1 || choice == previousChoice)
            {     
                  Console.WriteLine($"Invalid input. Please enter an integer value between {1} and {names.Length} : ");
                  PrintFileNames(names, previousChoice);
            }
            targetPath = names[choice - 1];
            Console.WriteLine( targetPath);
            */
            FilePicker fp = new FilePicker();
            var k = fp.ChosenPathGenerator(names,0);
            Console.WriteLine(k.Item1);
            Console.WriteLine(k.Item2);

            stream.Position = 0;
            int bufferSize = 512;
            byte[] decompressedBytes = new byte[bufferSize];
            // using var decompressor = new GZipStream(File.Open(path,FileMode.Open), CompressionMode.Decompress);
            //int length = decompressor.Read(decompressedBytes, 0, bufferSize);

            //decompressor.Close();
            //Console.WriteLine(length);

            int unchanged = 0;
            int modified = 0;
            int removed = 0;
            int added = 0;
            Dictionary<string,string> map = new Dictionary<string,string>();
            Dictionary<string, string> map2 = new Dictionary<string, string>();
            List<ConfigurationData> allData = new List<ConfigurationData>();
            //StreamReader sr = new StreamReader(stream);
            TextReader textReader = File.OpenText(k.Item1);
            TextReader textReader2 = File.OpenText(k.Item2);
            //sr.Close();
            //var a = sr.Read();
            var allText = textReader.ReadToEnd();
            var allText2 = textReader2.ReadToEnd();

            string[] first = allText.Split(";");
            string[] second = allText2.Split(";");
            
            
            
            foreach ( string line in first)
            {                               
                //Console.WriteLine( line);                
            }
            
            for (int i = 6; i < first.Length - 1 ; i++)
            {
                
                var a = first[i].Split(":");                
                map.Add(a[0], a[1]);  
            }

            int ad = 0;
            int un = 0;
            int mo = 0;
            int re = 0;

            for (int i = 6; i < second.Length - 1; i++)
            {

                var IdValuePair = second[i].Split(":");
                map2.Add(IdValuePair[0], IdValuePair[1]);
                if (map.ContainsKey(IdValuePair[0]) && map[IdValuePair[0]] == IdValuePair[1]) {
                    allData.Add(new ConfigurationData
                    {
                        ID = IdValuePair[0],
                        SourceValue = IdValuePair[1],
                        TargetValue = IdValuePair[1],
                        Type = "unchanged"
                    });
                    un++;
                }
                else if (map.ContainsKey(IdValuePair[0]) && map[IdValuePair[0]] != IdValuePair[1])
                {
                    allData.Add(new ConfigurationData
                    {
                        ID = IdValuePair[0],
                        SourceValue = map[IdValuePair[0]],
                        TargetValue = IdValuePair[1],
                        Type = "modified"

                    });
                    mo++;
                }
                else if (!map.ContainsKey(IdValuePair[0]))
                {
                    allData.Add(new ConfigurationData
                    {
                        ID = IdValuePair[0],
                        TargetValue = IdValuePair[1],
                        Type = "added"
                    });
                    ad++;
                }                
            }
            
            /*
             foreach(var data in allData)
             {
                 if (!map.ContainsKey(data.ID))
                 {
                     allData.Add(new ConfigurationData
                     {
                         ID = data.ID,
                         SourceValue = data.SourceValue,
                         Type = "removed"
                     });
                 }
             }*/
            //dfd
            foreach (var item in map)
            {
                if (!map2.ContainsKey(item.Key))
                {
                    Console.WriteLine($"Nera situ antrame, bet yra pirmame{item.Key} {item.Value}");
                    re++;
                }
            }
            Console.WriteLine(  $" Count yra {map2.Count}");
            var keysNotInTarget = map.Except(map2);//.Concat(map2.Except(map));

            foreach(var key in keysNotInTarget)
            {
                Console.WriteLine($"Nera antram {key.Key} {key.Value}");
                
            }
            //if(map.ContainsKey())
            var o = allData.Where(x => x.ID.StartsWith("40")).Select(x=>x);  //Filter by ID
            var e = allData.Where(x => x.Type == "added").ToArray();
            var y = allData.Where(x => x.Type == "added").ToArray();

            foreach (var key in o)
            {
                //Console.WriteLine($"Atfiltruoti {key.ID}");
            }
            foreach (var item in y)
            {
                //Console.WriteLine($"{item.ID} {item.SourceValue} {item.TargetValue} {item.Type}");
            }
            /*
            foreach (var item in map)
            {
                Console.WriteLine($"{item.Key} {item.Value}" );
            }*/

            Console.WriteLine(first[26]);
            var c = first[26].Split(":");
            if (c[1] == "")
            {
                Console.WriteLine( "yes");
            }
            //Console.WriteLine(a);

            Console.WriteLine($"added {ad} unchanged {un} modified {mo} removed {re}");
        }
    }
}
