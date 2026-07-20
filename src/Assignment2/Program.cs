using Assignment2.EmployeeHierarchy;
using Assignment2.ShapeHierarchy;

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
            Console.WriteLine("Hello, World!");
            Rectangle rectangle = new (10, 20, "Red");
            Console.WriteLine(rectangle.PrintDetails());
            Circle circle = new (10, "green");
            Console.WriteLine(circle.PrintDetails());
            Console.ReadLine();

            Developer developer = new Developer();

        }
    }
}