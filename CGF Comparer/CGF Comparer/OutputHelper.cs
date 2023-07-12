using System;

namespace CGF_Comparer
{
    public class OutputHelper
    {
        public void GrayText()
        {
            var previousColour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void YellowText()
        {
            var previousColour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public void RedText()
        {
            var previousColour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void GreenText()
        {
            var previousColour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}