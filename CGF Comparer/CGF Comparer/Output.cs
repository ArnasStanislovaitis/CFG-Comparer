using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ComparerLibrary;

namespace CFG_Comparer
{
    public class Output
    {
        public void PrintFileNames(string[] names, int choice)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (choice - 1 == i) { continue; }
                Console.WriteLine($"{i + 1}. {Path.GetFileName(names[i])}");
            }
        }
        public void PrintAllCfgData(IEnumerable<DataComparisonItem> data)
        {
            if (!data.Any()) { return; }

            OutputHelper colour = new OutputHelper();            
            var maxIdLength = data.Max(x => x.ID.Length);
            var maxSourceLength = data.Max(x => x.SourceValue.Length);
            var maxTargetLength = data.Max(x => x.TargetValue.Length);            
            Console.WriteLine($"{"ID".PadRight(maxIdLength)} {"Source".PadRight(maxSourceLength)} {"Target".PadRight(maxTargetLength)} {"Result"} ");

            foreach (var item in data)
            {
                if (item.Type == ResultsType.Unchanged) { colour.GrayText(); }
                else if (item.Type == ResultsType.Added) { colour.GreenText(); }
                else if (item.Type == ResultsType.Modified) { colour.YellowText(); }
                else if (item.Type == ResultsType.Removed) { colour.RedText(); }
                
                Console.WriteLine($"{item.ID.PadRight(maxIdLength)} {item.SourceValue.PadRight(maxSourceLength)} {item.TargetValue.PadRight(maxTargetLength)} {item.Type}");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void PrintFilesHeadings(CfgModel data)
        {
            var maxSourceLength = data.SourceMetaInfo.Max(x => x.Value.Length);
            var maxTargetLength = data.SourceMetaInfo.Max(x => x.Value.Length);
            Console.WriteLine("Source information:");

            for (int i = 0; i < data.SourceMetaInfo.Count; i++)
            {
                Console.WriteLine($"{data.SourceMetaInfo[i].ID.PadRight(maxSourceLength)} {data.SourceMetaInfo[i].Value}");
            }
            Console.WriteLine();
            Console.WriteLine("Target information:");

            for (int o = 0; o < data.TargetMetaInfo.Count; o++)
            {
                Console.WriteLine($"{data.TargetMetaInfo[o].ID.PadRight(maxTargetLength)} {data.TargetMetaInfo[o].Value}");
            }
            Console.WriteLine();

        }        
        public void DisplayFilterChoices(HashSet<int> set)
        {
            OutputHelper output = new OutputHelper();
            string[] filterChoices = new string[6] { "1. Unchanged", "2. Removed", "3. Added", "4. Modified", "5. Print with filters", "6. Back" };

            for (int i = 0; i < filterChoices.Length; i++)
            {
                if (set.Contains(i + 1))
                {
                    output.BlueText();
                    Console.WriteLine(filterChoices[i]);
                    output.GrayText();
                }
                else
                {
                    Console.WriteLine(filterChoices[i]);
                }
            }
        }
        public void DisplayFilteredResults(List<DataComparisonItem> data, int choice)
        {
            Output output = new Output();
            ResultsFilter filter = new ResultsFilter();
            ResultsType[] filters = new[] { ResultsType.Unchanged, ResultsType.Removed, ResultsType.Added, ResultsType.Modified };
            var filtered = filter.ComparisonResultFilter(data, filters[choice - 1]); 
            if(filtered == null) { return; }            
            output.PrintAllCfgData(filtered);
        } 
        public void DisplayMenu()
        {
            Console.Clear();
            string[] menuChoices = new string[4] { "1. Enter result filter menu ", "2. Display all data", "3. Filter by Id","4. Exit" };
            foreach (var item in menuChoices)
            {
                Console.WriteLine(item);
            }
        }
    }
}