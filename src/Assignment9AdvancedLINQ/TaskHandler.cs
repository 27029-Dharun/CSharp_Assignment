using Assignment9AdvancedLINQ.Models.Enums;
using Assignment9AdvancedLINQ.Tasks;
using Assignment9AdvancedLINQ.Views;

namespace Assignment9AdvancedLINQ;

/// <summary>
/// Contains logics to handle the task
/// </summary>
public class TaskHandler
{
    private ConsoleView _view;
    private BasicLinqQuery _basicLinqQuery;
    private ComplexLinqQuery _complexLinqQuery;
    private ArrayOperations _task3;
    private QueryOptimization _task4;
    //private QueryBuilder _task5;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskHandler"/> class.
    /// </summary>
    /// <param name="view">Instance of the view</param>
    /// <param name="basicLinqQuery">Instance of basic linq query</param>
    /// <param name="complexLinqQuery">Instance of complex linq query</param>
    /// <param name="task3">Instance of the task3</param>
    /// <param name="task4">Instance of the task4</param>
    /// <param name="task5">Instance of the task5</param>
    public TaskHandler(ConsoleView view, BasicLinqQuery basicLinqQuery, ComplexLinqQuery complexLinqQuery, ArrayOperations task3, QueryOptimization task4)
    {
        this._view = view;
        this._basicLinqQuery = basicLinqQuery;
        this._complexLinqQuery = complexLinqQuery;
        this._task3 = task3;
        this._task4 = task4;
        //this._task5 = task5;
    }

    /// <summary>
    /// Navigates to the tasks that is specified by the user.
    /// </summary>
    public void HandleTask()
    {
        while (true)
        {
            MenuOption option = this._view.GetEnumValue<MenuOption>("Select the option to continue: ");

            switch (option)
            {
                case MenuOption.Task1:
                    this._basicLinqQuery.GetAveragePrice();
                    break;

                case MenuOption.Task2:
                    this._complexLinqQuery.ComplexLinqQueries();
                    break;

                case MenuOption.Task3:
                    this._task3.HandleArrayOperations();
                    break;

                case MenuOption.Exit:
                    return;

                default:
                    this._view.PrintInfo("Enter a valid option");
                    break;
            }
        }
    }
}
