namespace Assignment2.Models.EmployeeHierarchy
{
    /// <summary>
    /// This class is dervied from the Employee class
    /// </summary>
    internal class Developer : Employee
    {
        /// <summary>
        /// This calss Calculates the Bonus of the Method
        /// </summary>
        /// <returns>Returns the bonus alue of the Developer</returns>
        public override decimal CalculateBonus()
        {
            if (this.Salary is null)
            {
                return 0;
            }

            return decimal.Multiply((decimal)this.Salary, 0.10M);
        }

        /// <summary>
        /// This class displays the Details of the Employee
        /// </summary>
        /// <returns>the name and salary of Empluyee</returns>
        public override string PrintDetails() => $"Developer Name: {this.Name}\nSalary: {this.Salary}\nBonus: {this.CalculateBonus()}\n";
    }
}
