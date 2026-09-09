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
            this._list.Add(ConsoleIO.GetString("Enter a book name: "));
        }
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
        }
    }

    /// <summary>
    /// Displays the name of the book available in the list.
    /// </summary>
    public void DisplayBooks()
    {
        ConsoleIO.PrintInfo("Books the list are: ");
        foreach (string bookName in this._list)
        {
            ConsoleIO.PrintInfo(bookName);
        }
    }
}
