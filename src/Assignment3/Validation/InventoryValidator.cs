namespace Assignment3.Validation
{
    /// <summary>
    /// Contains validation logic for product attributes.
    /// </summary>
    public static class InventoryValidator
    {
        private const int MinimumPrice = 1;

        private const decimal MinimumQuantity = 0;
        private const int MinimumNameLength = 3;

        /// <summary>
        /// Validates price of the product
        /// </summary>
        /// <param name="input">Price of the product</param>
        /// <returns>True if the price is positive; otherwise false</returns>
        public static bool IsValidatePrice(string input)
        {
            if (!decimal.TryParse(input, out decimal quantity))
            {
                return false;
            }

            if (quantity < MinimumPrice)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the quantity of the product.
        /// </summary>
        /// <param name="input">Quantity of the product</param>
        /// <returns>True if quantity is not negative; otherwise false. </returns>
        public static bool IsValidateQuantity(string input)
        {
            if (!int.TryParse(input, out int quantity))
            {
                return false;
            }

            if (quantity < MinimumQuantity)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates name to contain only alphabets.
        /// </summary>
        /// <param name="name">Name of the product. </param>
        /// <returns>True if name is valid; otherwise false. </returns>
        public static bool IsValidateName(string name)
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
    }
}
