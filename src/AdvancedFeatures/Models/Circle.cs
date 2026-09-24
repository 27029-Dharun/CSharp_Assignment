namespace AdvancedFeatures.Models;

/// <summary>
/// Represents a circle shape
/// </summary>
internal class Circle : Shape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> class.
    /// </summary>
    /// <param name="color">Color of the circle.</param>
    /// <param name="radius">Radius of the circle.</param>
    internal Circle(string color, double radius)
        : base(color)
    {
        this.Radius = radius;
    }

    /// <summary>
    /// Gets or sets the radius of the circle
    /// </summary>
    /// <value>The radius of the circle</value>
    internal double Radius { get; set; }

    /// <summary>
    /// Calculates the area of the circle.
    /// </summary>
    /// <returns>The calculated area as a double.</returns>
    internal override double CalculateArea()
    {
        return Math.PI * this.Radius * this.Radius;
    }
}
