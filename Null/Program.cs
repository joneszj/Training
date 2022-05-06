using System;

namespace Null
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types

            #region What is null
            // What is null? null means nothing; no value. A variable that is null represents a variable that is nothing

            // What can be null?
            // All reference types default value is null
            // All value types can become null using the ? or the Nullabe<t> geenric structure 
            #endregion

            #region How to make null
            // How to make something nullable?
            int nonNullInt; // this variable cannot be null, its default value is 0
            bool nonNullBool; // this variable also cannot be null, its default value is false

            int? myNumber; // <- is an int variable that is currently null
            myNumber = 13; // -< now, the value is 13

            Building buiding; // <- by default, because class is a reference type is null until we instantiate an instance
            buiding = new Building(); // <- building is now an instance, not null

            string myString; // <- string is a reference type, so this is null by default

            Nullable<int> myNumber2; // <- another way of declaring a value type as nullable
                                     // notice VS offers to simplfy the statement by using the ? 
            #endregion

            #region Working with null
            // Working with null?
            // Nullable types have extended properties that help us work with null

            // Any nullable value has the following:
            bool hasValue = myNumber.HasValue; // <- true if the valeiable is not null, false if it is null
            int theValue = myNumber.Value; // <- the value, will throw if null

            // A shorthand means of handling null is ?? (null coalesce) it will execute the statement to its right if the left expression is null
            var myNumber3 = myNumber ?? 0; // <- if myNumber is null, assign myNumber3 to 0

            // not null, but uses default values for its members
            Apartment apt;

            // strings have the static method IsNullOrEmpty and IsNullOrWhitespace to help with checking strings 
            #endregion

            #region C# 8.0 nullable reference types
            // All reference types are nullable by default, but since c# 8.0, you can extend reference type variables with the ? to access nullable properties/methods
            // As well as adding #nullable enable to teh file
            // Read more: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references 
            #endregion
        }

        // Reference types are null by default
        class Building
        {
            public string Address { get; set; }
            public string Zip { get; set; }
        }

        // Value types are not null and instead have/will use default values
        // Because struct is a complex value-type, it will have an instance, but all members will use their default value
        struct Apartment
        {
            public int RoomNumber { get; set; }
            public Building Building { get; set; } // <- is a reference type, so it will default to null even though it is on a value type struct
        }
    }
}
