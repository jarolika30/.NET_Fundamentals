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

# Debugging Fundamentals

- What is break mode? What are the options to step through code?
Break mode is the state of an application when the execution gets paused and allows the developer to edit the value in the current state and to debug the code. When you're in break mode, you can use various commands to navigate through your code:
F11 - Step Into; F10 - Step Over; Shift+F11 - Step Out;
- How to ignore some exceptions during debugging?
An exception is an indication of an error state that occurs while a program is being executed. You can tell the debugger which exceptions or sets of exceptions to break on, and at which point you want the debugger to break (that is, pause in the debugger). When the debugger breaks, it shows you where the exception was thrown. You can also add or delete exceptions. With a solution open in Visual Studio, use Debug > Windows > Exception Settings to open the Exception Settings window.
- How to set up conditional breakpoint?
You can control when and where a breakpoint executes by setting conditions. The condition can be any valid expression that the debugger recognizes. You should put your mouse on the breakpoint, right-click and select "Condition". This will open up a window where we can define a condition to hit the breakpoint only when the condition is met. 
- What is data breakpoint?
A data breakpoint is set on a variable and triggers a break when the value is first set or when it is changed.
If the value is read but not changed, execution doesn't break.
- What is trace point and how to use it?
A tracepoint is a breakpoint that prints a message to the Output window. A tracepoint can act like a temporary trace statement in the programming language and does not pause the execution of code. You can create a tracepoint by setting a special action in the Breakpoint Settings window. Tracepoints allow you to log information to the Output window under configurable conditions without modifying or stopping your code. 
- What are pdb files, when are they created and how to use them?
'pdb files' comes from Program database files. Debug information can be generated in .pdb files, depending on the compiler options that are used. Creating .pdb files can be useful if you later have to debug your release version. They can show the location of the source files, where in the app to stop for a breakpoint, the server to retrieve data from.
- What is symbol server?
 A symbol server is a centralized system that stores the PDB files (debugging symbols) for later access. This allows the compiled code to be shipped separately from the symbols required for debugging. By pointing a debugger to the symbol server, the necessary symbols could be downloaded dynamically and pulled into the debugger on-demand.
- What are debug and release build configurations?
Visual Studio projects have separate release and debug configurations for the program. You build the debug version for debugging and the release version for the final release distribution. In debug configuration, your program compiles with full symbolic debug information and no optimization. Optimization complicates debugging, because the relationship between source code and generated instructions is more complex.
The release configuration of your program has no symbolic debug information and is fully optimized.
