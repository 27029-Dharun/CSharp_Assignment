namespace Assignment2.EmployeeHierarchy
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
            if (this.Salary == null)
            {
                return 0;
            }

            return decimal.Multiply((decimal)this.Salary, 0.15M);
        }

        /// <summary>
        /// This class displays the Details of the Employee
        /// </summary>
        /// <returns>the name and salary of Empluyee</returns>
        public override string PrintDetails() => $"Developer Name: {this.Name}, Salary: {this.Salary} Bonus: {this.CalculateBonus()}";
    }
}
