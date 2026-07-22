namespace Assignment2.Models.ShapeHierarchy
{
    /// <summary>
    /// THis class derives from the Circle class
    /// </summary>
    internal class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">radius</param>
        /// <param name="color">Color</param>
        public Circle(double radius, string color)
            : base(color)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets this property stores the Radius of the circle objects
        /// </summary>
        /// <value>
        /// Value of radius
        /// </value>
        public double Radius { get; }

        /// <summary>
        /// Calculates the Area of the Circle
        /// </summary>
        /// <returns>Double value of Area of circle</returns>
        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        /// <summary>
        /// Returns the detail of the Rectangle object
        /// </summary>
        /// <returns>string containing color, shape type, and area.</returns>
        public override string PrintDetails() => $"Circle Color: {this.Color} ,Area: {this.CalculateArea()}";
    }
}
