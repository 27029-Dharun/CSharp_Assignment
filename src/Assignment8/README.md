# Assignment 8 - Error Handling

- This assignment showcases the error handling techniques by managing and responding to errors that occur during the execution of the program.
- It implements various strategies like try, catch and finally blocks, custom exceptions and global unhandled exception handling.
- It also interprets the exception stack trace.

## Menu Options

1. Task 1 - Divide by zero
2. Task 2 - Index out of bound
3. Task 3 - Custom exception
4. Task 4 - Global exception handling
5. Task 5 - View stack trace
6. Exit

## Task 1 - Divide by zero

- Implements `DivisionByZeroException`.
- The try block attempts to divide a number by zero and the catch block catches the exception and displays corresponding error message.
- The finally block is executed not matter try or catch block execute.

## Task 2 - Index out of bound

- Implements `IndexOutOfRangeException.`
- The user is asked to enter a lookup index to search.
- If the index is not within the maximum length of the array an exception is thrown.

## Task 3 - Custom exception

- Implements `InvalidUserInputException`.
- A custom exception that throws an exception when the user enters an invalid input.
- When the user fails to enter a valid input the exception is thrown.

## Task 4 - Global exception handling

- Throws an unhandled exception which is caught globally using the AppDomain's UnhandledException event.
- It implements the method that throws the `InvalidUserInputException` but does not handle it.

## Task 5 - View stack trace

- Catches the exception thrown by task 4 and print the stack trace

Stack Trace:

- at Assignment8.Controllers.Controller.Task4() in C:\Projects\CSharp_Assignment\src\Assignment8\Controllers\Controller.cs:line 150
- at Assignment8.Controllers.Controller.Task5() in C:\Projects\CSharp_Assignment\src\Assignment8\Controllers\Controller.cs:line 158
