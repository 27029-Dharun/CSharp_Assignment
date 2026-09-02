namespace Assignment10.Utilities;

/// <summary>
/// Contains the math utilities to perform operations like addition, subtraction, multiplication, division.
/// </summary>
public static class MathUtils
{
    /// <summary>
    /// Add two integer and returns their sum.
    /// </summary>
    /// <param name="num1">An first integer value to add.</param>
    /// <param name="num2">An second integer value to add.</param>
    /// <returns>A integer value containing the sum of two integer.</returns>
    public static int Add(int num1, int num2)
    {
        return num1 + num2;
    }

    /// <summary>
    /// Subtract two integer and returns their result.
    /// </summary>
    /// <param name="num1">An first integer value.</param>
    /// <param name="num2">An second integer value.</param>
    /// <returns>A integer value containing the difference of two integer.</returns>
    public static int Subtract(int num1, int num2)
    {
        return num1 - num2;
    }

    /// <summary>
    /// Multiply two integer and returns their product.
    /// </summary>
    /// <param name="num1">An first integer value.</param>
    /// <param name="num2">An second integer value.</param>
    /// <returns>A integer value containing the multiplication result.</returns>
    public static int Multiply(int num1, int num2)
    {
        return num1 * num2;
    }

    /// <summary>
    /// Divide two integer and returns their sum.
    /// </summary>
    /// <param name="num1">An first integer value.</param>
    /// <param name="num2">An second integer value.</param>
    /// <returns>A integer value containing the quotient.</returns>
    public static int Divide(int num1, int num2)
    {
        return num1 / num2;
    }
}