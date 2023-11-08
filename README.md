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

# Advanced C#

- What is the difference between reference and value types? 
A variable of a value type contains an instance of the type. Each value type variable holds its own copy of the data, and it is stored directly. If the data is assigned from one value type variable to another, then the system will create a separate copy of the data. Any changes made to one variable will not affect the other variable. (bool, byte, int, double, struct, enum, char ...)

Reference type contains a reference to an instance of the type. When the data is assigned from one reference type variable to another, both variables refer to the same memory location. So if the data is changed using one variable, it also gets changed for the other. Reference types include Classes, Interfaces, Delegates, and Arrays.

- What is boxing and unboxing? 
When a value type is converted to object type, it is called boxing and on the other hand, when an object type is converted to a value type, it is called unboxing.

- What is a class? What is an interface? 
A class in C# serves as a blueprint or prototype that outlines the structure and behavior of objects belonging to the same class category. It provides a specification for constructing individual objects with similar characteristics. Essentially, a class acts as a template that defines the properties, methods, and other members that objects of its type can possess. It encompasses both the state, represented by the properties, and the behavior, represented by the methods, that objects of its type can exhibit. Classes support the concept of inheritance. The class whose members are inherited is called the base class. The class that inherits the members of the base class is called the derived class. All types in the .NET type system implicitly inherit from Object or a type derived from it. The common functionality of Object is available to any type.

C# and .NET support single inheritance only, but classes can implement multiple interfaces. An interface is a completely "abstract class", which can only contain abstract methods and properties. An interface serves as a contract that defines the expected behavior and structure of objects, without specifying the implementation details. To implement from an interface means that the type implements all the methods defined in the interface.

- What is the difference between class and structure
One major difference between structs and classes is that a struct is a value type while a class is a reference type. Structs are often used to represent simple data types, such as integers, strings, and other basic data types. Classes, on the other hand, are used to represent more complex objects with multiple properties and methods. 
Another difference is that structs cannot inherit from other structs, while classes can inherit from other classes. This allows you to create more complex object hierarchies with classes.
And also classes are typically used to model real-world objects, such as cars or people in a program. Structs are often used in performance-critical applications because they are more lightweight than classes. Since structs are stored on the stack, they can be accessed more quickly than objects stored on the heap.

- What is a generic type? What is Covariance and Contravariance? 
Generics in C# is a feature that allows for the creation of reusable code by creating parameterized types. In simple terms, it enables us to create classes, interfaces, and methods that work with different data types without having to define the data type explicitly.

Covariance and Contravariance concepts will be first introduced for generics, then for delegates and finally for arrays.
Covariance serves as a means of allowing a method to return a type that is derived from the class specified in the type parameter. In the past, the return type had to exactly match the type parameter due to strict type matching of generics. Covariance relaxes this strict rule in a way that provides type safety. A parameter of a covariant type is declared using the 'Out' keyword, which precedes the name of the parameter.
Сontravariance allows a method to use an argument whose type is the base class specified by the corresponding type parameter. In the past, the type of a method argument had to exactly match the type parameter due to strict type matching of generics. Contravariance softens this strict rule in a way that provides type safety. A parameter of a contravariant type is declared using the 'In' keyword, which precedes the name of the parameter.

- What is delegate? 
A delegate is a type that represents references to methods with a particular parameter list and return type . When you instantiate a delegate, you can associate its instance with any method with a compatible signature and return type. You can invoke (or call) the method through the delegate instance.

- What is event? 
Events are something that occurs in a program. Events allow a class or object to notify other classes or objects when something occurs. The class that raises (or sends) the event is called the publisher. The classes that receive (or handle) the event are called subscribers.
Events are a special kind of multicast delegate that can only be invoked from within the class (or derived classes) or struct where they are declared (the publisher class). If other classes or structs subscribe to the event, their event handler methods will be called when the publisher class raises the event.

- What is the difference between delegate and event ?
Delegate is a function pointer. It holds the reference of one or more methods at runtime. A delegate is declared using the delegate keyword. Delegate is independent and not dependent on events. A delegate can be passed as a method parameter.

The event is a notification mechanism that depends on delegates. An event is declared using the event keyword.
An event is dependent on a delegate and cannot be created without delegates. Event is a wrapper around delegate instance to prevent users of the delegate from resetting the delegate and its invocation list and only allows adding or removing targets from the invocation list. An event is raised but cannot be passed as a method parameter.


