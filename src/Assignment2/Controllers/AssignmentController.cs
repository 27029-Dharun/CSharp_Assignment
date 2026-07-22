using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// This enum represents all the Task as enum
    /// </summary>
    internal enum ChooseTask
    {
        /// <summary>
        /// Shape
        /// </summary>
        Shape = 1,

        /// <summary>
        /// Employee
        /// </summary>
        Employee = 2,

        /// <summary>
        /// Bank
        /// </summary>
        Bank = 3,

        /// <summary>
        /// Exit
        /// </summary>
        Exit = 4,
    }

    /// <summary>
    /// THis is the assignment Controller
    /// </summary>
    internal class AssignmentController
    {
        private ConsoleView _view = new ();

        /// <summary>
        /// This method is the entery point
        /// </summary>
        public void Run()
        {
            int input;
            do
            {
                input = this._view.GetTask();
                switch (input)
                {
                    case (int)ChooseTask.Shape:
                        ShapeController shapeController = new ShapeController();
                        shapeController.Run();
                        break;

                    case (int)ChooseTask.Employee:
                        EmployeeController employeeController = new EmployeeController();
                        employeeController.Run();
                        break;

                    case (int)ChooseTask.Bank:
                        BankController bankController = new BankController();
                        bankController.Run();
                        break;

                    case (int)ChooseTask.Exit:
                        break;
                }
            }
            while (input != 4);
        }
    }
}
