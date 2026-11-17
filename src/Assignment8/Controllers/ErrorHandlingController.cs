using System.Diagnostics;
using Assignment8.CustomExceptions;
using Assignment8.View;

namespace Assignment8.Controllers;

/// <summary>
/// Contains the tasks and controls the flow among the tasks.
/// </summary>
internal class ErrorHandlingController
{
    private static readonly int[] SampleNumbers = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private readonly ConsoleView _view;

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorHandlingController"/> class.
    /// </summary>
    /// <param name="view">Instance of view</param>
    internal ErrorHandlingController(ConsoleView view)
    {
        this._view = view;
    }

    /// <summary>
    /// Gets or sets the valid integer range of the array.
    /// </summary>
    /// <value>Integer range in the array.</value>
    private int ValidIndexRange { get; set; } = SampleNumbers.Length;

    /// <summary>
    /// Gets menu and navigates between different tasks.
    /// </summary>
    internal void HandleMenu()
    {
        while (true)
        {
            int option = this._view.GetMenuOption();
            this._view.ClearConsole();
            switch (option)
            {
                case 1:
                    this.DemonstrateTryCatchFinally();
                    break;

                case 2:
                    this.DemonstrateCatchAndThrow();
                    break;

                case 3:
                    this.DemonstrateCustomException();
                    break;

                case 4:
                    this.DemonstrateGlobalUnhandledException();
                    break;

                case 5:
                    this.RunExceptionHandler();
                    break;

                case 6:
                    return;

                default:
                    this._view.PrintInfo("Enter a valid option in range 1 - 6.");
                    break;
            }

            this._view.PauseAndReturn();
        }
    }

    private void DemonstrateTryCatchFinally()
    {
        int dividend = 10;
        int divisor = 0;
        this._view.PrintInfo($"Attempting to divide {dividend} by {divisor}");

        try
        {
            int quotient = dividend / divisor;
            this._view.PrintInfo($"{quotient}");
        }
        catch (DivideByZeroException)
        {
            this._view.PrintWarning("Can't divide a number with zero");
        }
        finally
        {
            this._view.PrintInfo("Finally block execution");
        }
    }

    private void DemonstrateCatchAndThrow()
    {
        try
        {
            try
            {
                this.PrintElementsPastEnd();
            }
            catch (IndexOutOfRangeException e)
            {
                this._view.PrintInfo("Caught in task 2 catch block...\n" +
                    "Throwing an error from task 2 catch block... \n");

                throw new InvalidOperationException($"Invalid index, please enter the index in range 0-{this.ValidIndexRange}", e);
            }
        }
        catch (InvalidOperationException e)
        {
            this._view.PrintInfo(e.Message);
        }
    }

    private void DemonstrateCustomException()
    {
        try
        {
            this._view.PrintInfo("The elements in the array\n"
                + string.Join(",", SampleNumbers));

            // throws error if the entered value is not integer.
            int index = this.ReadIndexFromUser();
            this._view.PrintInfo($"The element in the array at index {index} is {SampleNumbers[index]}.");
        }
        catch (InvalidUserInputException ex)
        {
            this._view.PrintWarning("Exception thrown for invalid integer caught in the task 3 catch block.\n" +
                ex.Message);
        }
    }

    private void DemonstrateGlobalUnhandledException()
    {
        this.PrintElementsPastEnd();
    }

    private void RunExceptionHandler()
    {
        try
        {
            this.DemonstrateGlobalUnhandledException();
        }
        catch (IndexOutOfRangeException)
        {
            StackFrame[] stackFrames = new StackTrace(true).GetFrames();

            this._view.PrintInfo($"Caught in the catch block of Task 5\n" +
                $"\nStack trace provides a historical record of the function calls that led to the exception.\n");

            foreach (var frame in stackFrames)
            {
                string methodName = frame.GetMethod() !.Name;
                string className = frame.GetMethod() !.DeclaringType?.FullName ?? "(Unknown Class)";
                string fileName = frame.GetFileName() ?? "(No file info)";
                int lineNumber = frame.GetFileLineNumber();

                this._view.PrintInfo($"{className}.{methodName} " +
                                     $"[File: {fileName}, Line: {lineNumber}]");
            }

            this._view.PrintInfo("The Stack trace contains two entities\n" +
                "Task 4 method that throws the exception\n" +
                "Task 5 method that calls Task4 and catches the exception\n");
        }
    }

    private void PrintElementsPastEnd()
    {
        for (int i = 0; i <= this.ValidIndexRange; i++)
        {
            this._view.PrintInfo($"The element in the array at index[{i}] is {SampleNumbers[i]}");
        }
    }

    private int ReadIndexFromUser()
    {
        int index = this._view.GetInteger("Enter the index to get the value from the array: ");

        if (index < 0 || index >= this.ValidIndexRange)
        {
            throw new InvalidUserInputException("Please enter the index in range 0-{this.ValidIndexRange}.\" ");
        }

        return index;
    }
}
