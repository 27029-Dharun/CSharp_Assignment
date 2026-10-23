namespace AdvancedFeatures.Models;

/// <summary>
/// Represents the abstract base class for a geometric shape.
/// </summary>
internal abstract class Shape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Shape"/> class.
    /// </summary>
    /// <param name="color">The color of the shape.</param>
    protected Shape(string color)
    {
        this.Color = color;
    }

    /// <summary>
    /// Gets or sets the color of the shape.
    /// </summary>
    /// <value>The color of the shape.</value>
    internal string Color { get; set; }

    /// <summary>
    /// Calculates the area of the shape.
    /// </summary>
    /// <returns>The calculated area as a double.</returns>
    internal abstract double CalculateArea();
}
