using Assignment2.Models.ShapeHierarchy;
using Assignment2.Services;
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
    }

    /// <summary>
    /// THis is the Shape Controller
    /// </summary>
    internal class ShapeController
    {
        private readonly ShapeView _shapeview = new ();
        private readonly ShapeService _shapeservice = new ();

        /// <summary>
        /// This method is the entery point for Shape
        /// </summary>
        public void Run()
        {
            int input = this._shapeview.GetShapeOptions();
            switch (input)
            {
                case (int)ChooseShape.Circle:
                    this.CircleOperation();

                    break;

                case (int)ChooseShape.Rectangle:
                    this.RectangleOperation();

                    break;
            }
        }

        /// <summary>
        /// This method performs all the rectangle operation
        /// </summary>
        private void RectangleOperation()
        {
            this._shapeview.GetRectangleData(out double length, out double width, out string rectangleColor);
            Rectangle? rectangle = this._shapeservice.CreateRectangle(length, width, rectangleColor);
            if (rectangle != null)
            {
                this._shapeview.Print(rectangle);
            }
            else
            {
                this._shapeview.PrintInfo("Invalid Dimension for the Rectangle");
            }
        }

        /// <summary>
        /// This method performs all the circle operations
        /// </summary>
        private void CircleOperation()
        {
            this._shapeview.CreateCircle(out double radius, out string circleColor);
            Circle? circle = this._shapeservice.CreateCircle(radius, circleColor);
            if (circle != null)
            {
                this._shapeview.Print(circle);
            }
            else
            {
                this._shapeview.PrintInfo("Invalid Dimension for the circle");
            }
        }
    }
}