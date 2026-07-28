
namespace Assignment3.Validation
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
        public bool ValidateQuantity(decimal quantity)
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
            if (name == null || name.Length == 0)
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
        /// Validates Index
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="v">Length of product inventory</param>
        /// <returns>Boolean value true if valid</returns>
        internal bool ValidateIndex(int index, int v)
        {
            return index >= 0 && index < v;
        }

        internal bool CheckUniqueId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
