using System.Text;

namespace Collections.Tasks;

/// <summary>
/// Contains stack implementation to reverse a string.
/// </summary>
/// <typeparam name="T">The datatype for storing </typeparam>
public static class StackOperations<T>
{
    /// <summary>
    /// Reverse a string using a stack.
    /// </summary>
    /// <param name="input">The string to reverse.</param>
    /// <returns>The reversed string.</returns>
    public static string ReverseString(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        Stack<char> charStack = new Stack<char>(input.Length);

        foreach (char c in input)
        {
            charStack.Push(c);
        }

        StringBuilder reversed = new StringBuilder(input.Length);
        while (charStack.Count > 0)
        {
            reversed.Append(charStack.Pop());
        }

        return reversed.ToString();
    }
}
