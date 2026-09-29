namespace AdvancedFeatures.Tasks;

/// <summary>
/// Provides functionality for notifying subscribers.
/// </summary>
internal class Notifier
{
    /// <summary>
    /// Represents the method signature for notification handlers.
    /// </summary>
    /// <param name="message">The message to be printed.</param>
    internal delegate void Notify(string message);

    /// <summary>
    /// Occurs when an action is executed and notifies all subscribed handlers.
    /// </summary>
    internal event Notify? OnAction;

    /// <summary>
    /// Invokes the event <see cref="OnAction"/>.
    /// </summary>
    /// <param name="message">The message to be passed to the event <see cref="OnAction"/>.</param>
    internal void Execute(string message)
    {
        this.OnAction?.Invoke(message);
    }
}
