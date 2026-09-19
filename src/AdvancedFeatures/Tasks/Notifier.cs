namespace AdvancedFeatures.Tasks;

/// <summary>
/// Contains the notifier logics.
/// </summary>
internal class Notifier
{
    /// <summary>
    /// Notify delegate.
    /// </summary>
    /// <param name="message">The message to be printed.</param>
    internal delegate void Notify(string message);

    /// <summary>
    /// A event
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
