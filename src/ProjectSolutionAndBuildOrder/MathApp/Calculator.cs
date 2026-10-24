namespace MathApp;

/// <summary>
/// Contains the arithmetic operations.
/// </summary>
public static class Calculator
{
    /// <summary>
    /// Calculates the sum of two numbers.
    /// </summary>
    /// <param name="a">The first number.</param>
    /// <param name="b">The second number.</param>
    /// <returns>The sum of two numbers.</returns>
    public static double Add(double a, double b) => a + b;

    /// <summary>
    /// Calculates the difference of two numbers.
    /// </summary>
    /// <param name="a">The first number.</param>
    /// <param name="b">The second number.</param>
    /// <returns>The difference between two numbers.</returns>
    public static double Subtract(double a, double b) => a - b;

    /// <summary>
    /// Calculates the product of two numbers.
    /// </summary>
    /// <param name="a">The first number.</param>
    /// <param name="b">The second number.</param>
    /// <returns>The product of two numbers.</returns>
    public static double Multiply(double a, double b) => a * b;

    /// <summary>
    /// Divides the two numbers.
    /// </summary>
    /// <param name="a">The first number.</param>
    /// <param name="b">The second number.</param>
    /// <returns>The quotient <paramref name="a"/> divided by <paramref name="b"/>.</returns>
    public static double Divide(double a, double b) => a / b;
}
