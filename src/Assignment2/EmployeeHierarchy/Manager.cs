namespace Assignment2.EmployeeHierarchy
{
    /// <summary>
    /// This is a derived class from Employee
    /// </summary>
    internal class Manager : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="name">Name </param>
        /// <param name="salary">Salary of Employee</param>
        public Manager(string name, decimal salary)
            : base(name, salary)
        {
        }

        /// <summary>
        /// Calculates the bonus of the Employee
        /// </summary>
        /// <returns>Decimal bonus value</returns>
        public override decimal CalculateBonus()
        {
            if (this.Salary == null)
            {
                return 0;
            }

            return decimal.Multiply((decimal)this.Salary, 0.10M);
        }

        /// <summary>
        /// This class displays the Details of the Employee
        /// </summary>
        /// <returns>the name and salary of Empluyee</returns>
        public override string PrintDetails() => $"Manager {this.Name}, {this.Salary} {this.CalculateBonus()}";
    }
}
