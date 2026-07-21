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
            if (Salary == null)
            {
                return 0;
            }

            return decimal.Multiply((decimal)Salary, 0.15M);
        }

        /// <summary>
        /// This class displays the Details of the Employee
        /// </summary>
        /// <returns>the name and salary of Empluyee</returns>
        public override string PrintDetails() => $"Developer Name: {Name}, Salary: {Salary} Bonus: {CalculateBonus()}";
    }
}
