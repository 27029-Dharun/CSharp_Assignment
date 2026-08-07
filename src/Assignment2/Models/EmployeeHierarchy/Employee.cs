namespace Assignment2.Models.EmployeeHierarchy
{
    /// <summary>
    /// Serves as a base blue print for all the Employees
    /// </summary>
    internal abstract class Employee
    {
        /// <summary>
        /// Gets or sets and sets Name of the Employee.
        /// </summary>
        /// <value>
        /// A string value representing the name of the employee.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets salary of employee
        /// </summary>
        /// <value>
        /// A decimal value representing the salary of an individual.
        /// </value>
        public decimal? Salary { get; set; }

        /// <summary>
        /// Calculates Bonus for the Employee.
        /// Must be customized by the role of the employee.
        /// </summary>
        /// <returns>A decimal value representing the bonus of employee. </returns>
        public abstract decimal CalculateBonus();

        /// <summary>
        /// Creates a string containing employee details
        /// </summary>
        /// <returns>A string with name, salary and bonus of the employee</returns>
        public virtual string PrintDetails() => $"{this.Name}, {this.Salary} {this.CalculateBonus()}";
    }
}
