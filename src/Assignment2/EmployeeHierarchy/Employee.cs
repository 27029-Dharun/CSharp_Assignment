namespace Assignment2.EmployeeHierarchy
{
    /// <summary>
    /// This class contains Employee Details
    /// </summary>
    internal abstract class Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="salary">Salary </param>
        protected Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// Gets Name of the Employee
        /// </summary>
        /// <value>
        /// Name of the Employee
        /// </value>
        public string? Name { get; }

        /// <summary>
        /// Gets salary of employee
        /// </summary>
        /// <value>
        /// The Salary of all the individuals
        /// </value>
        public decimal? Salary { get; }

        /// <summary>
        /// Calculates Bonus of the Employee
        /// </summary>
        /// <returns>Bonus of employee</returns>
        public abstract decimal CalculateBonus();

        /// <summary>
        /// This class displays the Details of the Employee
        /// </summary>
        /// <returns>the name and salary of Empluyee</returns>
        public virtual string PrintDetails() => $"{this.Name}, {this.Salary} {this.CalculateBonus()}";
    }
}
