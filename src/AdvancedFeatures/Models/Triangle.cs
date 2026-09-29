namespace AdvancedFeatures.Models;

/// <summary>
/// Represents a triangle.
/// </summary>
internal class Triangle : Shape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Triangle"/> class with a specified color, base, and height.
    /// </summary>
    /// <param name="color">The color of the triangle.</param>
    /// <param name="triangleBase">The length of the triangle's base.</param>
    /// <param name="height">The vertical height of the triangle.</param>
    internal Triangle(string color, double triangleBase, double height)
        : base(color)
    {
        this.Base = triangleBase;
        this.Height = height;
    }

    /// <summary>
    /// Gets or sets the length of the triangle's base.
    /// </summary>
    /// <value>The base dimension as a double-precision floating-point number.</value>
    internal double Base { get; set; }

    /// <summary>
    /// Gets or sets the vertical height of the triangle.
    /// </summary>
    /// <value>The height dimension as a double-precision floating-point number.</value>
    internal double Height { get; set; }

    /// <summary>
    /// Calculates the area of the triangle using the base and height dimensions.
    /// </summary>
    /// <returns>The calculated area as a double.</returns>
    internal override double CalculateArea()
    {
        return 0.5 * this.Base * this.Height;
    }
}
