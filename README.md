# .NET_Fundamentals

- What does the .NET ecosystem provide?

In general, .NET is an open source developer platform, created by Microsoft, for building many different types of applications, such as web, mobile, and desktop. It consists of different tools, programming languages, and libraries.

- What are .NET implementations? Which ones are used nowadays?

 It is a formal specification of .NET APIs that helps to create cross-platform libraries.
 Each .NET implementation has 4 components: runtime, base class library, application frameworks, development tools.
 Implementations of .NET include .NET Framework, .NET 5+ (and .NET Core), and Mono.

- What is CLR?

CLR(Common Language Runtime) is a component of the Microsoft .NET Framework that manages the execution of .NET applications. It runs the code and provides services including memory management, type safety, exception handling, garbage collection, security and thread management. All programs written for the .NET Framework, regardless of programming language, are executed in the CLR.

- Why is .NET 5 a bit of a special version?

Because .NET5 aimed to remove a lot of the complexities by aligning all the different frameworks to support a common set of APIs and to produce a single, cross-platform .NET runtime and framework that integrated the best features of .NET Core, .NET Framework, Xamarin, and Mono. It was released in November 2020, but will reach end of support on May 10, 2022.

- Which technologies are supported by the .NET framework?

.NET Framework is a software development framework for building and running applications on Windows.
The framework includes a variety of programming languages, such as C#, F#, and Visual Basic, and supports a range of application types, including desktop, web, mobile, and gaming applications.

- Does cross-platform development is possible in .NET? What about cross-platform UI?

Yes,  with the .NET Core framework, developers can create applications that run on multiple platforms, including Windows, macOS, and Linux. There are such cross-platform UI in .Net as .NET MAUI, Avalonia.

- What does the multitargeting term mean?

Multi-targeting is the ability to compile the same source code multiple times, each time compiling for a different version of .NET.
Each target will result in a separate DLL being produced for a class library project for example.
You can then take all the different DLLs and package them up in  a single NuGet package that can then be installed into projects with different .NET versions.

- What is the purpose of Exception Handling in C#?
The C# language's exception handling features help you deal with any unexpected or exceptional situations that occur when a program is running. Exception handling uses the 'try, catch, and finally' keywords to try actions that may not succeed. Failures don't go unnoticed because if an exception is thrown and you don't handle it, the runtime terminates your application. 

- Can a try block have multiple catch blocks? 
Yes you can have multiple catch blocks with try statement. You start with catching specific exceptions and then in the last block you may catch base Exception . Only one of the catch block will handle your exception.

- Describe a flow how exceptions are handled? 
When an exception is thrown, the common language runtime (CLR) looks for the catch block that can handle this exception. If the currently executed method doesn't contain such a catch block, the CLR looks at the method that called the current method, and so on up the call stack. If no catch block is found, the CLR terminates the executing thread. 

- What is the base class from which all exceptions are derived? 
In .NET, an exception is an object that inherits from the System.Exception class.

- What is the difference between Exception and Inner Exception? 
Exception is an object that describes the error that caused the current exception. The Inner Exception in C# is a property of the Exception class. The InnerException property returns the same value as was passed into the Exception(String, Exception) constructor, or null if the inner exception value was not supplied to the constructor. This property is read-only.

- What is the difference between throw ex; and throw; statements?  
The difference between 'throw' and 'throw ex' is that 'throw' preserves the stack trace (the stack trace will point to the method that caused the exception in the first place) while 'throw ex' does not preserve the stack trace (we will lose the information about the method that caused the exception in the first place. It will seem like the exception was thrown from the place of its catching and re-throwing).

- What is the purpose of finally statement? 
The finally block will execute when the try/catch block leaves the execution, no matter what condition cause it. It always executes whether the try block terminates normally or terminates due to an exception. The main purpose of finally block is to release the system resources.

- What predefined .NET Exceptions do you know? 
The following exceptions are thrown by certain C# operations:
System.ArithmeticException, System.DivideByZeroException, System.IndexOutOfRangeException, System.NullReferenceException, 
System.OutOfMemoryException, System.TypeInitializationException and other.

- Is there a way to create a custom exception?
Yes. .NET provides a hierarchy of exception classes ultimately derived from the Exception base class. However, if none of the predefined exceptions meet your needs, you can create your own exception classes by deriving from the Exception class.
