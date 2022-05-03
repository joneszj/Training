using System;
using System.Linq;

namespace Palindrome
{
    class Program
    {
        /// <summary>
        /// Areas of focus: comparison, iteration, variables
        /// Secondary: enums, immutability, LinQ, stringBuilder, reverse iteration
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a word and we will identify if it is a palendrome!");
                do
                {
                    Console.WriteLine();
                    var word = Console.ReadLine();

                    // LinQ
                    // Console.WriteLine(word == new string(word.Reverse().ToArray()));

                    // non-LinQ
                    var stringReversed = "";
                    for (int i = word.Length - 1; i >= 0; i--)
                    {
                        stringReversed += word[i];
                    }
                    Console.WriteLine(word == stringReversed);

                    Console.WriteLine("Continue?");
                } while (Console.ReadKey().Key == ConsoleKey.Y);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Uh oh! Something went wrong :(");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
