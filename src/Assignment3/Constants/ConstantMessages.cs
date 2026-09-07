namespace Assignment3.Constants;

/// <summary>
/// Constants messages to display.
/// </summary>
public static class ConstantMessages
{
    /// <summary>
    /// Contains the options be which the products can be sorted.
    /// </summary>
    public const string SortOptionsPrompt = "Sort Product By\n" +
        "1. Name\n" +
        "2. Price\n" +
        "3. Quantity\n" +
        "Enter the option to sort: ";

    /// <summary>
    /// Contains the main menu options.
    /// </summary>
    public const string MainMenuPrompt = "1. Add a product\n" +
        "2. View all product\n" +
        "3. Edit Product\n" +
        "4. Delete Product\n" +
        "5. Search Product\n" +
        "6. Sort Products\n" +
        "7. Exit\n" +
        "Choose an operation to continue: ";

    /// <summary>
    /// Contains the message to display when the inventory is empty.
    /// </summary>
    public const string EmptyInventoryMessage = "Inventory is empty";
}
