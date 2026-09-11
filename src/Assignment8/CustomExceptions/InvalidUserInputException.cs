namespace Assignment8.CustomExceptions;

/// <summary>
/// Exception thrown when user input is invalid.
/// </summary>
internal class InvalidUserInputException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
    /// With a default error message.
    /// </summary>
    internal InvalidUserInputException()
        : base("Input provided is invalid, please enter a valid input")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
    /// With a custom error message.
    /// </summary>
    /// <param name="message"> Custom error message. </param>
    internal InvalidUserInputException(string message)
        : base(message)
    {
    }
}
