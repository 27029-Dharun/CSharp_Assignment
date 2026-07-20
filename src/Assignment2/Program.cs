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
            int task;
            Console.WriteLine("Enter the task to Perform: ");
            Console.WriteLine("1. Shape Hierarchy");
            Console.WriteLine("2. Employee Hierarchy");
            Console.WriteLine("3. Banking System");

            while (!int.TryParse(Console.ReadLine(), out task))
            {
                Console.WriteLine("Enter the task to Perform: ");
            }

            switch (task)
            {
                case 1:

                    Rectangle rectangle = new(10, 20, "Red");
                    Console.WriteLine(rectangle.PrintDetails());

                    Circle circle = new(10, "green");
                    Console.WriteLine(circle.PrintDetails());
                    break;

                case 2:

                    Developer developer = new Developer("Dharun", 100000);
                    Console.WriteLine(developer.PrintDetails());

                    Manager manager = new Manager("Ram", 300000);
                    Console.WriteLine(manager.PrintDetails());
                    break;

                case 3:
                    break;

                default:
                    Console.WriteLine("Not a valid Input");
                    break;
            }

            Console.ReadLine();
        }
    }
}