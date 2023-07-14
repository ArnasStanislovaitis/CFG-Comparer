using System;

namespace CGF_Comparer
{
    public class OutputHelper
    {
        public void GrayText()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void YellowText()
        {
           Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public void RedText()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void GreenText()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void BlueText()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}