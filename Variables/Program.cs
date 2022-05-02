using System;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Declaration, Initialization, Assignment
            // Variables are simply a way of storing in memory, application state
            // All variables require a type, unless they are dynamic
            int myNumber = 1;
            // Above, we declare the variable type (int), give the variable a name (myNumber), and initialize it with a value (1)
            // We can also declare uninitialized variables if we want to provide a value later
            int myNumber2;
            // Variable names cannot start with a number

            // C# requires a semicolon to follow the end of every statement (but it does not require a semicolon on scope blocks)

            // We can also shorthand variable declaration by using the 'var' keyword
            var myNumber3 = 1;
            // 'var' does not mean that variable can be reassigned to any type. The compiler simply examins the assignment and determines the type for us
            // This is whay 'var' must be initialized, or you will have a compiler warning
            // var someVariable; // <- this is invalid, the type must be known

            // Wenever we create a variable, we can say it is "of type x" or "an instance of type x" where x is the type of the variable
            bool someBool = true; // <- someBool is an instance of bool and is an instance bool

            // Type safety: means that a variable cannot be assigned to a value of a different type
            // string myString = 1; // <- this is invalid, a string variable requires a string, not an int
            // Go here for a list of C#'s base types: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types
            /* Common base data types are:
                int (whole number), 
                float (number that can have a decimal value),
                bool (true or false) 
                char (a single characted, always in single quotes '')
                string (multiple characters, always in double quates "")
             */ 
            #endregion

            #region Scope
            // All variables adhere to block scope
            // Meaning, variables may be referrenced in the scope they are created in, and any nested scope, but are unavailable outside that scope
            // Scope is simply determined by the curly brackets
            {
                // this is a scope, notice the enclosed { }
                var myString = "";
                {
                    // this is a new scope, nested within the previous scope
                    // myString is available for reference here
                    myString = "hello!";
                    // As well as the variables in the scopes above as well
                    myNumber = 1;
                    // notice that when reassigning a variable, we do not redeclare its type
                }
                var myBool = true;
            }
            // myBool = true; // <- this is invalid, myBool is declared in a nested scope, so it cannot be referrenced here
            // If we try to declare another variable in the parent scope, we will get a compiler error that the name in use in an enclosed scope
            // var myBool = 2; 
            #endregion

            #region Using Variables
            // Variables are used to stare data/state. Lets ask the user their name, then store that into a variable, then output that variable
            Console.WriteLine("What is your name"); // <- output
            var userName = Console.ReadLine(); // <- input
            // ^ notice the return type of ReadLine() is string, so our userName variable will also be of type string
            Console.WriteLine("Hello " + userName + "!"); // <- we can append strings together using the + operator called concatonation
            Console.WriteLine($"Very nice to meet you {userName}!"); // <- we can also use interpolation ($"some test {expression} some more text")
                                                                     // ^ just remember to use the $ infront of the string 
            #endregion

            #region Variable Reassignment
            // Variables are used to store data, but we can also alter the contents of a variable by assigning it a new value of the same type
            userName = userName + " (is awesome)";
            Console.WriteLine($"How is your day {userName}?"); // <- notice that userName now has " (is awesome)" added to it 
            #endregion

            #region Instanced Methods
            // Variables often have helpful instanced methods available to us accessed by a .
            // An instance method is simply a method on a variable (an instance)
            userName.ToUpper(); // <- .ToUpper() is an instance method on string variables, this will return a new string of userName that is entirely upper cased
            // ^ because it returns a new string (examine/hover .ToUpper()), it does not alter the variable it was called on
            // We can create a new variable to capture this new string from .ToUpper()
            var upperUserName = userName.ToUpper();
            // or we can simply reassign the original variable to the new string from .ToUpper()
            userName = userName.ToUpper();
            Console.WriteLine(userName); // <- is not in all caps 
            #endregion

            #region Static Methods
            // Types themselves also have helpful methods that we can use, called static methods
            // We can access these with a period after the type name
            var isEmpty = string.IsNullOrEmpty(userName);
            // string.IsNullOrEmpty(string) is a static method on the string type
            // it will return a bool indicating if the passed string is null or empty
            // Thus, the variable isEmpty is of type bool
            // Though static methods are on types, not variables, often they are needed when working with variables
            // Static methods and Instanced methods will be covered in more detail later
            #endregion

            #region Deep Dive
            // https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/
            // https://www.bestprog.net/en/2016/08/08/02-base-types-values-types-in-c/#q_01
            #endregion
        }
    }
}
