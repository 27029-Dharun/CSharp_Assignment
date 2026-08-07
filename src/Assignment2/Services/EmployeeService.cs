using Assignment2.Models.EmployeeHierarchy;

namespace Assignment2.Services
{
    /// <summary>
    /// Coordinates the business logic for shape
    /// </summary>
    internal class EmployeeService
    {
        /// <summary>
        /// creates a new developer
        /// </summary>
        /// <param name="name"> Name of the developer. </param>
        /// <param name="salary"> Salary of the developer. </param>
        /// <returns> A instance of the developer created. </returns>
        public Developer? CreateDeveloper(string name, decimal salary)
        {
            if (name == string.Empty || salary <= 0)
            {
                return null;
            }

            return new Developer()
            {
                Name = name,
                Salary = salary,
            };
        }

        /// <summary>
        /// Creates a new manager
        /// </summary>
        /// <param name="name"> Name of the manager. </param>
        /// <param name="salary"> Salary of the manager. </param>
        /// <returns> A instance of the manager created. </returns>
        public Manager? CreateManager(string name, decimal salary)
        {
            if (name == string.Empty || salary <= 0)
            {
                return null;
            }

            return new Manager()
            {
                Name = name,
                Salary = salary,
            };
        }

        /// <summary>
        /// Gets the employee details.
        /// </summary>
        /// <param name="employee"> Instance of the employee. </param>
        /// <returns> A string with employee name, role and bonus. </returns>
        internal string GetDetails(Employee employee)
        {
            if (employee is Manager manager)
            {
                return manager.PrintDetails();
            }

            // Every employees other than manager is a circle
            Developer developer = (Developer)employee;
            return developer.PrintDetails();
        }
    }
}
