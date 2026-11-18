namespace Collections.Tasks;

/// <summary>
/// Contains queue operations.
/// </summary>
/// <typeparam name="T">The data type for storing the entry</typeparam>
public class QueueOperations<T>
{
    private readonly Queue<T> _queue;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueueOperations{T}"/> class.
    /// </summary>
    /// <param name="length">The length of the queue.</param>
    public QueueOperations(int length)
    {
        this._queue = new Queue<T>(length);
    }

    /// <summary>
    /// Gets a read-only view of all the entries.
    /// </summary>
    /// <value>The read-only view of the entries.</value>
    public Queue<T> Entry => this._queue;

    /// <summary>
    /// Adds the entry of the person to the queue.
    /// </summary>
    /// <param name="entry">The entry of the person to add to the queue.</param>
    public void Enqueue(T entry)
    {
        this._queue.Enqueue(entry);
    }

    /// <summary>
    /// Remove the entry of the person from the queue.
    /// </summary>
    /// <param name="removedEntry">The name of the entry removed from the queue.</param>
    /// <returns>The entry removed from the function</returns>
    public bool TryDequeue(out T? removedEntry)
    {
        if (this._queue.TryDequeue(out removedEntry))
        {
            return true;
        }

        return false;
    }
}
