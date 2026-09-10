using Collections.IO;

namespace Collections.Tasks;

/// <summary>
/// Contains queue operations.
/// </summary>
public class QueueOperations
{
    private readonly Queue<string> _queue = new Queue<string>();

    /// <summary>
    /// Add five name of person to the queue.
    /// </summary>
    public void AddNames()
    {
        for (int i = 0; i < 5; i++)
        {
            this._queue.Enqueue(ConsoleIO.GetString("Enter a person's name: "));
        }
    }

    /// <summary>
    /// Remove the name of the person from the queue.
    /// </summary>
    public void RemoveName()
    {
        ConsoleIO.PrintInfo("Removing the first person added to the queue.");
        string removedName = this._queue.Dequeue();
        ConsoleIO.PrintInfo($"Removed Name: {removedName}");
    }

    /// <summary>
    /// Displays the name of the person in queue.
    /// </summary>
    public void DisplayNames()
    {
        ConsoleIO.PrintInfo("The name of the persons in queue");
        foreach (string name in this._queue)
        {
            ConsoleIO.PrintInfo($"Name of the persons in the queue: {name}");
        }
    }
}
