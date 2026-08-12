namespace Assignment2.Models.ShapeHierarchy
{
    /// <summary>
    /// Represents a rectangle
    /// </summary>
    internal class Rectangle : Shape
    {
        private const string _type = "Rectangle";

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// The Rectangle class
        /// </summary>
        /// <param name="length"> Length of the rectangle. </param>
        /// <param name="width"> Width of the rectangle. </param>
        /// <param name="color"> Color of the rectangle. </param>
        public Rectangle(double length, double width, string color)
            : base(color)
        {
            this.Length = length;
            this.Width = width;
        }

        /// <summary>
        /// Gets the width of the rectangle.
        /// </summary>
        /// <value>
        /// A double containing width of the rectangle.
        /// </value>
        public double? Width { get; }

        /// <summary>
        /// Gets the height of the rectangle.
        /// </summary>
        /// <value>
        /// A double with height of the rectangle.
        /// </value>
        public double? Length { get; }

        /// <summary>
        /// Calculates the area of the rectangle.
        /// </summary>
        /// <returns> A double containing the area of the rectangle. </returns>
        public override double CalculateArea()
        {
            if (this.Length == 0 || this.Length == null || this.Width == null)
            {
                return 0;
            }

            double area = (double)(this.Width * this.Length);
            return Math.Round(area, 3);
        }

        /// <summary>
        /// Formats and returns the detail of the rectangle
        /// </summary>
        /// <returns>A string containing color, shape type, and area.</returns>
        public override string PrintDetails() => $"\nColor: {this.Color}\nShape Type: {_type}\nArea: {this.CalculateArea()}\n";
    }
}
