using Assignment2.Models.ShapeHierarchy;
using Assignment2.Validators;

namespace Assignment2.Services
{
    /// <summary>
    /// This contains the Shape Services
    /// </summary>
    internal class ShapeService
    {
        /// <summary>
        /// This method creates the rectangle
        /// </summary>
        /// <param name="length">Length</param>
        /// <param name="width">Width</param>
        /// <param name="color">Color</param>
        /// <returns>Returns the Rectangle Object</returns>
        public Rectangle? CreateRectangle(double length, double width, string color)
        {
            if (length <= 0 || width <= 0 || Validator.IsAllAlphabet(color) != string.Empty)
            {
                return null;
            }

            return new Rectangle(length, width, color);
        }

        /// <summary>
        /// THis method creates the circle object
        /// </summary>
        /// <param name="radius">Radius</param>
        /// <param name="color">Color</param>
        /// <returns>Returns the circle object</returns>
        public Circle? CreateCircle(double radius, string color)
        {
            if (radius <= 0 || Validator.IsAllAlphabet(color) != string.Empty)
            {
                return null;
            }

            return new Circle(radius, color);
        }
    }
}
