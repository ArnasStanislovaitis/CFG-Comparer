using System;
using System.Collections.Generic;

namespace CFG_Comparer
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
        public int ValidPathChoice(string[] fileNames, int previousChoice) {
            
            Output output = new();
            int choice;
            Console.Clear();
            output.PrintFileNames(fileNames, previousChoice);

            while (!int.TryParse(Console.ReadLine(), out choice) || choice > 3 || choice < 1 ||  choice == previousChoice)
            {
                Console.Clear();
                output.PrintFileNames(fileNames, previousChoice);
                Console.WriteLine($"Invalid input. Please enter a number from menu: ");                
            }
            
            return choice;
        }
        public int ValidMenuChoice()
        {
            Output output = new();
            int choice;            
            while (!int.TryParse(Console.ReadLine(), out choice) || choice > 4 || choice < 1)
            {
                Console.Clear();
                Console.WriteLine($"Invalid input. Please enter a number from menu: ");
                output.DisplayMenu();
                
            }

            return choice;
        }
    }
}