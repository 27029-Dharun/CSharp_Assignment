# Assignment 8 - Error Handling

- This assignment implements error handling techniques to manage exceptions.
- It demonstrates try, catch and finally blocks, interpretation of exception stack traces, custom exceptions and global unhandled exception handling.

## Menu Options

1. Task 1 - Divide by zero
2. Task 2 - Index out of range
3. Task 3 - Custom exception
4. Task 4 - Global exception handling
5. Task 5 - View stack trace
6. Exit

## Task 1 - Divide by zero

- Implements `DivideByZeroException`.
- The try block attempts to divide an integer by zero. The catch block catches the exception and displays the corresponding error message.
- The finally block executes whether or not an exception is thrown.

## Task 2 - Index out of range

- Implements `IndexOutOfRangeException` and `ArgumentOutOfRangeException`.
- The program accesses an element of an integer array using an index that is outside the array bounds. The user is not asked for the index.
- The inner try/catch catches the `IndexOutOfRangeException` and throws a new `ArgumentOutOfRangeException` with a custom message, keeping the original exception as its inner exception.
- The outer try/catch catches the `ArgumentOutOfRangeException` and prints its message, followed by the inner exception message as the root cause.

## Task 3 - Custom exception

- Implements the custom `InvalidUserInputException`.
- The user is asked to enter an array index. If the input is not an integer or is outside the array range, `InvalidUserInputException` is thrown.
- The exception is caught and its message is displayed.

## Task 4 - Global exception handling

- Throws an `IndexOutOfRangeException` that is deliberately not handled.
- The unhandled exception is caught globally by the `AppDomain.UnhandledException` event handler, which is subscribed at the start of `Main`.
- The handler writes a message to `Console.Error` and calls `Environment.Exit(1)`, so the application ends with exit code 1.

## Task 5 - View stack trace

- Catches the `IndexOutOfRangeException` thrown by `Task4()` and prints its stack trace.

### How to read the stack trace

- Frames are listed from the most recent call to the oldest.
- The top frame identifies where the exception was thrown: `Task4()`, at the line shown.
- The trace covers the path from the throw point up to the frame that catches the exception, and no further. Here `Task5()` catches it, so `Task5()` is the last frame listed. `HandleMenu()` and `Main()` are not listed.
- If the exception were unhandled, as in Task 4, the trace would continue up through `HandleMenu()` and `Main()`, because nothing stops it earlier.