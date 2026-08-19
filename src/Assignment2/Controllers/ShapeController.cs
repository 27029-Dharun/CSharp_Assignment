using Assignment2.Models.Enums;
using Assignment2.Models.ShapeHierarchy;
using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2.Controllers;

/// <summary>
/// Manages Shape Hierarchy, connect view and shape service.
/// </summary>
internal class ShapeController
{
    private readonly ShapeService _shapeService;
    private readonly ConsoleView _view;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShapeController"/> class.
    /// </summary>
    /// <param name="view">Instance of the view</param>
    /// <param name="shapeService">Shape service object</param>
    internal ShapeController(ConsoleView view, ShapeService shapeService)
    {
        this._shapeService = shapeService;
        this._view = view;
    }

    /// <summary>
    /// Serves as a entry point to root shape hierarchy.
    /// </summary>
    internal void ShapeOperations()
    {
        ShapeOption input = this._view.GetEnumOption<ShapeOption>("\nSelect a Shape to Create\r\n1. Circle\n2. Rectangle\n3. Back\nEnter the option: ");
        switch (input)
        {
            case ShapeOption.Circle:
                this.CircleOperation();
                break;

            case ShapeOption.Rectangle:
                this.RectangleOperation();
                break;

            case ShapeOption.Back:
                return;

            default:
                this._view.PrintInfo("Enter number in range 1 - 3");
                break;
        }

        this._view.PauseAndReturn();
    }

    /// <summary>
    /// Prompts user for data entry and displays the calculated area of rectangle
    /// </summary>
    private void RectangleOperation()
    {
        double length = this._view.GetDimension("Enter the length of the rectangle: ");
        double width = this._view.GetDimension("Enter the width of the rectangle: ");
        string color = this._view.GetColor("Enter the color of the rectangle: ");

        Rectangle rectangle = this._shapeService.CreateRectangle(length, width, color);
        this._view.PrintInfo(this._shapeService.GetDetails(rectangle));
    }

    /// <summary>
    /// Prompts user for data entry and displays the calculated area of circle
    /// </summary>
    private void CircleOperation()
    {
        double radius = this._view.GetDimension("Enter the radius of the circle: ");
        string color = this._view.GetColor("Enter the color of the circle: ");

        Circle circle = this._shapeService.CreateCircle(radius, color);
        this._view.PrintInfo(this._shapeService.GetDetails(circle));
    }
}