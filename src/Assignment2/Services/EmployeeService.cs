using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Models.EmployeeHierarchy;

namespace Assignment2.Services
{
    /// <summary>
    /// This class is the Shape Service that creates Employees
    /// </summary>
    internal class EmployeeService
    {
        /// <summary>
        /// This methos creates a Developer
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="salary">Salary</param>
        /// <returns>Developer object</returns>
        public Developer CreateDeveloper(string name, decimal salary)
        {
            return new Developer()
            {
                Name = name,
                Salary = salary,
            };
        }

        /// <summary>
        /// This methos creates a manager
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="salary">Salary</param>
        /// <returns>Manager object</returns>
        public Manager CreateManager(string name, decimal salary)
        {
            return new Manager()
            {
                Name = name,
                Salary = salary,
            };
        }
    }
}
