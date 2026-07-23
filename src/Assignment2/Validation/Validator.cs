using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Validators
{
    /// <summary>
    /// This class contains Validator for the Project
    /// </summary>
    internal class Validator
    {
        /// <summary>
        /// This method validats string and check all the character if string
        /// </summary>
        /// <param name="input">String to be Checked</param>
        /// <returns>Boolean value true - All are character false if it contains letter</returns>
        public static string IsAllAlphabet(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "String can't be empty";
            }

            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return "Name can't have symbols other than alphabets";
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// This validates dimension
        /// </summary>
        /// <param name="dimension">Dimension of the shape</param>
        /// <returns>string output</returns>
        public static string IsValidDimension(double dimension)
        {
            if (dimension > 0)
            {
                return "Dimension can't be Negative or Zero";
            }

            return string.Empty;
        }

        /// <summary>
        /// This validates the account number
        /// </summary>
        /// <param name="number">The account number to be validated</param>
        /// <returns>the string outpur</returns>
        public static string IsValidAccountNumber(string number)
        {
            if (number.Length != 12)
            {
                return "Account number must contain tweleve digits";
            }

            foreach (char c in number)
            {
                if (!char.IsDigit(c))
                {
                    return "Account number can't have characters";
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// This validates the amount to be added
        /// </summary>
        /// <param name="amount">Amount to be validated</param>
        /// <returns>String output for validation</returns>
        public static string IsValidAmount(decimal amount)
        {
            if (amount > 0)
            {
                return string.Empty;
            }

            return "Amount can't be Negative";
        }
    }
}
