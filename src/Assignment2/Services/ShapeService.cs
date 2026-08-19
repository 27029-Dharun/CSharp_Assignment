using Assignment2.Models.ShapeHierarchy;

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
        /// <param name="length">Length of the rectangle.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="color">Color of the rectangle.</param>
        /// <returns>An instance of rectangle object.</returns>
        internal Rectangle CreateRectangle(double length, double width, string color)
        {
            return new Rectangle(length, width, color);
        }

        /// <summary>
        /// Creates a circle instance with the data of the circle
        /// </summary>
        /// <param name="radius">Radius of the circle.</param>
        /// <param name="color">Color of the circle.</param>
        /// <returns>An instance of circle that is created.</returns>
        internal Circle CreateCircle(double radius, string color)
        {
            return new Circle(radius, color);
        }

        /// <summary>
        /// Gets the details of the shape.
        /// </summary>
        /// <param name="shape">Instance of the shape</param>
        /// <returns>A string containing Details of the shape</returns>
        internal string GetDetails(Shape shape)
        {
            return shape.PrintDetails();
        }
    }
}
