using System;

namespace ControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            // Applications run top to bottom, line by line
            // Often, we may want to run a block of code based on some form of input
            // The two main means of control flow are switch and if/else statements
            // There are others, but for not, these are fundamental

            #region Switch
            // A switch statement does what it sounds like, switches where the code will run if certain cases are true
            // To build a switch, we use the 'switch' keyword, followed by thing that we will switch on (thing)
            // If our (thing) matches a case, what is in the case will run
            // Cases may fallthrough to other cases
            // If none of our cases finds a match, the default case will run

            var activity = Console.ReadLine().ToLower();
            // (keyboard switch tab + tab)
            switch (activity)
            {
                case "jogging":
                case "running":
                    // jogging and running will go here since jogging has no break
                    Console.WriteLine("Awesome! I know a great place we can get some cardio!");
                    break;
                case "movie":
                    Console.WriteLine("Aww, there is nothing good at the theaters!");
                    break;
                case "music":
                    Console.WriteLine("What is your favorite band?");
                    var band = Console.ReadLine();
                    Console.WriteLine($"Great! Lets listen to {band}");
                    break;
                default:
                    Console.WriteLine("Hmmm.... Lets do something else.");
                    break;
            }

            #endregion

            #region IfElse_ElseIf
            // if statements will run a block of code if the expression passed into the if is true
            // else will run if the if expression returns false
            // else if(expression) can check subsequent expressions if the previous if's evaluate to false

            var activity2 = Console.ReadLine().ToLower();
            // (keyboard if tab + tab)
            if (activity2 == "jogging" || activity2 == "running")
            {
                Console.WriteLine("Awesome! I know a great place we can get some cardio!");
            }
            else if (activity2 == "movie") Console.WriteLine("Aww, there is nothing good at the theaters!");
            else if (activity2 == "music")
            {
                Console.WriteLine("What is your favorite band?");
                var band = Console.ReadLine();
                Console.WriteLine($"Great! Lets listen to {band}");
            }
            else Console.WriteLine("Hmmm.... Lets do something else.");
            // notice, single line if/else code blocks do not need brackets
            // this will do exactly what the switch above does

            // If it is easier to write the if statement first, you can use intellisence (ctrl + .)
            // select the if/else code, ctrl + ., convert to switch
            // But in my experience, if/else statements are preferred, regardless the potential performance hit
            #endregion

            #region Nesting

            #endregion

            #region Comparison Operators
            // && and
            // || or
            // > greater than
            // < less than
            // ! not (will return the opposite bool value)
            #endregion

            #region Notes
            // I generally prefer if statements as I find them easier to read and write
            // But switch statements have the benefit of the compiler being able to branch determine more efficiently so there is a case for them
            #endregion

            #region Deep Dive
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements
            // https://zetcode.com/lang/csharp/flowcontrol/
            #endregion

            #region Practice
            // Create a Console Application and practice creating and managing control flow constructs
            // Understand comparion operators and the bool data type
            // Ask the user questions, store their response into variables and branch from those inputs
            // Ask follow up questions for each branch, etc.

            // Create a simple 10 question math quiz where you will track a count of incorrect and correct answers
            // Ask the question, store the answer, keep track of the score, display the score after the quiz is finished
            // To complete this using ints, you may want to read up on Parsing.
            // Otherwise, since ReadLine() returns a string, you could simply compare string to string for now
            #endregion
        }
    }
}
