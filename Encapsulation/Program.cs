using System;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Encapsulation is the concept of hiding implementation details that consumers of our class/method should not be concerned with
            // or perhaps more importantly, for security purposes, should not have access to

            // https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop
            // Encapsulation Hiding the internal state and functionality of an object and only allowing access through a public set of functions.

            // Encapsulation in C# is managed using primarily via accessabilty modifiers, and the private modifier in particular
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/private

            // any method, field, constructor, etc. can only be accessed from within the context the modifier is placed on

            // private members must be set/initialized within their declared context, including using a constructor or method that exposed the member to mutation
            Console.WriteLine("Hello World!");

            MyClass myClass = new();
            // _multiplier with our default constructor will be set to 10
            // myClass._multiplier; // <- compile error _multiplier is inaccessible
            MyClass myClass2 = new(100); // <- because we expose the _multiplier vie this constructor, we can have the consumer of MyClass set its value as wlel
            myClass.add = 20;

            // TODO: const, readonly
        }
    }

    class MyClass
    {
        private readonly int _multiplier; // <- only accesible in MyClass
        readonly int divide; // <- internal, only accessible to the assembly (the project)
        public int add; // <- always available, even outside the assembly

        public MyClass()
        {
            _multiplier = 10;
        }

        public MyClass(int? multiplier)
        {
            _multiplier = multiplier ?? 10;
        }

        int nultiply(int number)
        {
            return number * _multiplier;
        }
    }
}
