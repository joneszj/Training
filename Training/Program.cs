using System;

namespace Training
{
    class Program
    {
        /// <summary>
        /// Areas of focus: IDE, working environment, solutions, projects, namespaces
        /// Secondary: types, OOP, debugging, Project class & static void Main method (aka entry point), starting/stoping an application, Console
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // IDE - Integrated Development Environment
            // Visual Studio (VS) is an IDE tailored around the .Net Framework (.Net Core)
            // The .Net Framework is an ecosystem of programs and functionality developed by Microsoft
            // Web Applications, Games, Console Applications, Database Applications etc.

            // The .Net Framework can be written in C# or VB.Net, both are Object Oriented Programming languages (OOP)
            // Both compile into Intermediate Language (IL)

            // VS will organize projects for us into a solution
            // A solution may contain man projects. Projects can reference other projects but not in a circular manner

            // All C# code must be written on a class. Classes are organized in projects using a namespace as well as folders
            // C# is an OOP language, meaning our code is organized as and on objects/types

            // A type or class is simply a definition for what something is/has (state/properties) and what it does (behvior/methods)
            // An instance is when we create a type as an actual object using the 'new' keyword
            // The static keyword allows us to create state/behavior that is not tied to instances, but instead to a class
            // If the class is is not static, but has statis state/behavior, that state/behavior is shared by all instances

            // All .Net applications will call the 'static void Main' method on the Program class to start your application
            // Consider it the startup entry point

            // Starting an application is as simple as prssing F5 or clicking the green play button at the top
            // Stopping the application is a simple as pressing the red stop button once an application is running

            // A Console application is a very simple .Net application that provides for us a CLI user interface
            // We can write output, and read input
            // Console applications are extremely minimal, an so they are ideal for learning C# and fundamental .Net functionality without the overhead of learning a framework
            // (A framework is an opinionated pattern to completing certain tasks. Ex: MVC is a framework for constructing and managing a web site
            // With the Console application, we really only need to concern ourselves with input and output
            // The rest is purely learning C# and .Net base functionality

            // TODO: go over intellisense

            // We can use Console.WriteLine(string) to output text to the applicaiton
            Console.WriteLine("Hello!");
            // We can use Console.ReadKey() to get a single keypress from a user and store it into a variable
            var key = Console.ReadKey();
            // We can use Console.ReadLine() to read an entire line of input from the application and store it into a variable
            var input = Console.ReadLine();
            // There are other methods and state on the Console such as making beep sounds and setting color, but we really only need to concern ourselves with input and output for now

            // https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history

            #region Deep Dive
            // https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/
            // https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/main-command-line
            // https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements
            // https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/namespaces
            // https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names
            // https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
            #endregion

            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/statement-keywords

            #region Helpful Shortcuts
            // ctrl + k + d will format your file
            // ctrl + shift + s will save all open tabs
            // ctrl + tab or strl + shift + tab will allow you to navigate open tabls
            // ctrl + q will open the search (at the top)
            // ctrl + f will open find
            // ctrl + shift + f will open find all
            // ctrl + h will open replace
            // ctrl + shift + h will open replace all
            // when renaming things, its usually best to just r-click the thing, select rename, and VS will automatically update all isntances of that thing
            // ctrl + b will build the current project
            // ctrl + shift + b will build all projects
            // f5 will run the current project with debugging on
            // ctrl + k + s will open the surround context menu (it is how I make the #regions)
            // ctrl + k + k will toggle a bookmark on the current line
            // f9 will insert a breakpoint on the current line
            #endregion
        }
    }
}
