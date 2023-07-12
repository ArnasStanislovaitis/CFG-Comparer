using System;
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
    }
}