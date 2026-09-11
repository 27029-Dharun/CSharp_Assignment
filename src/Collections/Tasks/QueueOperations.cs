using Collections.IO;

namespace Collections.Tasks;

/// <summary>
/// Contains queue operations.
/// </summary>
/// <typeparam name="T">The data type for storing the name</typeparam>
public class QueueOperations<T>
{
    private readonly Queue<T> _queue = new Queue<T>();

    /// <summary>
    /// Add five name of person to the queue.
    /// </summary>
    /// <param name="names">A array containing 5 persons name.</param>
    public void AddNames(T[] names)
    {
        for (int i = 0; i < 5; i++)
        {
            this._queue.Enqueue(names[i]);
        }
    }

    /// <summary>
    /// Remove the name of the person from the queue.
    /// </summary>
    /// <returns>The name removed from the function</returns>
    public T RemoveName()
    {
        return this._queue.Dequeue();
    }

    /// <summary>
    /// Displays the name of the person in queue.
    /// </summary>
    public void DisplayNames()
    {
        foreach (T name in this._queue)
        {
            ConsoleIO.PrintInfo($"Name of the persons in the queue: {name}");
        }
    }

    /// <summary>
    /// Checks if the queue has any elements.
    /// </summary>
    /// <returns>A boolean true if it has any entries; otherwise false.</returns>
    public bool HasAny()
    {
        return this._queue.Any();
    }
}
