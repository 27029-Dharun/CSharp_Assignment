namespace Assignment2.Models.EmployeeHierarchy
{
    /// <summary>
    /// Represents a manager and contain bonus calculation logic.
    /// </summary>
    internal class Manager : Employee
    {
        private const decimal ManagerBonusRate = 0.15M;

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="name"> Name of the manager. </param>
        /// <param name="salary"> Salary of the manager. </param>
        public Manager(string name, decimal salary)
            : base(name, salary)
        {
        }

        /// <summary>
        /// Calculates the bonus for the manager.
        /// </summary>
        /// <returns> A decimal bonus value of the manager. </returns>
        public override decimal CalculateBonus()
        {
            return decimal.Multiply((decimal)this.Salary, ManagerBonusRate);
        }

        /// <summary>
        /// Creates a string with the details of the employee.
        /// </summary>
        /// <returns> A string with the name and salary of Employee. </returns>
        public override string PrintDetails() => $"Manager {this.Name}\nSalary: {this.Salary}\nBonus: {this.CalculateBonus()}\n";
    }
}
