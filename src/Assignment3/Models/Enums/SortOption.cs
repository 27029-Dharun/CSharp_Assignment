namespace Assignment3.Models.Enums;

/// <summary>
/// Specifies the fields in the inventory that we can sort with.
/// </summary>
public enum SortOption
{
    /// <summary>
    /// Represents the option to sort by name of the product.
    /// </summary>
    Name = 1,

    /// <summary>
    /// Represents the option to sort by the price of the product.
    /// </summary>
    Price,

    /// <summary>
    /// Represents the option to sort by the quantity of the product.
    /// </summary>
    Quantity,
}
