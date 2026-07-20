namespace Assignment2.EmployeeHierarchy
{
    /// <summary>
    /// This class is dervied from the Employee class
    /// </summary>
    internal class Developer : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// </summary>
        /// <param name="name">Name of Developer</param>
        /// <param name="salary">Salary of the Developer</param>
        public Developer(string name, decimal salary)
            : base(name, salary)
        {
        }

        /// <summary>
        /// This calss Calculates the Bonus of the Method
        /// </summary>
        /// <returns>Returns the bonus alue of the Developer</returns>
        public override decimal CalculateBonus()
        {
            if (this.Salary == null)
            {
                return 0;
            }

            return decimal.Multiply((decimal)this.Salary, 0.15M);
        }
    }
}
