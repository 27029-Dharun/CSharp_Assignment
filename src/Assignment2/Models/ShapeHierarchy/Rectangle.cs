namespace Assignment2.Models.ShapeHierarchy
{
    /// <summary>
    /// This class derives from the Shape class and property for storing the dimensions
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// The Rectangle class
        /// </summary>
        /// <param name="length">Length</param>
        /// <param name="width">Width</param>
        /// <param name="color">Color</param>
        public Rectangle(double length, double width, string color)
            : base(color)
        {
            Length = length;
            Width = width;
        }

        /// <summary>
        /// Gets the the width of the rectangle
        /// </summary>
        /// <value>
        /// The width of the rectangle is stored here
        /// </value>
        ///
        public double? Width { get; }

        /// <summary>
        /// Gets the height of the Rectangle object
        /// </summary>
        /// <value>
        /// The height of the Rectangle object
        /// </value>
        public double? Length { get; }

        /// <summary>
        /// Calucates Area with Width and Height
        /// </summary>
        /// <returns>Area of type Double </returns>
        public override double CalculateArea()
        {
            if (Length == 0 || Length == null || Width == null)
            {
                return 0;
            }

            return (double)(Width * Length);
        }

        /// <summary>
        /// Returns the detail of the Rectangle object
        /// </summary>
        /// <returns>string containing color, shape type, and area.</returns>
        public override string PrintDetails() => $"{Color} , Rectangle, {CalculateArea()}";
    }
}
