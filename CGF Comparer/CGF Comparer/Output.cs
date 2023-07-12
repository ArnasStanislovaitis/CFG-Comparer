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
        public void PrintAllData(List<ModelCFG> data)
        {
            OutputHelper colour = new OutputHelper();

            foreach (var item in data)
            {
                if (item.Type == "unchanged") { colour.GrayText(); }
                else if (item.Type == "added") { colour.GreenText(); }
                else if (item.Type == "modified") { colour.YellowText(); }
                else if (item.Type == "removed") { colour.RedText(); }

                Console.WriteLine($"{item.ID} {item.SourceValue} {item.TargetValue} {item.Type}");

            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void PrintAllData(IEnumerable<ModelCFG> data)
        {
            OutputHelper colour = new OutputHelper();

            foreach (var item in data)
            {
                if (item.Type == "unchanged") { colour.GrayText(); }
                else if (item.Type == "added") { colour.GreenText(); }
                else if (item.Type == "modified") { colour.YellowText(); }
                else if (item.Type == "removed") { colour.RedText(); }

                Console.WriteLine($"{item.ID} {item.SourceValue} {item.TargetValue} {item.Type}");

            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}