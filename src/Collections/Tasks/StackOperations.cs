namespace Collections.Tasks;

/// <summary>
/// Contains stack implementation to reverse a string.
/// </summary>
/// <typeparam name="T">Type parameter</typeparam>
public class StackOperations<T>
{
    private readonly Stack<T> _chars = new Stack<T>();

    /// <summary>
    /// Gets a string input and load the characters in string into the stack.
    /// </summary>
    /// <param name="values">Type parameter</param>
    public void AddCharacter(List<T> values)
    {
        foreach (T character in values)
        {
            this._chars.Push(character);
        }
    }

    /// <summary>
    /// Pops all the characters and append to a new string.
    /// </summary>
    /// <returns>Reversed string input.</returns>
    public List<T> ReverseCharacter()
    {
        List<T> result = new List<T>();
        foreach (T character in this._chars)
        {
            result.Append(character);
        }

        return result;
    }
}
