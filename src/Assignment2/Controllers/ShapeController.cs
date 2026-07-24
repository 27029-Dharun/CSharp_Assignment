using Assignment2.Models.ShapeHierarchy;
using Assignment2.Services;
using Assignment2.Validators;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// This enum represents all the Task as enum
    /// </summary>
    internal enum ChooseShape
    {
        /// <summary>
        /// Shape
        /// </summary>
        Circle = 1,

        /// <summary>
        /// Employee
        /// </summary>
        Rectangle = 2,

        /// <summary>
        /// Exit from operation
        /// </summary>
        Exit = 3,
    }

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
        public void Run()
        {
            int input;
            do
            {
                input = ConsoleView.GetShapeOptions();
                switch (input)
                {
                    case (int)ChooseShape.Circle:
                        this.CircleOperation();
                        break;

                    case (int)ChooseShape.Rectangle:
                        this.RectangleOperation();
                        break;

                    case (int)ChooseShape.Exit:
                        return;

                    default:
                        ConsoleView.PrintInfo("Enter number in range 1 - 3");
                        break;
                }
            }
            while (input != 3);
        }

        /// <summary>
        /// This method performs all the rectangle operation
        /// </summary>
        private void RectangleOperation()
        {
            double length = ConsoleView.GetDouble("Enter the Length of the Rectangle: ");
            double width = ConsoleView.GetDouble("Enter the Width of the Rectangle: ");
            string color = ConsoleView.GetString("Enter the color of the Rectangle: ");
            if (length <= 0 || width <= 0)
            {
                ConsoleView.PrintInfo("Dimensions can't be Negative");
                return;
            }

            if (Validator.IsAllAlphabet(color) != string.Empty)
            {
                ConsoleView.PrintInfo("Invalid Color");
            }

            Rectangle? rectangle = this._shapeservice.CreateRectangle(length, width, color);
            if (rectangle != null)
            {
                ConsoleView.PrintShape(rectangle);
            }
            else
            {
                ConsoleView.PrintInfo("Invalid Dimension for the Rectangle");
            }
        }

        /// <summary>
        /// This method performs all the circle operations
        /// </summary>
        private void CircleOperation()
        {
            double radius = ConsoleView.GetDouble("Enter the Radius of the Circle: ");
            string color = ConsoleView.GetString("Enter the color of the Circle: ");
            if (radius <= 0)
            {
                ConsoleView.PrintInfo("Dimensions can't be Negative");
                return;
            }

            if (Validator.IsAllAlphabet(color) != string.Empty)
            {
                ConsoleView.PrintInfo("Invalid Color");
                return;
            }

            Circle? circle = this._shapeservice.CreateCircle(radius, color);
            if (circle != null)
            {
                ConsoleView.PrintShape(circle);
            }
            else
            {
                ConsoleView.PrintInfo("Invalid Dimension for the circle");
            }
        }
    }
}