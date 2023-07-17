using System;
using System.Collections.Generic;
using System.IO;

namespace CGF_Comparer
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
        public void PrintAllCfgData(IEnumerable<ModelCFG> data)
        {
            OutputHelper colour = new OutputHelper();
            Console.WriteLine($"{"ID",-9}{"Source",-36}{"Target",-33}{"Result",10} ");
            foreach (var item in data)
            {
                if (item.Type == "unchanged") { colour.GrayText(); }
                else if (item.Type == "added") { colour.GreenText(); }
                else if (item.Type == "modified") { colour.YellowText(); }
                else if (item.Type == "removed") { colour.RedText(); }

                Console.WriteLine($"{item.ID,-8} {item.SourceValue,-35} {item.TargetValue,-35} {item.Type,10}");

            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void PrintFilesHeadings(List<string> data)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{data[i],-57} {data[i + 6]}");
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
        public void DisplayFilteredResults(List<ModelCFG> data, int choice)
        {
            Output output = new Output();
            ResultsFilter filter = new ResultsFilter();
            string[] filters = new string[4] { "unchanged", "removed", "added", "modified" };
            var filtered = filter.ComparisonResultFilter(data, filters[choice - 1]);            
            output.PrintAllCfgData(filtered);
        } 
        public void DisplayMenu()
        {
            Console.Clear();
            string[] menuChoices = new string[3] { "1. Enter result filter menu ", "2. Display all data", "3. Filter by Id" };
            foreach (var item in menuChoices)
            {
                Console.WriteLine(item);
            }
        }
    }
}