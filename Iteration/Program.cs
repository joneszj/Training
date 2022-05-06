using System;

namespace Iteration
{
    class Program
    {
        static void Main(string[] args)
        {
            #region While
            // if while expression is true, the while scope will run until it is false
            Console.WriteLine("Enter a random number between 1 and 10 until you guess the correct number.");
            var inputAnswer = Console.ReadLine();
            // (keyboard while tab + tab)
            while (inputAnswer != "8")
            {
                // if the answer was not 8, the while loop will start.
                Console.WriteLine("Enter a random number between 1 and 10.");
                inputAnswer = Console.ReadLine();
            }

            // Usage idea: great for a retry pattern allowing the user to retry a statment until valid
            #endregion

            #region DoWhile
            // The only differences between while and do while are:
            // that do while will always run atleast once
            // do is at the top, and while after the scope brackets

            // with any loop, we can maintain an external variable to count how many times we have iterated
            // (keyboard do tab + tab)
            int count = 1;
            do
            {
                Console.WriteLine($"Enter a random number between 1 and 10. Attempts made: {count++}");
                inputAnswer = Console.ReadLine();
            } while (inputAnswer != "4");

            // Usage idea: great for allowing an entire application to restart in the doWhile loop until the user specifies otherwise
            #endregion

            // While and DoWhile constructs are particularly useful when you do not, or cannot determine beforehand when the iteration should terminate
            // For loops are deterministic by nature, the termination condition is known when the iteration starts

            #region For
            // For loops are like while loops, but we can set the iteration count manually
            // for (start variable, termination expression, increment)
            // after each iteration, i will be bumped by 1
            // (keyboard for tab + tab)
            for (int i = 0; i < 10; i++)
            {
                // will start i at 0
                // if i < 10, stop the iteration

                // this code block will run

                // after each iteration, i will be incremented by 1
            }

            // Usage idea: great for iterating over arrays, or when you simply need an index, such as the numbers on a list
            #endregion

            #region ReverseFor
            // same as a normal for loop, but starts in reverse and decrements i on each iteration
            // for (start variable, termination expression, decrement)
            // (keyboard forr tab + tab)
            for (int i = 10 - 1; i >= 0; i--)
            {
                // will start i at 10
                // if i >= 0, stop the iteration

                // this code block will run

                // after each iteration, i will be decremented by 1
            }

            // Usage idea: same as nor for loops, but in reverse
            #endregion

            #region Nesting
            // all loops may have nested loops, just be maintain the variables properly
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Outer: {i}");
                for (int y = 0; y < 20; y++)
                {
                    // notice the inner loop needs a distinct variable name, here we use y
                    // the outer loop variable is accesible here as well
                    Console.WriteLine($"Outer: {i}, Inner: {y}");
                }
            }
            #endregion

            #region Jump Statements
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements
            // Break and Continue aren't very common, but you may find use for them
            // break; will terminate the current iteration, but the iteration construct will continue
            // continue; will terminate the iteration construct
            // return; (used anywhere) will return the current method to the caller
            // goto; I have never used this. I think the idea of pointers are shunned upon in the c# community. goto; may also be shadowed by other constructs that offer similar functionality
            // TODO: application idea that requires usage of break and continue
            #endregion

            // In my experience, I rarely ever use these iteration constructs. The vast majority of the time for web development I use ForEach, which will be discussed in collections
            // This is because, most of the iterations required in web applications are on data collections, which have a determined limit that usually don't require an index

            // While loops can be used to perform infinite looping by simply leaving the expression as always true
            // For loops may also be used for infinite looping by omitting the incrementation
            // But doing so is likely a mistake, as unlike the while loops, you don't really have a means of terminating the loop without using a break;
            for (int i = 0; i < 10;)
            {

            }
            // For loops are quite often necessary in interview questions (string reversal etc.)
            // Arrays, a primitive collection, are easily traversable using For loops as well, but I still prefer ForEach

            #region Deep Dive
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements
            // https://zetcode.com/lang/csharp/flowcontrol/
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements
            #endregion

            #region Practice
            // Create a Console Application and practice iteration
            // Understand which iteration construct may be fit a given scenario

            // While
            // Create Console applicaiton that will be a simple 10 question math quiz where you will track a count of incorrect and correct answers
            // Ask the question, store the answer, keep track of the counts, display the counts after the quiz is finished
            // Using features from previous lessons, implement a retry feature on questions that users provide invalid (not the same as incorrect) answers
            // Ex output:   10 * 30
            // Ex input:    A300
            // Ex output:   A300 is not a valid number. Please try again
            // Ex output:   10 * 30 (attempt 2)

            // DoWhile
            // Create a Console application that will print a series of sets of numbers starting 1
            // After outputing 10 number, ask the user with they would like more
            // If the user input is char 'Y', or 'y' (so use ReadKey() not ReadLine()) then output the next set of numbers
            // If the user inputs anthing other than char 'Y' or 'y' then terminate the application

            // For Loop
            // Create a Console application that will ask the user for a number between 1 and 100
            // For every odd number, set the console background color to red and output "{the number} is odd"
            // For every even number, set the console background color to blue and output "{the number} is even"
            // Use iteration until your iteration count is equal to the number the user provided
            // Use tools from previous lessons such as parsing for input validation, a while loop to retry user input, and a doWhile to restart the application unless the user specifies otherwise

            // Reverse For Loop
            // Create a Console app that will count down to 0 from a number the user inputs
            // For every odd number, set the console background color to red and output that number
            // For every even number, set the console background color to blue and output that number
            // To get or set the background, you can use the Console.BackgroundColor static property of type ConsoleColor (an enume, which we will cover in the future)
            // A simple google search will demonstrate this easily
            // Use tools from previous lessons such as parsing for input validation, a while loop to retry user input, and a doWhile to restart the application unless the user specifies otherwise
            // When 0 is reached, use the Console.Beep() static method to create a beep sound
            #endregion
        }
    }
}
