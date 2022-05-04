using System;
using System.Linq;

namespace _09g_ShortestWord
{
    class Program
    {
        static void Main(string[] args)
        {
            // try/catch incase something unexpected throws an error
            try
            {
                // control variable to rerun the program
                var continueProgram = false;
                // doWhile to rerun the program and to run it atleast once
                do
                {
                    // ask user for words
                    Console.WriteLine("Provide 3 or more words, separated by comma's");
                    // split the words into new string array and assign words to this new array
                    var words = Console.ReadLine().Split(',');

                    // we use a while to retry invalid user input
                    while (words.Length < 3)
                    {
                        Console.WriteLine("Not enough words, please try again.");
                        words = Console.ReadLine().Split(',');
                    }

                    // LinQ: look how much simpler and more readable it is
                    // first we trim each string, then we order them, then we select the min/max
                    // var wordsTrimedOrdered = words.Select(e => e.Trim()).OrderBy(e => e);
                    // var shortestWord = wordsTrimedOrdered.Min(e => e.Length);
                    // var longestWord = wordsTrimedOrdered.Max(e => e.Length);
                    // Console.WriteLine($"Shortest: {shortestWord}\nLongest: {longestWord}");

                    // since these variables are only used once, we can shorten our code by simply outputing their evaluation instead of creating the variables
                    // var wordsTrimedOrdered = words.Select(e => e.Trim()).OrderBy(e => e);
                    // Console.WriteLine($"Shortest: {wordsTrimedOrdered.Min(e => e.Length)}\nLongest: {wordsTrimedOrdered.Max(e => e.Length)}");

                    // Non-LinQ
                    var shortestWord = string.Empty;
                    var longestWord = string.Empty;
                    // ^ because strings are immutable, string.Empty creates a single empty string, instead of two ""

                    // trim the words
                    var wordsTrimmed = new string[words.Length];
                    for (int i = 0; i < words.Length; i++)
                    {
                        wordsTrimmed[i] = words[i].Trim();
                    }

                    // Sort using a custom Comparison method
                    Array.Sort(wordsTrimmed, SortByLengthThenName());
                    // first indexed array item will be the shortest
                    shortestWord = wordsTrimmed[0];
                    // last indexed array item will be the longest
                    longestWord = wordsTrimmed[wordsTrimmed.Length - 1];
                    // output result
                    Console.WriteLine($"Shortest: {shortestWord}\nLongest: {longestWord}");
                    // Again, since these variables are only used once, we can shorten this by outputing their evaluation instead of creating new variables if desired
                    // Console.WriteLine($"Shortest: {wordsTrimmed[0]}\nLongest: {wordsTrimmed[wordsTrimmed.Length - 1]}");

                    // ask user if they would like to rerun that application again
                    Console.WriteLine("Would you like to run the application again?");
                    // if key is not y, terminate the application
                    continueProgram = Console.ReadKey().Key == ConsoleKey.Y;
                } while (continueProgram);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong :(\n{ex.Message}");
                throw;
            }
        }

        // original sort algorithm source: https://stackoverflow.com/questions/20087280/sort-string-array-by-element-length
        // expanded upon to sort alphabetically for equal length strings
        // test, hello, jack, zack will sort as jack, test, zack, hello
        private static Comparison<string> SortByLengthThenName() => 
            (current, next) => 
                current.Length.CompareTo(next.Length) == 0 ? current.CompareTo(next) : current.Length.CompareTo(next.Length);
        
    }
}
