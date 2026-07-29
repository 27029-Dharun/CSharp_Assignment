namespace InventoryManager.Validation
{
    /// <summary>
    /// Validator class
    /// </summary>
    internal class InventoryValidator
    {
        /// <summary>
        /// Validates price
        /// </summary>
        /// <param name="price">Price of the Product</param>
        /// <returns>True if the price is positive</returns>
        public bool IsValidatePrice(decimal price)
        {
            return price > 0;
        }

        /// <summary>
        /// Validates the quantity
        /// </summary>
        /// <param name="quantity">Quantity of the product</param>
        /// <returns>True if quantity is positive</returns>
        public bool IsValidateQuantity(decimal quantity)
        {
            return quantity > 0;
        }

        /// <summary>
        /// validates name to contain only alphabets
        /// </summary>
        /// <param name="name">Name of the Product</param>
        /// <returns>True if name is valid</returns>
        public bool IsValidateName(string name)
        {
            if (name == null || name.Length < 3)
            {
                throw new ArgumentException("Name should have at least 3 Characters");
            }

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    throw new ArgumentException("Name should only contain Alphabets");
                }
            }

            return true;
        }
    }
}
