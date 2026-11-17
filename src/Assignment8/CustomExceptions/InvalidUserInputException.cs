namespace Assignment8.CustomExceptions;

/// <summary>
/// Exception thrown when user input is invalid.
/// </summary>
public sealed class InvalidUserInputException : Exception
{
    private const string DefaultExceptionMessage = "Input provided is invalid, please enter a valid input";

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class with a default error message.
    /// </summary>
    public InvalidUserInputException()
        : base(DefaultExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InvalidUserInputException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class with a specified error message and a inner exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The inner exception.</param>
    public InvalidUserInputException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
