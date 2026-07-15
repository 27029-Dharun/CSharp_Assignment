using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// Helper class
    /// </summary>
    internal class Helper
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="number">Phone number</param>
        /// <returns>Boolean value </returns>
        public static bool IsValidateNumber(string number)
        {
            if (number == null)
            {
                return false;
            }

            if (number.Length != 0 && number.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}
