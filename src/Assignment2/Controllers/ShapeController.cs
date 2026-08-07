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

    /// <summary>
    /// Initializes a new instance of the <see cref="ShapeController"/> class.
    /// </summary>
    /// <param name="shapeService">Shape service object</param>
    public ShapeController(ShapeService shapeService)
    {
        this._shapeService = shapeService;
    }

    /// <summary>
    /// Serves as a entry point to root shape hierarchy.
    /// </summary>
    public void ShapeOperations()
    {
        ShapeOption input = (ShapeOption)ConsoleView.GetInteger("\nSelect a Shape to Create\r\n1. Circle\n2. Rectangle\n3. Exit\nEnter the option: ");
        switch (input)
        {
            case ShapeOption.Circle:
                this.CircleOperation();
                break;

            case ShapeOption.Rectangle:
                this.RectangleOperation();
                break;

            case ShapeOption.Exit:
                return;

            default:
                ConsoleView.PrintInfo("Enter number in range 1 - 3");
                break;
        }

        ConsoleView.PauseAndReturn();
    }

    /// <summary>
    /// Prompts user for data entry and displays the calculated area of rectangle
    /// </summary>
    private void RectangleOperation()
    {
        double length = ConsoleView.GetDouble("Enter the length of the rectangle: ");
        double width = ConsoleView.GetDouble("Enter the width of the rectangle: ");
        string color = ConsoleView.GetString("Enter the color of the rectangle: ");
        Rectangle? rectangle = this._shapeService.CreateRectangle(length, width, color);
        if (rectangle == null)
        {
            ConsoleView.PrintInfo("Dimension should be positive and color should only have alphabets");
            return;
        }

        ConsoleView.PrintInfo(this._shapeService.GetDetails(rectangle));
    }

    /// <summary>
    /// Prompts user for data entry and displays the calculated area of circle
    /// </summary>
    private void CircleOperation()
    {
        double radius = ConsoleView.GetDouble("Enter the radius of the circle: ");
        string color = ConsoleView.GetString("Enter the color of the circle: ");
        Circle? circle = this._shapeService.CreateCircle(radius, color);
        if (circle == null)
        {
            ConsoleView.PrintInfo("Dimension should be positive and color should only have alphabets");
            return;
        }

        ConsoleView.PrintInfo(this._shapeService.GetDetails(circle));
    }
}