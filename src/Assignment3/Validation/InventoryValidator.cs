namespace Assignment3.Validation
{
    /// <summary>
    /// Contains validation logic for product attributes.
    /// </summary>
    internal static class InventoryValidator
    {
        private const int MinimumPrice = 1;

        private const decimal MinimumQuantity = 0;
        private const int MinimumNameLength = 3;

        /// <summary>
        /// Validates price of the product
        /// </summary>
        /// <param name="price">Price of the product</param>
        /// <returns>True if the price is positive; otherwise false</returns>
        public static bool IsValidatePrice(decimal price)
        {
            return price >= MinimumPrice;
        }

        /// <summary>
        /// Validates the quantity of the product.
        /// </summary>
        /// <param name="quantity">Quantity of the product</param>
        /// <returns>True if quantity is not negative; otherwise false. </returns>
        public static bool IsValidateQuantity(decimal quantity)
        {
            return quantity >= MinimumQuantity;
        }

        /// <summary>
        /// Validates name to contain only alphabets.
        /// </summary>
        /// <param name="name">Name of the product. </param>
        /// <returns>True if name is valid; otherwise false. </returns>
        public static bool IsValidateName(string name)
        {
            if (name is null || name.Length < MinimumNameLength)
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
    }
}
