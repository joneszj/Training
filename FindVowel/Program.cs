using System;

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
                do
                {
                    Console.WriteLine("Enter a word and we will count the vowels (not including y and don't display vowels not found)!\n");
                    // LinQ
                    //Console.ReadLine().ToLower().Where(e =>
                    //    e == 'a' ||
                    //    e == 'e' ||
                    //    e == 'i' ||
                    //    e == 'o' ||
                    //    e == 'u')
                    //    .GroupBy(e => e)
                    //    .ToList().ForEach(e => Console.WriteLine($"{e.Key}: {e.Count()}"));

                    // non-LinQ
                    int aCount, eCount, iCount, oCount, uCount;
                    aCount = eCount = iCount = oCount = uCount = 0;
                    foreach (var letter in Console.ReadLine())
                    {
                        if (char.ToLower(letter) == 'a') aCount++;
                        if (char.ToLower(letter) == 'e') eCount++;
                        if (char.ToLower(letter) == 'i') iCount++;
                        if (char.ToLower(letter) == 'o') oCount++;
                        if (char.ToLower(letter) == 'u') uCount++;
                    }

                    var result = "";
                    // hard to read? readability is almost always more important!
                    //result = $"{(a != 0 ? $"a:{a}" : string.Empty)}, " +
                    //    $"{(e != 0 ? $"e:{e}" : string.Empty)}, " +
                    //    $"{(i != 0 ? $"i:{i}" : string.Empty)}, " +
                    //    $"{(o != 0 ? $"o:{o}" : string.Empty)}, " +
                    //    $"{(u != 0 ? $"o:{u}" : string.Empty)}";

                    // easier to read
                    if (aCount > 0) result += $"a:{aCount} ";
                    if (eCount > 0) result += $"e:{eCount} ";
                    if (iCount > 0) result += $"i:{iCount} ";
                    if (oCount > 0) result += $"o:{oCount} ";
                    if (uCount > 0) result += $"u:{uCount} ";

                    Console.WriteLine(result);
                    Console.WriteLine("Continue?");
                } while (Console.ReadKey(true).Key == ConsoleKey.Y);
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
