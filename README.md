# .NET_Fundamentals

- What does the .NET ecosystem provide?
- What are .NET implementations? Which ones are used nowadays?
- What is CLR?
- Why is .NET 5 a bit of a special version?
- Which technologies are supported by the .NET framework?
- Does cross-platform development is possible in .NET? What about cross-platform UI?
- What does the multitargeting term mean?

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
