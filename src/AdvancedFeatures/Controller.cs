using AdvancedFeatures.Tasks;

namespace AdvancedFeatures;

/// <summary>
/// Controls the flow of the application between the tasks.
/// </summary>
internal class Controller
{
    /// <summary>
    /// Handles the events and delegates concept.
    /// </summary>
    internal void HandleEventsAndDelegate()
    {
        Notifier notifier = new Notifier();
        notifier.OnAction += this.DisplayMessage;
        notifier.OnAction += this.NotifyUser;
        notifier.Execute("Dharun");
    }

    /// <summary>
    /// Handles var and delegates
    /// </summary>
    internal void HandleVarAndDynamic()
    {
        DataTypes dataTypes = new DataTypes();

        dataTypes.VarAndDelegateDemonstration();
    }

    /// <summary>
    /// Handles sort array operation.
    /// </summary>
    internal void HandleSort()
    {
        AnonymousMethod anonymousMethod = new AnonymousMethod();
        anonymousMethod.SortArray();
    }

    /// <summary>
    /// Display the greeting message to the user.
    /// </summary>
    /// <param name="userName">The name of the user.</param>
    internal void DisplayMessage(string userName) => Console.WriteLine($"Hello, {userName}");

    /// <summary>
    /// Display the notification to the user.
    /// </summary>
    /// <param name="userName">The name of the user.</param>
    internal void NotifyUser(string userName) => Console.WriteLine($"Notified {userName}");
}
