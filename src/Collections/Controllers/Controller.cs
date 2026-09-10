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
        ListOperations list = new ListOperations();
        ConsoleIO.PrintHeader("List Task");
        ConsoleIO.PrintInfo("Adding books to list\n");
        list.AddBooks();

        ConsoleIO.PrintInfo("\nRemoving a book from list\n");
        list.DeleteBook();

        ConsoleIO.PrintInfo("\nDisplaying all the books\n");
        list.DisplayBooks();
    }

    private void HandleStackOperations()
    {
        StackOperations stack = new StackOperations();
        ConsoleIO.PrintHeader("Reversing a string\n");
        ConsoleIO.PrintInfo($"Entered String: {stack.AddCharacter()}");

        ConsoleIO.PrintInfo($"Reversed string : {stack.ReverseCharacter()}");
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
