using Collections.IO;

namespace Collections.Tasks;

/// <summary>
/// Contains a list implementation
/// </summary>
public class ListOperations
{
    private readonly List<string> _list = new List<string>();

    /// <summary>
    /// Creates a list with book names.
    /// </summary>
    public void AddBooks()
    {
        for (int i = 0; i < 5; i++)
        {
            this._list.Add(ConsoleIO.GetName("Enter the book name: "));
        }

        ConsoleIO.PrintInfo("Added five books name to the list\n");
    }

    /// <summary>
    /// Deletes a book entered by the user.
    /// </summary>
    public void DeleteBook()
    {
        string bookName = ConsoleIO.GetString("Enter the book name to delete: ");

        if (this._list.Contains(bookName))
        {
            this._list.Remove(bookName);
            Console.WriteLine($"Removed {bookName} from the list");
        }

        Console.WriteLine($"{bookName} not present in the list");
    }

    /// <summary>
    /// Displays the name of the book available in the list.
    /// </summary>
    public void DisplayBooks()
    {
        ConsoleIO.PrintInfo("Books in the list are: ");
        foreach (string bookName in this._list)
        {
            ConsoleIO.PrintInfo(bookName);
        }
    }
}
