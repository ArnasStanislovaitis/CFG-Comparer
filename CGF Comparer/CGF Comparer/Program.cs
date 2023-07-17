using System;

namespace CGF_Comparer
{
    internal class Program
    {       
        static void Main(string[] args)
        {     
            MainMenu mainMenu = new MainMenu();
            while (true)
            {
                mainMenu.Menu();
            }            
        }
    }    
}