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
