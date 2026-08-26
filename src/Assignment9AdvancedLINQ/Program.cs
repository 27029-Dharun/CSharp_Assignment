using Assignment9AdvancedLINQ.Models.Enums;
using Assignment9AdvancedLINQ.Repository;
using Assignment9AdvancedLINQ.Tasks;
using Assignment9AdvancedLINQ.Views;

namespace Assignment9AdvancedLINQ;

/// <summary>
/// Program class for starting the operation
/// </summary>
public class Program
{

    /// <summary>
    /// Application entry point and composition root. Wires up the dependencies once and hands control to the controller.
    /// </summary>
    public static void Main()
    {
        ConsoleView view = new ConsoleView();
        Database database = new Database();

        Task1 task1 = new Task1(database, view);
        Task2 task2 = new Task2(database, view);
        Task3 task3 = new Task3(database, view);
        Task4 task4 = new Task4(database, view);
        Task5 task5 = new Task5(database, view);

        database.InitializeData();

        while (true)
        {
            MenuOption option = view.GetEnumValue<MenuOption>("Select the option to continue: ");

            switch (option)
            {
                case MenuOption.Task1:
                    task1.GetAveragePrice();
                    break;

                case MenuOption.Task2:
                    break;

                case MenuOption.Task3:
                    break;

                default:
                    view.PrintInfo("Enter a valid option");
                    break;
            }
        }
    }
}