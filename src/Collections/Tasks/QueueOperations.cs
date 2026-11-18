namespace Collections.Tasks;

/// <summary>
/// Contains queue operations.
/// </summary>
/// <typeparam name="T">The data type for storing the name</typeparam>
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
    /// Adds the name of the person to the queue.
    /// </summary>
    /// <param name="name">The name of the person to add to the queue.</param>
    public void Enqueue(T name)
    {
        this._queue.Enqueue(name);
    }

    /// <summary>
    /// Remove the name of the person from the queue.
    /// </summary>
    /// <returns>The name removed from the function</returns>
    public T Dequeue()
    {
        return this._queue.Dequeue();
    }

    /// <summary>
    /// Checks if the queue has any elements.
    /// </summary>
    /// <returns>A boolean true if it has any entries; otherwise false.</returns>
    public bool HasAny()
    {
        return this._queue.Count > 0;
    }
}
