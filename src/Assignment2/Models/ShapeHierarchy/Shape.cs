namespace Assignment2.Models.ShapeHierarchy
{
    /// <summary>
    /// Serves as a base blue print for all the shapes.
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="color">Color of the shape</param>
        public Shape(string color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Gets this property stores the color of each shapes.
        /// </summary>
        /// <value>
        /// A string contains the color of the shape.
        /// </value>
        public string Color { get; }

        /// <summary>
        /// Calculates the area of the shape.
        /// Must be customized by specifying the shape.
        /// </summary>
        /// <returns>A double value containing area of the Shape.</returns>
        public abstract double CalculateArea();

        /// <summary>
        /// Creates a string with details of the shape.
        /// </summary>
        /// <returns> A string value with color and area of the shape. </returns>
        public virtual string PrintDetails() => $"{this.Color}, {this.CalculateArea()}";
    }
}
