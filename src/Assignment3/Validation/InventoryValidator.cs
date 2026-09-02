namespace Assignment3.Validation
{
    /// <summary>
    /// Contains validation logic for product attributes.
    /// </summary>
    public static class InventoryValidator
    {
        private const decimal MinimumPrice = 1;
        private const int MinimumQuantity = 0;
        private const int MinimumNameLength = 3;

        /// <summary>
        /// Validates price of the product
        /// </summary>
        /// <param name="input">Price of the product</param>
        /// <returns>True if the price is positive; otherwise false</returns>
        public static bool IsValidatePrice(string input)
        {
            if (!decimal.TryParse(input, out decimal price))
            {
                return false;
            }

            return HasValidMinimumValue(price, MinimumPrice);
        }

        /// <summary>
        /// Validates the quantity of the product.
        /// </summary>
        /// <param name="input">Quantity of the product</param>
        /// <returns>True if quantity is not negative; otherwise false. </returns>
        public static bool IsValidQuantity(string input)
        {
            if (!int.TryParse(input, out int quantity))
            {
                return false;
            }

            return HasValidMinimumValue(quantity, MinimumQuantity);
        }

        /// <summary>
        /// Validates name to contain only alphabets.
        /// </summary>
        /// <param name="name">Name of the product. </param>
        /// <returns>True if name is valid; otherwise false. </returns>
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < MinimumNameLength)
            {
                return false;
            }

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the product name is unique
        /// </summary>
        /// <param name="name"> Name of the product to be validated.</param>
        /// <param name="productNames"> List of products available in the inventory.</param>
        /// <param name="existingName"> Existing name of the product</param>
        /// <returns> True if the name is unique; otherwise false. </returns>
        public static bool IsUniqueProductName(string name, List<string> productNames, string? existingName = null)
        {
            // Returns true if the name is equals to the name that is already existing.
            if (existingName != null && existingName == name)
            {
                return true;
            }

            foreach (var productName in productNames)
            {
                if (productName == name)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HasValidMinimumValue<T>(T input, T minimumValue)
            where T : IComparable
        {
            return input.CompareTo(minimumValue) >= 0;
        }
    }
}
