namespace AdvancedFeatures.Models;

/// <summary>
/// Represents a rectangle
/// </summary>
internal class Rectangle : Shape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rectangle"/> class.
    /// </summary>
    /// <param name="color">The color of the rectangle.</param>
    /// <param name="length">The length of the rectangle</param>
    /// <param name="width">The width of the rectangle</param>
    internal Rectangle(string color, double length, double width)
        : base(color)
    {
        this.Length = length;
        this.Width = width;
    }

    /// <summary>
    /// Gets or sets the length of the rectangle.
    /// </summary>
    /// <value>The length of the rectangle.</value>
    internal double Length { get; set; }

    /// <summary>
    /// Gets or sets the width of the rectangle.
    /// </summary>
    /// <value>The width of the rectangle.</value>
    internal double Width { get; set; }

    /// <summary>
    /// Calculates the area of the rectangle
    /// </summary>
    /// <returns>The calculated area as a double.</returns>
    internal override double CalculateArea()
    {
        return Math.PI * this.Length * this.Width;
    }
}
