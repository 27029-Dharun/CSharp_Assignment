namespace Assignment2.Models.EmployeeHierarchy
{
    /// <summary>
    /// This is a derived class from Employee
    /// </summary>
    internal class Manager : Employee
    {
        /// <summary>
        /// Calculates the bonus of the Employee
        /// </summary>
        /// <returns>Decimal bonus value</returns>
        public override decimal CalculateBonus()
        {
            if (Salary == null)
            {
                return 0;
            }

            return decimal.Multiply((decimal)Salary, 0.10M);
        }

        /// <summary>
        /// This class displays the Details of the Employee
        /// </summary>
        /// <returns>the name and salary of Empluyee</returns>
        public override string PrintDetails() => $"Manager {Name}, {Salary} {CalculateBonus()}";
    }
}
