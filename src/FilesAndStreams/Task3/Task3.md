# Task 3 - File Handling and Memory Efficiency

## Objective

To understand how to write data to a file, read data from a file, and identify unnecessary memory usage.

## Identified Memory Issue

The following code creates an unnecessary copy of the data:
byte[] writeBuffer = memoryStream.ToArray();
ToArray() creates a new byte array containing all the data in the MemoryStream.
For large amounts of data, this requires additional memory.

## Modified Approach

Instead of converting the entire MemoryStream into a new byte array, we can use CopyTo().

### Modified Flow

String
   ↓
MemoryStream
   ↓
CopyTo()
   ↓
FileStream
   ↓
File

## Example

using (MemoryStream memoryStream = new MemoryStream())
{
    byte[] buffer = Encoding.ASCII.GetBytes(data);
    memoryStream.Write(buffer, 0, buffer.Length);
    memoryStream.Position = 0;
    using (FileStream fileStream = new FileStream(
        path,
        FileMode.Create,
        FileAccess.Write))
    {
        memoryStream.CopyTo(fileStream);
    }
}

## Why CopyTo() Is Better

- Avoids creating a complete duplicate byte array.
- Reduces unnecessary memory allocation.
- Transfers data directly from MemoryStream to FileStream.
- Better for handling large amounts of data.

## Conclusion

The main memory issue was the unnecessary copy created by ToArray().
Using CopyTo() or writing directly to FileStream makes the program more memory-efficient.
