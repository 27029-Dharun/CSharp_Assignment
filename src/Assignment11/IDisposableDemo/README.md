# Assignment 11

## Implementing and understanding the IDisposable Interface and the `using` Statement

### IDisposable Interface

- IDisposable is an interface that helps us to release unmanaged resources like database collections, file handlers and opened network connections.
- It contains the a method Dispose

```csharp
namespace System
{
    public interface IDisposable
    {
        void Dispose();
    }
}
```

- When implemented and used it allow us to release the unmanaged resources.
- It can be used with using statement for automatic cleanup.

### Using Statement

- Automatically call dispose for the object that implements the IDisposable interface even if an exception is thrown.

```csharp
using (FileWriter fileWriter = new FileWriter(path))
{
    fileWriter.Write("Hello World");
}
```

Behaves like

```csharp
try{
    fileWriter.Write("Hello World");
}
finally{
    fileWriter.Dispose();
}
```
