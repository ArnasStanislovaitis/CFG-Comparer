using System;
using System.Collections.Generic;
using CGF_Comparer.Models;

namespace CGF_Comparer
{
    public class FilterMenu
    {
        public void DisplayFilterMenu(List<DataComparisonItem> cfgData,List<string> dataHeadings)
        {
            Output output = new();
            InputValidator validator = new();            
            HashSet<int> choices = new();
            int choice = 0;

            while(choice != 6)
            {
                output.DisplayFilterChoices(choices);
                choice = validator.ValidFilterChoice(choices);
                Console.Clear();

                if (choice == 5)
                {
                    output.PrintFilesHeadings(dataHeadings);

                    foreach (var item in choices)
                    {
                       output.DisplayFilteredResults(cfgData, item);
                    }
                }

                else if (choices.Contains(choice))
                {
                    choices.Remove(choice);
                }

                else if (!choices.Contains(choice))
                {
                    choices.Add(choice);
                }
            }
        }
    }
}