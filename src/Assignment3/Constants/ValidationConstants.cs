namespace Assignment3.Constants;

/// <summary>
/// Contains all the configurable variables
/// </summary>
public static class ValidationConstants
{
    /// <summary>
    /// Represents the minimum price of the product.
    /// </summary>
    public const decimal MinimumPrice = 1;

    /// <summary>
    /// Represents the minimum quantity of the product.
    /// </summary>
    public const int MinimumQuantity = 0;

    /// <summary>
    /// Represents the minimum length for the name of the product.
    /// </summary>
    public const int MinimumNameLength = 3;

    /// <summary>
    /// Represents the maximum number of attempts to enter a valid input.
    /// </summary>
    public const int MaxAttempts = 3;
}
