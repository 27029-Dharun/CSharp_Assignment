using Assignment2.Models.Enums;
using Assignment2.Models.ShapeHierarchy;
using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// THis is the Shape Controller
    /// </summary>
    internal class ShapeController
    {
        private readonly ShapeService _shapeservice;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeController"/> class.
        /// </summary>
        /// <param name="shapeservice">Shape service object</param>
        public ShapeController(ShapeService shapeservice)
        {
            this._shapeservice = shapeservice;
        }

        /// <summary>
        /// This method is the entery point for Shape
        /// </summary>
        public void RunShapeOperations()
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
        /// This method performs all the rectangle operation
        /// </summary>
        private void RectangleOperation()
        {
            double length = ConsoleView.GetDouble("Enter the Length of the Rectangle: ");
            double width = ConsoleView.GetDouble("Enter the Width of the Rectangle: ");
            string color = ConsoleView.GetString("Enter the color of the Rectangle: ");
            Rectangle? rectangle = this._shapeservice.CreateRectangle(length, width, color);
            if (rectangle == null)
            {
                ConsoleView.PrintInfo("Dimension should be Positive and Color can't have symbols other than alphabets");
                return;
            }

            ConsoleView.PrintShape(rectangle);
        }

        /// <summary>
        /// This method performs all the circle operations
        /// </summary>
        private void CircleOperation()
        {
            double radius = ConsoleView.GetDouble("Enter the Radius of the circle: ");
            string color = ConsoleView.GetString("Enter the color of the circle: ");
            Circle? circle = this._shapeservice.CreateCircle(radius, color);
            if (circle == null)
            {
                ConsoleView.PrintInfo("Dimension should be Positive and Color can't have symbols other than alphabets");
                return;
            }

            ConsoleView.PrintShape(circle);
        }
    }
}