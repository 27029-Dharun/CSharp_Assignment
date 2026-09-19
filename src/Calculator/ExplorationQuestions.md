# Understanding .NET

## Exploration questions

### 1. Explain what the .NET platform is and its primary purpose

* .NET is a software development framework released by Microsoft that provides support to programming languages like **C#** , **F#**, **Visual basics**
* The primary purpose is to provide cross platform environment for developing and running applications.
* It provides common platform, libraries, tools and environment to develop and running applications.
* It provides runtime execution, memory management, garbage collection, exception handling, security mechanisms.
* It can be used to develop **Desktop Applications**, **Web Application**, **Unity-based Games**, and **Windows-based applications**.

### 2. What are the key components of the .NET platform?

The primary components making up the .NET platform include:

* **Compiler:** Converts supported high-level language code (e.g., C#, F#) into an CIL.
* **Runtime:** Executes and manages the application code during runtime.
* **Library:** Provides utility packages and built-in functionality (e.g., JSON serialization options).
* **SDK and Tools:** Help developers build, package, and monitor applications using modern workflows.
* **App Stacks:** Framework layers that help developers build specific application types like Windows Forms and Web Applications.

### 3. Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET

#### Common Language Runtime (CLR)

* The standard runtime execution environment provided by .NET.
* It is responsible for running .NET applications and managing their lifecycle. It acts as a virtual machine that takes compiled Intermediate Language (IL) code from languages like C#, VB.NET, or F#, and uses the Just-In-Time (JIT) compiler to convert it into native machine code at runtime.

##### Key Functions of CLR

* **Memory Management:** Allocates and manages memory.
* **Code Execution:** Converts CIL to machine level code during runtime.
* **Garbage Collection:** Automatically manages memory for managed code by collecting unreachable objects and defragmenting application memory.
* **Exception handling:** Provides structured excption handling to prevent crashes.
* **Thread Management:** Manages concurrent execution.

#### Common Type System (CTS)

* Dictates how data types are defined, declared, and managed inside the CLR.
* **Cross-Language Integration:** Enables seamless language interoperability by establishing a standard type standard across all .NET languages.
* Example:

C# code `int num = 4;`

This is converted as `System.Int32 num = 4;`

So internally, the CLR understand the type as System.Int32, for all the programming language like C#, F#

### 4. What is the role of the Global Assembly Cache (GAC) in .NET?

Systems running in the Common Language Runtime (CLR) include a machine-wide central cache known as the **Global Assembly Cache (GAC)**.

It stores assemblies intended to be shared across multiple distinct applications on the same computer.
Developers share code libraries globally by deploying them directly into the GAC.

### 5. Explain the difference between value types and reference types in **C#**

#### Value types

* Stores the actual value of the variable in the memory.
* It stores the value in stack.
* When assigned to a new variable, the underlying value is copied completely. Most primitive data types in C# operate as value types.
* **ex:** int, float, struct

#### Reference types

* Stores the reference pointing to the value of the variable.
* It stores the value in heap and the heaps reference is stored in the stack memory.
* When assigned to a new variable, the reference of the variable is copied to the new variable. So changing the new variable also changes the value of the old variable.

* **ex:** class, interface

### 6. Describe the concept of garbage collection on .NET and its advantages

The memory in heap is managed by the garbage collector.It performs operation like removing unused object stored in heap and perform memory defragmentation.
**Triggers of GC**

* When Garbage collector is called explicitly.
* When the memory occupied by the object surpasses the given threshold.

It used Mark and sweep algorithm to find the unreferenced object.
Garbage collector used the Generation of Object concept and separates object into three generations.

* **Generation 0:** Contains short-lived objects.
* **Generation 1:** Contains medium-lived objects that survived their initial GC cleaning cycle.
* **Generation 2:** Contains long-lived objects that survived multiple consecutive GC cycles.

### 7. What is the purpose of the Globalization and Localization features in .NET?

#### Globalization

* Adapts software to handle regional variations in calendar styles, date formats, number layouts, and currency formats.
* Achieved by writing formatting logic utilizing the native `System.Globalization` library namespace.

#### Localization

* The actual process of adapting a globalized application to support specific target cultures and target languages.
* Accomplished by converting and translating text resource files into executable code, giving developers deep customization over local user experiences.

### 8. Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework

#### Common Intermediate Language (CIL)

* High-level source code in C# is not compiled directly into native machine code. It is first compiled into an intermediate form called **CIL**.
* Languages like C#, F#, and VB.NET all compile down into an identical structural format CIL.
* And this provides a common execution format for .NET runtime.
* CIL is then converted to machine level code by JIT.

#### Just-In-Time (JIT) Compiler

* The CLR uses a specialized compiler called the **JIT Compiler** to translate CIL instructions into native machine code during execution.
* A piece of code it converted to machine level code right before it got executed for the first time.
* The entire code is not compiled to machine level code only the code that are used are compiled.
* Modern runtimes also support AOT compilation, which translates CIL into machine code before execution to achieve near-instant application startup times.
