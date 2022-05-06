using System;

namespace Types
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/
            #region Types
            // What are types?
            // We can define a type as a blueprint that defines what something is and its state and behavior
            // If we think of what a car might be in code, we can map out its state and behavior
            // It has wheels, a passenger count, a break to slow down, a gas peddle to accelerate, etc.
            // Look at the class Car (below) to see how we can build this in code
            // We define state as properties, and the behavior as methods
            // The class is just a blueprint; a design. If we want an instance of a Car type, we would use the new keywaord
            var honda = new Car();
            // we can set properties on our instance and call methods easily
            honda.Make = "Honda";
            honda.Model = "Accord";
            honda.Year = 2023;
            honda.AddPassenger();
            honda.PressGas();

            // we can create as many instances we want
            var lexus = new Car();
            lexus.Make = "Lexus";
            lexus.Model = "ES300";
            lexus.Year = 1999;

            // An unintialized class will always be null until assigned
            Car bMW;

            // the honda and lexus are both instance of type Car
            // Car is a class. Classes are the most common type you will likely interact with, but there others and we should be familiar with them 
            #endregion

            #region State/Behavior
            // What are type members? State/Behavior?
            // Members are any state or behavior of a type
            // Type is what the thing is
            // State defines what a type has
            // Behavior defines what a type does

            // State is often defined using properties
            // Behavior is often defined using methods
            #endregion

            #region Object
            // What is object? Object is the base type. All types derive from object.
            object canBeAnything = 123;
            // ctrl l-click object, to read its details
            #endregion

            #region Value and Reference Types
            // What are value and reference types?

            // What are the built in value types? https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/#value-types
            // What are the built in reference types? https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/#reference-types 
            #endregion

            // We have worked exclusively with built-in types, but most complex applications will use custom/complex types like Car
            // From now on, we will organize our applications using types, this is where C# shines as an Object Oriented Programmign language
            // Types allow us to engineer and organize our application by defining types (objects) that have state and behavior
        }

        class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            /// <summary>
            /// Count of Wheels, default to 4
            /// </summary>
            public int Wheels { get; set; } = 4;
            /// <summary>
            /// Count of maximum capacity, default to 5
            /// </summary>
            public int Capacity { get; set; } = 5;
            /// <summary>
            /// Count of current passengers including driver
            /// </summary>
            public int Passengers { get; set; }
            /// <summary>
            /// Current speed of car in MPH
            /// </summary>
            public int Speed { get; set; }
            /// <summary>
            /// Will decelerate a moving car
            /// </summary>
            public void PressBreak()
            {
                if (Speed == 0 || Passengers == 0) return;
                Speed--;
            }
            /// <summary>
            /// Will accelerate a car
            /// </summary>
            public void PressGas()
            {
                if (Passengers > 0) Speed++;
            }

            /// <summary>
            /// Will add a passenger if car is not at full capacity
            /// </summary>
            public void AddPassenger()
            {
                if (Passengers < Capacity) Passengers++;
            }
            /// <summary>
            /// Will remove a passenger if passengers count is not 0
            /// </summary>
            public void RemovePassenger()
            {
                if (Passengers > 0) Passengers--;
            }
        }
    }
}
