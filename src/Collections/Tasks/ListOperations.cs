using Collections.IO;

namespace Collections.Tasks;

/// <summary>
/// Contains a list implementation
/// </summary>
/// <typeparam name="T">The data type for the name of the book.</typeparam>
public class ListOperations<T>
{
    private readonly List<T> _list = new List<T>();

    /// <summary>
    /// Creates a list with book names.
    /// </summary>
    /// <param name="arr">Array containing the books name</param>
    public void AddBooks(T[] arr)
    {
        for (int i = 0; i < 5; i++)
        {
            this._list.Add(arr[i]);
        }

        ConsoleIO.PrintInfo("Added five books name to the list\n");
    }

    /// <summary>
    /// Deletes a book entered by the user.
    /// </summary>
    /// <param name="bookName">Name of the book to delete.</param>
    public void DeleteBook(T bookName)
    {
        if (this._list.Contains(bookName))
        {
            this._list.Remove(bookName);
            Console.WriteLine($"Removed {bookName} from the list");
            return;
        }

        Console.WriteLine($"{bookName} not present in the list");
    }

    /// <summary>
    /// Displays the name of the book available in the list.
    /// </summary>
    public void DisplayBooks()
    {
        ConsoleIO.PrintInfo("Books in the list are: ");
        foreach (T bookName in this._list)
        {
            ConsoleIO.PrintInfo($"{bookName}");
        }
    }
}
