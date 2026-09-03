namespace Assignment10.Utilities;

/// <summary>
/// Contains the math utilities to perform operations like addition, subtraction, multiplication, division.
/// </summary>
public static class MathUtils
{
    /// <summary>
    /// Add two integer and returns their sum.
    /// </summary>
    /// <param name="firstNumber">First integer value to add.</param>
    /// <param name="secondNumber">Second integer value to add.</param>
    /// <returns>A integer value containing the sum of two integer.</returns>
    public static int Add(int firstNumber, int secondNumber)
    {
        return firstNumber + secondNumber;
    }

    /// <summary>
    /// Subtract two integer and returns their difference.
    /// </summary>
    /// <param name="firstNumber">First integer value.</param>
    /// <param name="secondNumber">Second integer value.</param>
    /// <returns>A integer value containing the difference of two integer.</returns>
    public static int Subtract(int firstNumber, int secondNumber)
    {
        return firstNumber - secondNumber;
    }

    /// <summary>
    /// Multiply two integer and returns their product.
    /// </summary>
    /// <param name="firstNumber">First integer value.</param>
    /// <param name="secondNumber">second integer value.</param>
    /// <returns>A integer value containing the multiplication result.</returns>
    public static int Multiply(int firstNumber, int secondNumber)
    {
        return firstNumber * secondNumber;
    }

    /// <summary>
    /// Divide two integer and returns their quotient.
    /// </summary>
    /// <param name="firstNumber">First integer value.</param>
    /// <param name="secondNumber">Second integer value.</param>
    /// <returns>A integer value containing the quotient.</returns>
    public static double Divide(int firstNumber, int secondNumber)
    {
        if (secondNumber == 0)
        {
            throw new DivideByZeroException("Invalid Argument - Divisor can't be zero");
        }

        return (double)firstNumber / secondNumber;
    }
}