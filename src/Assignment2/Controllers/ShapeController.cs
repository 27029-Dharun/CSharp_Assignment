using Assignment2.Models.ShapeHierarchy;
using Assignment2.Services;
using Assignment2.Validators;
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
            int input;
            do
            {
                input = ConsoleView.GetInteger("Select a Shape to Create\r\n1. Circle\n2. Rectangle\n3. Exit\n");
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
            double length = this.GetValidDimension("Enter the Length of the Rectangle: ");
            if (length == -1)
            {
                ConsoleView.PrintInfo("Creation failed Please try again");
                return;
            }

            double width = this.GetValidDimension("Enter the Width of the Rectangle: ");
            if (width == -1)
            {
                ConsoleView.PrintInfo("Creation failed Please try again");
                return;
            }

            string color = this.GetValidString("Enter the color of the Rectangle: ");
            if (color == string.Empty)
            {
                ConsoleView.PrintInfo("Creation failed Please try again");
                return;
            }

            Rectangle rectangle = this._shapeservice.CreateRectangle(length, width, color);
            ConsoleView.PrintShape(rectangle);
        }

        /// <summary>
        /// This method performs all the circle operations
        /// </summary>
        private void CircleOperation()
        {
            double radius = this.GetValidDimension("Enter the Radius of the circle: ");
            if (radius == -1)
            {
                ConsoleView.PrintInfo("Creation failed Please try again");
                return;
            }

            string color = this.GetValidString("Enter the color of the circle: ");
            if (color == string.Empty)
            {
                ConsoleView.PrintInfo("Creation failed Please try again");
                return;
            }

            Circle circle = this._shapeservice.CreateCircle(radius, color);
            ConsoleView.PrintShape(circle);
        }

        /// <summary>
        /// This is a Valid Dimension
        /// </summary>
        /// <param name="message">The message to be printed</param>
        /// <returns>Double dimension field</returns>
        private double GetValidDimension(string message)
        {
            double input = ConsoleView.GetDouble(message);
            int tries = 3;
            while (input <= 0 && tries > 0)
            {
                ConsoleView.PrintInfo("Dimensions should be positive");
                ConsoleView.PrintInfo($"Tries Left: {tries}");
                tries--;
                input = ConsoleView.GetDouble("Enter the Radius of the Circle: ");
            }

            if (input <= 0)
            {
                return -1;
            }

            return input;
        }

        /// <summary>
        /// This is a Valid Dimension
        /// </summary>
        /// <param name="message">The message to be printed</param>
        /// <returns>Double dimension field</returns>
        private string GetValidString(string message)
        {
            int tries = 3;
            string color = ConsoleView.GetString(message);
            while (Validator.IsAllAlphabet(color) != string.Empty && tries > 0)
            {
                ConsoleView.PrintInfo("Invalid Color");
                ConsoleView.PrintInfo($"Tries Left: {tries}");
                tries--;
                color = ConsoleView.GetString(message);
            }

            if (Validator.IsAllAlphabet(color) != string.Empty)
            {
                ConsoleView.PrintInfo("Invalid Color");
                return string.Empty;
            }

            return color;
        }
    }
}