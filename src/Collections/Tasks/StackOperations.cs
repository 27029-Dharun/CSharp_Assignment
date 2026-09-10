using Collections.IO;

namespace Collections.Tasks;

/// <summary>
/// Contains stack implementation.
/// </summary>
public class StackOperations
{
    private readonly Stack<char> _chars = new Stack<char>();

    /// <summary>
    /// Gets a string input and load the characters in string into the stack.
    /// </summary>
    public void AddCharacter()
    {
        string input = ConsoleIO.GetString("Enter a string: ");
        foreach (char character in input)
        {
            this._chars.Push(character);
        }
    }

    /// <summary>
    /// Pops all the characters and append to a new string.
    /// </summary>
    public void RemoveCharacter()
    {
    }
}
