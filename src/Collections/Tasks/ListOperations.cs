namespace Collections.Tasks;

/// <summary>
/// Contains a list implementation
/// </summary>
/// <typeparam name="T">The data type for the name of the book.</typeparam>
public class ListOperations<T>
{
    private readonly List<T> _items;

    /// <summary>
    /// Initializes a new instance of the <see cref="ListOperations{T}"/> class.
    /// </summary>
    /// <param name="entryCount">Length of the count.</param>
    public ListOperations(int entryCount)
    {
         this._items = new List<T>(entryCount);
    }

    /// <summary>
    /// Gets a read-only view of all entries.
    /// </summary>
    /// <value>The value of all the entries.</value>
    public IReadOnlyList<T> Items => this._items;

    /// <summary>
    /// Adds an entry to the list.
    /// </summary>
    /// <param name="entry">The name to add in the list.</param>
    public void Add(T entry)
    {
        this._items.Add((T)entry);
    }

    /// <summary>
    /// Deletes an entry from the list.
    /// </summary>
    /// <param name="entry">Entry to be deleted.</param>
    /// <returns>A boolean true if the entry is deleted, otherwise false.</returns>
    public bool Remove(T entry)
    {
        return this._items.Remove(entry);
    }

    /// <summary>
    /// Checks if the entry is present in the list.
    /// </summary>
    /// <param name="entry">The entry to be checked in the list.</param>
    /// <returns>A boolean true if the list contains the entry.</returns>
    public bool Contains(T entry)
    {
        return this._items.Contains(entry);
    }
}
