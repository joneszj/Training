using System;

namespace NextLetter
{
    class Program
    {
        /// <summary>
        /// Areas of Focus: arrays, indexing, iteration
        /// Secondary: validation, static/instance classes/methods, LinQ
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                Console.WriteLine("Enter a letter and get the next letter.");

                // LinQ
                //do
                //{
                //    var letter = Console.ReadKey().KeyChar;
                //    if (alphabet.Any(e => e == letter)) Console.WriteLine(alphabet.SkipWhile(e => e != letter).Skip(1).FirstOrDefault());
                //    else Console.WriteLine($"\n{letter} is invalid.");
                //} while (true);

                do
                {
                    var letter = Console.ReadKey().KeyChar;
                    var alphabetArrayIndex = Array.IndexOf(alphabet, letter);
                    if (alphabetArrayIndex > -1)
                    {
                        if (alphabetArrayIndex + 1 == alphabet.Length) alphabetArrayIndex = -1;
                        Console.WriteLine($"\n{alphabet[alphabetArrayIndex + 1]}");
                    }
                    else Console.WriteLine($"\n{letter} is invalid.");
                } while (true);
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
