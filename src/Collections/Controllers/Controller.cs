using Collections.IO;
using Collections.Tasks;

namespace Collections.Controllers;

/// <summary>
/// Coordinates and control the flow between the different tasks.
/// </summary>
public class Controller
{
    /// <summary>
    /// Handles task menu and executes the task.
    /// </summary>
    public void HandleTaskMenu()
    {
        string menuPrompt = "1. List operation\n" +
            "2. Stack (Reverse string)\n" +
            "3. Queue operation\n" +
            "4. Dictionary operation\n" +
            "5. Exit\n" +
            "Enter an option to continue: ";

        while (true)
        {
            try
            {
                TaskOptions option = ConsoleIO.GetEnumOption<TaskOptions>(menuPrompt);

                switch (option)
                {
                    case TaskOptions.List:
                        this.HandleListOperations();
                        break;

                    case TaskOptions.Stack:
                        this.HandleStackOperations();
                        break;

                    case TaskOptions.Queue:
                        this.HandleQueueOperations();
                        break;

                    case TaskOptions.Dictionary:
                        this.HandleDictionaryOperations();
                        break;

                    case TaskOptions.Exit:
                        return;
                }
            }
            catch (Exception e)
            {
                ConsoleIO.PrintInfo(e.Message);
            }

            ConsoleIO.PauseAndClear();
        }
    }

    private void HandleListOperations()
    {
        ListOperations<string> list = new ListOperations<string>();
        ConsoleIO.PrintHeader("List Task");
        ConsoleIO.PrintInfo("Adding books to list\n");

        string[] arr = new string[5];
        for (int i = 0; i < 5; i++)
        {
            arr[i] = ConsoleIO.GetString("Enter a book name");
        }

        list.AddBooks(arr);

        ConsoleIO.PrintInfo("\nRemoving a book from list\n");
        string nameToDelete = ConsoleIO.GetString("Enter a book name");
        list.DeleteBook(nameToDelete);

        ConsoleIO.PrintInfo("\nDisplaying all the books\n");
        list.DisplayBooks();
    }

    private void HandleStackOperations()
    {
        StackOperations<char> stack = new StackOperations<char>();
        ConsoleIO.PrintHeader("Reversing a string\n");

        string input = ConsoleIO.GetName("Enter the name to reverse: ");
        List<char> charArray = new List<char>();
        foreach (char character in input)
        {
            charArray.Add(character);
        }

        stack.AddCharacter(charArray);
        ConsoleIO.PrintInfo($"Entered String: {input}");

        ConsoleIO.PrintInfo($"Reversed string : {string.Join(string.Empty, stack.ReverseCharacter())}");
    }

    private void HandleQueueOperations()
    {
        QueueOperations queue = new QueueOperations();
        ConsoleIO.PrintHeader("Queue Task");
        ConsoleIO.PrintInfo("Adding name to queue\n");
        queue.AddNames();

        ConsoleIO.PrintInfo("\nRemoving a book from queue\n");
        queue.RemoveName();

        ConsoleIO.PrintInfo("\nDisplaying all the books\n");
        queue.DisplayNames();
    }

    private void HandleDictionaryOperations()
    {
        DictionaryOperations queue = new DictionaryOperations();
        ConsoleIO.PrintHeader("Students database");
        ConsoleIO.PrintInfo("\nAdding data to dictionary\n");
        queue.CreateStudentData();

        ConsoleIO.PrintInfo("\nRemoving a student from dictionary\n");
        queue.DeleteStudent();

        ConsoleIO.PrintInfo("\nDisplaying all the students\n");
        queue.DisplayStudent();
    }
}
