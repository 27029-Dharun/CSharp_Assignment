namespace Assignment2.Models.ShapeHierarchy
{
    /// <summary>
    /// This abstract class contains the Shape and calculate Area method
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// THis class assigns color
        /// </summary>
        /// <param name="color">Color of the shape</param>
        public Shape(string color)
        {
            Color = color;
        }

        /// <summary>
        /// Gets this property stores the color of each shapes
        /// </summary>
        /// <value>
        /// This contains the Color of each shape
        /// </value>
        public string? Color { get; }

        /// <summary>
        /// This abstract class is used to calculate area of different shapes
        /// </summary>
        /// <returns>Returns the area of the Shape</returns>
        public abstract double CalculateArea();

        /// <summary>
        /// This class prints the details of shape
        /// </summary>
        /// <returns>String output showing the Color and Area of the Shape </returns>
        public virtual string PrintDetails() => $"{Color}, {CalculateArea()}";
    }
}
