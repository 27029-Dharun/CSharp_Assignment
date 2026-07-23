using Assignment2.Models.EmployeeHierarchy;

namespace Assignment2.Views
{
    /// <summary>
    /// THis is the Emplyee View
    /// </summary>
    internal class EmployeeView
    {
        /// <summary>
        /// This returns the Employee Type that is to be created
        /// </summary>
        /// <returns>Int value 1 - Developer 2 - Manager </returns>
        public int GetEmployeeType()
        {
            int input;
            Console.WriteLine();
            Console.WriteLine("Enter the number to Create a Shape");
            Console.WriteLine("1. Employee");
            Console.WriteLine("2. Developer");
            Console.WriteLine("3. Exit");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Enter a Valid Input");
            }

            return input;
        }

        /// <summary>
        /// This methods gets the data of the employee
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="salary">Salary</param>
        public void GetEmployee(out string name, out decimal salary)
        {
            Console.WriteLine("Enter the Name of the Employee");
            name = (Console.ReadLine() ?? string.Empty).Trim();
            while (name == string.Empty)
            {
                Console.WriteLine("Color can't be Empty");
                name = (Console.ReadLine() ?? string.Empty).Trim();
            }

            Console.WriteLine("Enter the Salary of the Employee");
            while (!decimal.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Enter a Valid Input");
            }
        }

        /// <summary>
        /// This prints the Details of the Employee
        /// </summary>
        /// <param name="employee">The employee object</param>
        public void Print(Employee employee)
        {
            Console.WriteLine(employee.PrintDetails());
        }
    }
}
