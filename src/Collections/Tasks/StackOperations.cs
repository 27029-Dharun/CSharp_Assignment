using Collections.IO;

namespace Collections.Tasks;

internal class StackOperations
{
    Stack<char> chars = new Stack<char>();

    public void AddCharacter()
    {
        string c = ConsoleIO.GetString("Enter a string: ");
        this.chars.Push(c[0]);
    }
}
