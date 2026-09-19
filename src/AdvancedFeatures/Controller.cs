using AdvancedFeatures.IO;
using AdvancedFeatures.Models;
using AdvancedFeatures.Tasks;

namespace AdvancedFeatures;

/// <summary>
/// Controls the flow of the application between the tasks.
/// </summary>
internal class Controller
{
    /// <summary>
    /// Start the execution flow.
    /// </summary>
    internal void Run()
    {
        string menuOptionPrompt = "Advanced C# Features\n" +
            "[1] Task 1 - Events and delegates\n" +
            "[2] Task 2 - Use of dynamic and var keyword\n" +
            "[3] Task 3 - Anonymous Methods\n" +
            "[4] Task 4 - Lambda Expressions\n" +
            "[5] Task 5 - Delegates for Sorting\n" +
            "[6] Task 6 - Implementing and Manipulating Records\n" +
            "[7] Task 7 - Advanced Pattern Matching\n" +
            "[8] Exit\n" +
            "Enter an task to perform: ";

        MenuOption userChoice;
        do
        {
            userChoice = ConsoleIO.GetEnumOption<MenuOption>(menuOptionPrompt);
            switch (userChoice)
            {
                case MenuOption.Task1:
                    this.HandleTask1();
                    break;

                case MenuOption.Task2:
                    this.HandleTask2();
                    break;

                case MenuOption.Task3:
                    this.HandleTask3();
                    break;

                case MenuOption.Task4:
                    this.HandleTask4();
                    break;

                case MenuOption.Task5:
                    this.HandleTask5();
                    break;

                case MenuOption.Task6:
                    this.HandleTask6();
                    break;

                case MenuOption.Task7:
                    this.HandleTask7();
                    break;

                case MenuOption.Exit:
                    break;
            }

            ConsoleIO.PauseAndClear();
        }
        while (userChoice != MenuOption.Exit);
    }

    /// <summary>
    /// Demonstrates the events and delegates concept.
    /// </summary>
    internal void HandleTask1()
    {
        ConsoleIO.PrintHeader("Task 1 - Events and delegates");
        Notifier notifier = new Notifier();
        notifier.OnAction += this.DisplayMessage;
        notifier.OnAction += this.NotifyUser;
        notifier.Execute("Dharun");
    }

    /// <summary>
    /// Demonstrates var and delegates.
    /// </summary>
    internal void HandleTask2()
    {
        ConsoleIO.PrintHeader("Task 2 - Var And dynamic keyword");
        VarAndDynamic dataTypes = new VarAndDynamic();
        dataTypes.VarAndDelegateDemonstration();
    }

    /// <summary>
    /// Demonstrates sort array operation.
    /// </summary>
    internal void HandleTask3()
    {
        ConsoleIO.PrintHeader("Task 3 - Anonymous Method");
        AnonymousMethod anonymousMethod = new AnonymousMethod();
        anonymousMethod.SortArray();
    }

    /// <summary>
    /// Demonstrates list manipulation.
    /// </summary>
    internal void HandleTask4()
    {
        ConsoleIO.PrintHeader("Task 4 - Lambda Expression");
        LambdaExpressions lambdaExpressions = new LambdaExpressions();
        lambdaExpressions.ManipulateList();
    }

    /// <summary>
    /// Demonstrates sorting operation.
    /// </summary>
    internal void HandleTask5()
    {
        ConsoleIO.PrintHeader("Task 5 - Sorting with delegates");
        ConsoleIO.PrintHeader("Sorting with delegates");
        SortingWithDelegates sorting = new SortingWithDelegates();

        List<Product> products = new List<Product>
        {
            new Product("Apple", "Fruit", 200m),
            new Product("Laptop", "Electronics", 52000m),
            new Product("Chair", "Furniture", 8500m),
            new Product("Coffee Maker", "Appliances", 5500m),
            new Product("Notebook", "Stationery", 50m),
            new Product("T-shirt", "Clothing", 500m),
        };

        ConsoleIO.PrintInfo("\nSorting by name of the products\n");
        sorting.SortProducts(products, sorting.SortByName);

        ConsoleIO.PrintInfo("\nSorting by category of the products\n");
        sorting.SortProducts(products, sorting.SortByCategory);

        ConsoleIO.PrintInfo("\nSorting by price of the products\n");
        sorting.SortProducts(products, sorting.SortByPrice);
    }

    /// <summary>
    /// Demonstrates record task
    /// </summary>
    internal void HandleTask6()
    {
        ConsoleIO.PrintHeader("Task 6 - Record");

        // Creating record instance.
        Book book1 = new Book("The Alchemist", "Paulo Coelho", "978-0061122415");
        Book book2 = new Book("Clean Code", "Robert C. Martin", "978-0132350884");

        // Records support positional syntax, allows to define properties and constructors concisely in a single line
        ConsoleIO.PrintInfo($"Checking value equality for record: {book1.author == book2.author}");
        ConsoleIO.PrintInfo($"Checking value equality for record: {book1.author.Equals(book2.author)}");

        // Can't modify the record because by default all the properties are get-init.
        // book1.Title = " ";
        Book updatedBook = book1 with { title = "The Pilgrimage" };

        // Print both to show immutability
        ConsoleIO.PrintInfo("Original Book:");
        this.DisplayBook(book1);

        ConsoleIO.PrintInfo("\nUpdated Book:");
        this.DisplayBook(updatedBook);
    }

    /// <summary>
    /// Creates shape and calculates their area
    /// </summary>
    internal void HandleTask7()
    {
        ConsoleIO.PrintHeader("Task 7 - Calculate Shape Area");
        List<Shape> shapes = new List<Shape>
        {
            new Circle("Red", 12),
            new Rectangle("Red", 12, 3),
            new Triangle("Green", 12, 5),
        };

        foreach (var shape in shapes)
        {
            this.DisplayShapeDetails(shape);
        }
    }

    private void DisplayShapeDetails(Shape shape)
    {
        switch (shape)
        {
            case Circle circle:

                ConsoleIO.PrintInfo("\nShape: Circle");
                ConsoleIO.PrintInfo($"Color: {circle.Color}");
                ConsoleIO.PrintInfo($"Radius: {circle.Radius}");
                ConsoleIO.PrintInfo($"Area: {circle.CalculateArea()}\n");
                break;

            case Rectangle r:
                ConsoleIO.PrintInfo("\nShape: Rectangle");
                ConsoleIO.PrintInfo($"Color: {r.Color}");
                ConsoleIO.PrintInfo($"Length: {r.Length}");
                ConsoleIO.PrintInfo($"Width: {r.Width}");
                ConsoleIO.PrintInfo($"Area: {r.CalculateArea()}\n");
                break;

            case Triangle t:
                ConsoleIO.PrintInfo("\nShape: Rectangle");
                ConsoleIO.PrintInfo($"Color: {t.Color}");
                ConsoleIO.PrintInfo($"Height: {t.Height}");
                ConsoleIO.PrintInfo($"Width: {t.Base}");
                ConsoleIO.PrintInfo($"Area: {t.CalculateArea()}\n");
                break;
        }
    }

    private void DisplayBook(Book book1)
    {
        var (title, author, isbn) = book1;

        ConsoleIO.PrintInfo($"Title: {title}");
        ConsoleIO.PrintInfo($"Author: {author}");
        ConsoleIO.PrintInfo($"ISBN: {isbn}");
    }

    /// <summary>
    /// Display the greeting message to the user.
    /// </summary>
    /// <param name="userName">The name of the user.</param>
    private void DisplayMessage(string userName) => ConsoleIO.PrintInfo($"Hello, {userName}");

    /// <summary>
    /// Display the notification to the user.
    /// </summary>
    /// <param name="userName">The name of the user.</param>
    private void NotifyUser(string userName) => ConsoleIO.PrintInfo($"Notified {userName}");
}
