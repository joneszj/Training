using System;
using System.Linq;

namespace FindVowel
{
    class Program
    {
        /// <summary>
        /// Areas of focus: branching, iteration, variables
        /// Secondary: concatonation, incrementaiton, interpolation, LinQ, readability, static classes/methods
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a word and we will count the vowels (not including y and don't display vowels not found)!");
                do
                {
                    Console.WriteLine();

                    // LinQ
                    //Console.ReadLine().Where(e =>
                    //    char.ToLower(e) == 'a' ||
                    //    char.ToLower(e) == 'e' ||
                    //    char.ToLower(e) == 'i' ||
                    //    char.ToLower(e) == 'o' ||
                    //    char.ToLower(e) == 'u')
                    //    .GroupBy(e => e)
                    //    .ToList().ForEach(e => Console.WriteLine($"{e.Key}: {e.Count()}"));

                    // non-LinQ
                    int a, e, i, o, u;
                    a = e = i = o = u = 0;
                    foreach (var letter in Console.ReadLine())
                    {
                        if (char.ToLower(letter) == 'a') a++;
                        if (char.ToLower(letter) == 'e') e++;
                        if (char.ToLower(letter) == 'i') i++;
                        if (char.ToLower(letter) == 'o') o++;
                        if (char.ToLower(letter) == 'u') u++;
                    }

                    var result = "";
                    // hard to read? readability is almost always more important!
                    //result = $"{(a != 0 ? $"a:{a}" : string.Empty)}, " +
                    //    $"{(e != 0 ? $"e:{e}" : string.Empty)}, " +
                    //    $"{(i != 0 ? $"i:{i}" : string.Empty)}, " +
                    //    $"{(o != 0 ? $"o:{o}" : string.Empty)}, " +
                    //    $"{(u != 0 ? $"o:{u}" : string.Empty)}";

                    // easier to read
                    if (a > 0) result += $"a:{a} ";
                    if (e > 0) result += $"e:{e} ";
                    if (i > 0) result += $"i:{i} ";
                    if (o > 0) result += $"o:{o} ";
                    if (u > 0) result += $"u:{u} ";

                    Console.WriteLine(result);
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
