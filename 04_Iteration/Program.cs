using System;

namespace _04_Iteration
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
            #endregion

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
            #endregion

            #region Nesting

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
            #endregion

            // In my experience, I rarely ever use these iteration features. The vast majority of the time I use ForEach, which will be discussed in collections
            // While loops can be used to perform infinite looping
            // For loops are quite often necessary in interview questions (string reversal etc.)
            // Arrays, a primitive collection, are easily traversable using For loops as well, but I still prefer ForEach

            #region Deep Dive
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements
            // https://zetcode.com/lang/csharp/flowcontrol/
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements
            #endregion
        }
    }
}
