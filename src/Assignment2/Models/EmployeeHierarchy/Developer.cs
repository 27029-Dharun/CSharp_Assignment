namespace Assignment2.Models.EmployeeHierarchy
{
    /// <summary>
    /// Represents a developer and perform bonus calculation for developer.
    /// </summary>
    internal class Developer : Employee
    {
        private const decimal DeveloperBonusRate = 0.10M;

        /// <summary>
        /// Calculates the bonus of the developer.
        /// </summary>
        /// <returns> Bonus for the Employee. </returns>
        public override decimal CalculateBonus()
        {
            if (this.Salary is null)
            {
                return 0;
            }

            return decimal.Multiply((decimal)this.Salary, DeveloperBonusRate);
        }

        /// <summary>
        /// Creates a string with the details of employee.
        /// </summary>
        /// <returns>a string containing the name and salary of the developer</returns>
        public override string PrintDetails() => $"Developer Name: {this.Name}\nSalary: {this.Salary}\nBonus: {this.CalculateBonus()}\n";
    }
}
