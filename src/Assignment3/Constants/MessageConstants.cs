namespace Assignment3.Constants;

/// <summary>
/// Constants messages to display.
/// </summary>
public static class MessageConstants
{
    /// <summary>
    /// Contains messages displayed by the inventory application.
    /// </summary>
    public const string SortOptionsPrompt = "Sort Product By\n" +
        "1. Name\n" +
        "2. Price\n" +
        "3. Quantity\n" +
        "Enter the option to sort: ";

    /// <summary>
    /// Contains the message to display when getting the main menu options.
    /// </summary>
    public const string MainMenuPrompt = "1. Add a product\n" +
        "2. View all products\n" +
        "3. Edit product\n" +
        "4. Delete product\n" +
        "5. Search products\n" +
        "6. Sort products\n" +
        "7. Exit\n" +
        "Choose an operation to continue: ";

    /// <summary>
    /// Contains the message to display when the inventory is empty.
    /// </summary>
    public const string EmptyInventoryMessage = "Inventory is empty";
}
