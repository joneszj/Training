using System;

namespace String
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0
            Console.WriteLine("Hello World!");

            // immutable
            // https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0#Immutability

            // The main thing to know about strings for now is that they are immutable
            // That is, they are actually read-only. Any method that seems to alter a string in anyway is actually returning a new string
            // If you have a program that is doing many string manipulations, conside StringBuilder
            // StringBuilder allows you to construct and alter strings once instead of creating a new string per manipulation
        }
    }
}
