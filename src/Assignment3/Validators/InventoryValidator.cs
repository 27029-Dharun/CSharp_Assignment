using Assignment3.Constants;

namespace Assignment3.Validators;

/// <summary>
/// Contains validation logic for product attributes.
/// </summary>
public static class InventoryValidator
{
    /// <summary>
    /// Validates price of the product.
    /// </summary>
    /// <param name="input">Price of the product.</param>
    /// <returns>True if the price is positive; otherwise false.</returns>
    public static bool IsValidPrice(string input)
    {
        if (!decimal.TryParse(input, out decimal price))
        {
            return false;
        }

        return HasValidMinimumValue(price, ValidationConstants.MinimumPrice);
    }

    /// <summary>
    /// Validates the quantity of the product.
    /// </summary>
    /// <param name="input">Quantity of the product.</param>
    /// <returns>True if quantity is not negative; otherwise false. </returns>
    public static bool IsValidQuantity(string input)
    {
        if (!int.TryParse(input, out int quantity))
        {
            return false;
        }

        return HasValidMinimumValue(quantity, ValidationConstants.MinimumQuantity);
    }

    /// <summary>
    /// Validates name to contain only alphabets.
    /// </summary>
    /// <param name="name">Name of the product. </param>
    /// <returns>True if name is valid; otherwise false. </returns>
    public static bool IsValidName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < ValidationConstants.MinimumNameLength)
        {
            return false;
        }

        return name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
    }

    /// <summary>
    /// Checks if the product name is unique.
    /// </summary>
    /// <param name="name"> Name of the product to be validated.</param>
    /// <param name="productNames"> List of products available in the inventory.</param>
    /// <returns> True if the name is unique; otherwise false. </returns>
    public static bool IsProductNameUnique(string name, IList<string> productNames)
    {
        return !productNames.Contains(name, StringComparer.OrdinalIgnoreCase);
    }

    private static bool HasValidMinimumValue<T>(T input, T minimumValue)
        where T : IComparable<T>
    {
        return input.CompareTo(minimumValue) >= 0;
    }
}
