namespace Assignment3.Validation
{
    /// <summary>
    /// Contains validation for service like unique product name
    /// </summary>
    public static class InventoryServiceValidator
    {
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
