using System.Text;
using Collections.IO;

namespace Collections.Tasks;

/// <summary>
/// Contains stack implementation to reverse a string.
/// </summary>
public class StackOperations
{
    private readonly Stack<char> _chars = new Stack<char>();

    /// <summary>
    /// Gets a string input and load the characters in string into the stack.
    /// </summary>
    /// <returns>A string entered by the user.</returns>
    public string AddCharacter()
    {
        string input = ConsoleIO.GetName("Enter a string: ");
        foreach (char character in input)
        {
            this._chars.Push(character);
        }

        return input;
    }

    /// <summary>
    /// Pops all the characters and append to a new string.
    /// </summary>
    /// <returns>Reversed string input.</returns>
    public string ReverseCharacter()
    {
        StringBuilder reversedString = new StringBuilder();
        foreach (char character in this._chars)
        {
            reversedString.Append(character);
        }

        return reversedString.ToString();
    }
}
