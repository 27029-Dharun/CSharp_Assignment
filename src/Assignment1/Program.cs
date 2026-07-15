using System;
using System.Collections.Generic;
using Assignment1.Services;
using Assignment1.Ui;
using Assignments1;

namespace Assignment1
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Contact Manager Application");
            MenuOption menu = new MenuOption();
            menu.DisplayMenu();
            Console.WriteLine("Exited ...");
            Console.ReadKey();
        }
    }
}
