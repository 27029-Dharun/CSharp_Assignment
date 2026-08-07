using Assignment2.Models.ShapeHierarchy;
using Assignment2.Validators;

namespace Assignment2.Services
{
    /// <summary>
    /// Coordinates business logic for shapes
    /// </summary>
    internal class ShapeService
    {
        /// <summary>
        /// Creates a rectangle instance with the data of the rectangle
        /// </summary>
        /// <param name="length"> Length of the rectangle. </param>
        /// <param name="width"> Width of the rectangle. </param>
        /// <param name="color"> Color of the rectangle. </param>
        /// <returns> An instance of rectangle object. </returns>
        public Rectangle? CreateRectangle(double length, double width, string color)
        {
            if (length <= 0 || width <= 0 || Validator.IsAllAlphabet(color) != string.Empty)
            {
                return null;
            }

            return new Rectangle(length, width, color);
        }

        /// <summary>
        /// Creates a circle instance with the data of the circle
        /// </summary>
        /// <param name="radius"> Radius of the circle.</param>
        /// <param name="color"> Color of the circle. </param>
        /// <returns> An instance of circle that is created. </returns>
        public Circle? CreateCircle(double radius, string color)
        {
            if (radius <= 0 || Validator.IsAllAlphabet(color) != string.Empty)
            {
                return null;
            }

            return new Circle(radius, color);
        }

        /// <summary>
        /// Gets the details of the shape.
        /// </summary>
        /// <param name="shape">Instance of the shape</param>
        /// <returns>A string containing Details of the shape</returns>
        internal string GetDetails(Shape shape)
        {
            if (shape is Rectangle rect)
            {
                return rect.PrintDetails();
            }

            // Every shapes other than rectangle is a circle
            Circle circle = (Circle)shape;
            return circle.PrintDetails();
        }
    }
}
