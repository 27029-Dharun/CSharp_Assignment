using Assignment3.Constants;
using Assignment3.Models;
using Assignment3.Validators;
using ConsoleTables;

namespace Assignment3.View;

/// <summary>
/// Handles input and output operations.
/// </summary>
public class ConsoleView
{
    /// <summary>
    /// Gets an integer input.
    /// </summary>
    /// <param name="message">Message to be printed.</param>
    /// <returns>Integer input.</returns>
    public int GetInteger(string message)
    {
        int remainingAttempts = ValidationConstants.MaxAttempts;
        while (true)
        {
            string input = this.GetString(message);

            if (int.TryParse(input, out int integer))
            {
                return integer;
            }

            remainingAttempts--;
            if (remainingAttempts == 0)
            {
                throw new InvalidCastException("Enter a valid integer");
            }

            Console.WriteLine($"Tries left: {remainingAttempts}");
            Console.WriteLine("Enter a valid integer\n");
            Console.Write(message);
        }
    }

    /// <summary>
    /// Gets and validates an enum option selected by the user.
    /// </summary>
    /// <typeparam name="T">Generics type parameter which accepts all Enum type.</typeparam>
    /// <param name="prompt">Prompt displayed to the user.</param>
    /// <returns>The enum type to parse and validate.</returns>
    public T GetEnumOption<T>(string prompt)
        where T : struct, Enum
    {
        while (true)
        {
            string input = this.GetString(prompt);
            if (Enum.TryParse(input, out T result) && Enum.IsDefined(result))
            {
                return result;
            }

            Console.Clear();
            Console.WriteLine("Enter a valid option");
        }
    }

    /// <summary>
    /// Gets the name of the product from the user.
    /// </summary>
    /// <param name="isEditMode "> Optional indicates that the price can be empty used for edited the amount. </param>
    /// <returns>A string containing product name.</returns>
    public string GetProductName(bool isEditMode = false)
    {
        return this.GetValidatedInput(
            "Enter the product name: ",
            isEditMode,
            InventoryValidator.IsValidName,
            "Name should atleast contain three alphabets.");
    }

    /// <summary>
    /// Gets the product quantity from the user.
    /// </summary>
    /// <param name="isEditMode "> Optional indicates that the price can be empty used for edited the amount. </param>
    /// <returns>An integer value that is enter by user.</returns>
    public int? GetProductQuantity(bool isEditMode = false)
    {
        string input = this.GetValidatedInput(
            "Enter the quantity of the product: ",
            isEditMode,
            InventoryValidator.IsValidQuantity,
            "Quantity can't be negative");

        if (isEditMode && string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        return int.Parse(input);
    }

    /// <summary>
    /// Gets decimal product price from the user.
    /// </summary>
    /// <param name="isEditMode"> Optional indicates that the price can be empty used for edited the amount. </param>
    /// <returns> A decimal value containing the price of the product. </returns>
    public decimal? GetProductPrice(bool isEditMode = false)
    {
        string input = this.GetValidatedInput(
            "Enter the price of the product: ",
            isEditMode,
            InventoryValidator.IsValidPrice,
            "Price must a valid positive integer.");

        if (isEditMode && string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        return decimal.Parse(input);
    }

    /// <summary>
    /// Gets the search query to search product in the inventory.
    /// </summary>
    /// <returns>The query entered by the user.</returns>
    public string GetSearchQuery()
    {
        return this.GetString("Enter the name or product Id to search: ");
    }

    /// <summary>
    /// Print the message in console.
    /// </summary>
    /// <param name="message">Message to be printed.</param>
    public void PrintInfo(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Displays the edit option instruction.
    /// </summary>
    public void DisplayEditInstruction()
    {
        Console.WriteLine("Enter value for field that you only want to edit, leave the remaining field empty");
    }

    /// <summary>
    /// Prints the product object in console.
    /// </summary>
    /// <param name="product">Product to display.</param>
    public void PrintProduct(Product product)
    {
        Console.WriteLine($"\nProduct Id: {product.Id}");
        Console.WriteLine($"Product name: {product.Name}");
        Console.WriteLine($"Product price: {product.Price}");
        Console.WriteLine($"Product quantity: {product.Quantity}\n");
    }

    /// <summary>
    /// Displays the list of the products in the inventory.
    /// </summary>
    /// <param name="products">Products to display.</param>
    public void PrintInventory(List<Product> products)
    {
        var table = new ConsoleTable(
            "Product Id",
            "Product Name",
            "Product Price",
            "Product Quantity");

        foreach (Product inventory in products)
        {
            table.AddRow(inventory.Id, inventory.Name, inventory.Price, inventory.Quantity);
        }

        table.Write();
    }

    /// <summary>
    /// Pauses and waits for the user to enter a value.
    /// </summary>
    public void PauseAndContinue()
    {
        Console.WriteLine("Enter a key to return to main menu");
        Console.ReadKey();

        // Erases the entire scroll back buffer history
        Console.Write("\x1b[3J");
        Console.Clear();
    }

    private string GetValidatedInput(
        string prompt,
        bool isEditMode,
        Func<string, bool> isValidField,
        string errorMessage)
    {
        int remainingAttempts = ValidationConstants.MaxAttempts;

        while (true)
        {
            string input = this.GetString(prompt);

            if (isEditMode && string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            if (isValidField(input))
            {
                return input;
            }

            remainingAttempts--;
            if (remainingAttempts == 0)
            {
                throw new InvalidDataException("No attempt left, Please try again.\n");
            }

            Console.WriteLine(errorMessage);
            Console.WriteLine($"Attempts left: {remainingAttempts}\n");
        }
    }

    /// <summary>
    /// Gets the string from the user.
    /// </summary>
    /// <param name="message">Message to be displayed.</param>
    /// <returns>String given as input.</returns>
    private string GetString(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? string.Empty;
    }
}
