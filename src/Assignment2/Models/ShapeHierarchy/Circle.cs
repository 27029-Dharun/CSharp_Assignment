namespace Assignment2.Models.ShapeHierarchy
{
    /// <summary>
    /// Represents a geometric circle shape
    /// </summary>
    internal class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius"> Radius of the circle. </param>
        /// <param name="color"> Color of the circle. </param>
        public Circle(double radius, string color)
            : base(color)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets this the radius of the circle.
        /// </summary>
        /// <value>
        /// A double containing the radius of the circle.
        /// </value>
        public double Radius { get; }

        /// <summary>
        /// Calculates the area of the circle.
        /// </summary>
        /// <returns> A double value with area of circle. </returns>
        public override double CalculateArea()
        {
            double area = Math.PI * this.Radius * this.Radius;
            return Math.Round(area, 2);
        }

        /// <summary>
        /// Format and return a string with details of the circle.
        /// </summary>
        /// <returns>A string containing color, shape type, and area of the circle.</returns>
        public override string PrintDetails() => $"\nCircle Color: {this.Color}\nArea: {this.CalculateArea()}\n";
    }
}
