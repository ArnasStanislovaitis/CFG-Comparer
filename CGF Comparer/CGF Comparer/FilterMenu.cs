﻿using System;
using System.Collections.Generic;

namespace CGF_Comparer
{
    public class FilterMenu
    {
        public void DisplayFilterMenu(List<ModelCFG> cfgData)
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