# Assignment 16 - Advanced C# Concepts

## Task 1 - Events and delegates

This task demonstrates the implementation of the Events and delegates with a notification system.

1. **The Delegate (`Notify`):** A type-safe function pointer that can reference both static and instance methods, ensuring the method signature matches exactly.
2. **The Event (`OnAction`):** It allows a class or object to notify other classes or objects.
3. **The Subscription (`+=`):**  Add a method to the event all the methods that are subscribed are executed when it is invoked.
4. **The Trigger (`Execute`):** The events can be invoked only within that call so `Execute` method is used to invoke the events and execute all the methods subscribed.

## Task 2 - Type System: `var` vs `dynamic`

Both the keywords allow you to declare variables without explicitly naming the type, they handle type enforcement completely differently.

**var**:

- Statically typed.
- Should initialize value at the declaration.
- The compiler infers the type at **compile-time**.

**dynamic**:

- Dynamically typed.
- Need not to be initialized at declaration.
- The type is resolved at **runtime** via the Dynamic Language Runtime (DLR).

## Task 3 - Sorting an Array Using Anonymous Methods

This task demonstrates how to use an **anonymous method** to customize the behavior of the built-in `Array.Sort` method to sort an array of integers in ascending order.

```C#
Array.Sort(numbers, delegate(int x, int y) {
    return x.CompareTo(y);
});
```

- **`Array.Sort`**: A built-in C# utility. By default, it knows how to sort numbers, but here we explicitly pass a custom comparison rule as a second argument.
- **`delegate(int x, int y)`**: This is the **Anonymous Method**. The `delegate` keyword defines an inline function without a name. It intercepts the sorting process by grabbing two numbers from the array (`x` and `y`) to check which one is smaller.

### `return x.CompareTo(y);`

Inside the anonymous method, `CompareTo`:

- If `x` is smaller than `y`, it returns a **negative number**.
- If `x` is larger than `y`, it returns a **positive number**.
- If they are equal, it returns **0**.
- Changing this to `return y.CompareTo(x);` would sort the array in **descending order**.

## Task 4 - Lambda Expression

This task demonstrates the use of lambda expression to manuplicate the list.

```C#
var evenNumbers = integers.Where(number => number % 2 == 0);

var squaredNumbers = integers.Select(number => number * number);
```

`number => number % 2 == 0` returns boolean.
If the result is true the elements is added to the new list if not it is skipped.

`number => number * number` returns the squared result of the number.
The squared number returned is added to the new list.

## Task 5 - Advanced Use of Delegates for Sorting

This task demonstrates how to use a custom **Delegate** By passing different methods into the same execution loop, to allow sorting dynamically with Name, Category, or Price.

`public delegate int SortDelegate(Product first, Product second);`

- For **strings** (`Name`, `Category`), `string.Compare` organizes alphabetic positions.
- For **doubles** (`Price`), `.CompareTo` computes basic numerical values.

A method that sorts the product by accepting the delegate

```C#

internal void SortProducts(List<Product> products, SortDelegate sort)
{
    products.Sort((first, second) => sort(first, second));
}

```

## Task 6 - Records

This task demonstrates the core characteristics of **Records** in C# - declaration, value-based equality testing, immutability behaviors non-destructive mutation via the `with` expression, and positional object deconstruction.

### 1. Positional Record Syntax

`public record Book(string Title, string Author, string ISBN);`  
By using this brief single-line syntax, the C# compiler automatically builds.

- Init-only positional properties
- A constructor matching these arguments
- A customized `ToString()` formatter
- Built-in value-comparison.

### 2. Value-Based Equality (`==`)

In standard classes, `==` checks if two reference pointers point to the exact same physical memory block. With records, `==` evaluates the **actual content** inside the properties. Because `book2` and `duplicateOfBook2` contain identical property data strings, the check safely returns `True`.

### 3. Immutability

Attempting to directly write `book1.Title = "New Title";` throws a compile-time error.
Property or indexer 'Book.Title' cannot be assigned to -- it is read only.
This guarantees that once data enters the instance, it can never be altered by unpredictable runtime mutations.

### 4. Non-Destructive Mutation (`with`)

The `with` expression copies the entire original record structure into a brand new memory block while applying localized modifications cleanly in place. The original `book1` record is left completely untouched.

### 5. Automatic Deconstruction

Positional records natively bundle built-in deconstructors.
`var (title, author, isbn) = book;`

## Task 7 - Implementing Advanced Pattern Matching

This task demonstrates the use of **Type Pattern Matching** inside a `switch` statement (`Shape`), identify the underlying derived concrete implementation, and extract properties cleanly inline.

```csharp
if (shape is Circle) { 
    Circle c = (Circle)shape;
}
```

With modern C# Type Pattern Matching (`case Circle c:`), the compiler performs a **two-in-one check**. It verifies if the `shape` variable is a `Circle`. If true, it safely unboxes it and casts it directly into a local variable named **`c`** which is instantly ready for use within that `case` scope block.

```csharp

        switch (shape)
        {
            case Circle circle:

                ConsoleIO.PrintInfo("\nShape: Circle");
                ConsoleIO.PrintInfo($"Color: {circle.Color}");
                ConsoleIO.PrintInfo($"Radius: {circle.Radius}");
                ConsoleIO.PrintInfo($"Area: {circle.CalculateArea()}\n");
                break;

            case Rectangle rectangle:
                ConsoleIO.PrintInfo("\nShape: Rectangle");
                ConsoleIO.PrintInfo($"Color: {rectangle.Color}");
                ConsoleIO.PrintInfo($"Length: {rectangle.Length}");
                ConsoleIO.PrintInfo($"Width: {rectangle.Width}");
                ConsoleIO.PrintInfo($"Area: {rectangle.CalculateArea()}\n");
                break;

            case Triangle triangle:
                ConsoleIO.PrintInfo("\nShape: Rectangle");
                ConsoleIO.PrintInfo($"Color: {triangle.Color}");
                ConsoleIO.PrintInfo($"Height: {triangle.Height}");
                ConsoleIO.PrintInfo($"Width: {triangle.Base}");
                ConsoleIO.PrintInfo($"Area: {triangle.CalculateArea()}\n");
                break;
        }
```
