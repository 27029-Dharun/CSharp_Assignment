namespace Collections.Tasks;

/// <summary>
/// Contains the dictionary implementation that maps a student's name to their grade.
/// </summary>
/// <typeparam name="TKey">The data type of the student's identifier for the name.</typeparam>
/// <typeparam name="TValue">The data type of the student's grade.</typeparam>
public class DictionaryOperations<TKey, TValue>
    where TKey : notnull
{
    private readonly Dictionary<TKey, TValue> _entries;

    /// <summary>
    /// Initializes a new instance of the <see cref="DictionaryOperations{TKey, TValue}"/> class.
    /// </summary>
    /// <param name="length">The length of the dictionary.</param>
    public DictionaryOperations(int length)
    {
        this._entries = new Dictionary<TKey, TValue>(length);
    }

    /// <summary>
    /// Gets a read-only view of all student records.
    /// </summary>
    /// <value>The Entries of the dictionary.</value>
    public IReadOnlyDictionary<TKey, TValue> Entries => this._entries;

    /// <summary>
    /// Adds the student data to the dictionary.
    /// </summary>
    /// <param name="name">Name of the student.</param>
    /// <param name="value">Grade of the student.</param>
    /// <returns>A boolean true if the entry is added, otherwise false.</returns>
    public bool TryAdd(TKey name, TValue value)
    {
        return this._entries.TryAdd(name, value);
    }

    /// <summary>
    /// Deletes a student from the record.
    /// </summary>
    /// <param name="studentName">The name of the student to remove.</param>
    /// <returns>A boolean true if removed, otherwise false.</returns>
    public bool Remove(TKey studentName)
    {
        return this._entries.Remove(studentName);
    }
}
