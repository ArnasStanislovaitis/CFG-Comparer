using System;
using System.Collections.Generic;

namespace CGF_Comparer
{
    public class InputValidator
    {
        public int ValidFilterChoice(HashSet<int> chosen)
        {
            Output output = new();
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || choice > 6 || choice < 1)
            {
                Console.Clear();
                Console.WriteLine($"Invalid input. Please enter a number between 1 and 6 : ");
                output.DisplayFilterChoices(chosen);
            }

            return choice;
        }
    }
}