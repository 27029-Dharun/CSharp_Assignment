using Assignment2.Controllers;

namespace Assignment2
{
    /// <summary>
    /// This class is Main Entry point of our program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This method is the main method of Assignment 2
        /// </summary>
        public static void Main()
        {
            MainController controller = new MainController();
            controller.Run();
            Console.WriteLine("Enter a Key to Exit");
            Console.ReadKey();
        }
    }
}