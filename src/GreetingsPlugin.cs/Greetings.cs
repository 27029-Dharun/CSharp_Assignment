namespace GreetingsPlugin;
using IGreetingsPlugin;

/// <summary>
/// Displays the greeting message.
/// </summary>
public class Greetings : IGreetings
{
    /// <inheritdoc/>
    public void Greet()
    {
        Console.WriteLine($"Hello!");
    }
}
