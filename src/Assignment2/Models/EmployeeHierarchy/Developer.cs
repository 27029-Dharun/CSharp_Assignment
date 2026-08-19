namespace Assignment2.Models.EmployeeHierarchy
{
    /// <summary>
    /// Represents a developer and perform bonus calculation for developer.
    /// </summary>
    internal class Developer : Employee
    {
        private const decimal DeveloperBonusRate = 0.10M;
        private const string _position = "Developer";

        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// </summary>
        /// <param name="name">Name of the developer.</param>
        /// <param name="salary">Salary received by the developer.</param>
        internal Developer(string name, decimal salary)
            : base(name, salary)
        {
        }

        /// <summary>
        /// Calculates the bonus of the developer.
        /// </summary>
        /// <returns>Bonus for the Employee.</returns>
        internal override decimal CalculateBonus()
        {
            return this.Salary * DeveloperBonusRate;
        }

        /// <summary>
        /// Creates a string with the details of employee.
        /// </summary>
        /// <returns>A string containing the name and salary of the developer.</returns>
        internal override string PrintDetails() => $"Name: {this.Name}\nPosition: {_position}\nSalary: {this.Salary}\nBonus: {this.CalculateBonus()}\n";
    }
}
