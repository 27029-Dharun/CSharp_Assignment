using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Models.EmployeeHierarchy;
using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// This is the Employee Role enum
    /// </summary>
    internal enum EmployeeRole
    {
        /// <summary>
        /// Developer
        /// </summary>
        Developer = 1,

        /// <summary>
        /// Manager
        /// </summary>
        Manager = 2,
    }

    /// <summary>
    /// THis is the Employee Controller
    /// </summary>
    internal class EmployeeController
    {
        private EmployeeView _employeeView = new ();
        private EmployeeService _employeeService = new EmployeeService();

        /// <summary>
        /// This is the Entry point of the Employee Task
        /// </summary>
        public void Run()
        {
            int option = this._employeeView.GetEmployeeType();
            switch (option)
            {
                case (int)EmployeeRole.Developer:
                    this._employeeView.GetEmployee(out string developerName, out decimal developerSalary);
                    Developer developer = this._employeeService.CreateDeveloper(developerName, developerSalary);
                    this._employeeView.Print(developer);
                    break;

                case (int)EmployeeRole.Manager:
                    this._employeeView.GetEmployee(out string name, out decimal salary);
                    Manager manager = this._employeeService.CreateManager(name, salary);
                    this._employeeView.Print(manager);
                    break;
            }
        }
    }
}
