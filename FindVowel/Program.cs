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
                        switch (char.ToLower(letter))
                        {
                            case 'a':
                                aCount++;
                                break;
                            case 'e':
                                eCount++;
                                break;
                            case 'i':
                                iCount++;
                                break;
                            case 'o':
                                oCount++;
                                break;
                            case 'u':
                                uCount++;
                                break;
                        }
                    }

                    var result = "";
                    // hard to read? readability is almost always more important!
                    //result = $"{(aCount != 0 ? $"a:{aCount}" : string.Empty)}, " +
                    //    $"{(eCount != 0 ? $"e:{eCount}" : string.Empty)}, " +
                    //    $"{(iCount != 0 ? $"i:{iCount}" : string.Empty)}, " +
                    //    $"{(oCount != 0 ? $"o:{oCount}" : string.Empty)}, " +
                    //    $"{(uCount != 0 ? $"o:{uCount}" : string.Empty)}";

                    // easier to read
                    if (aCount > 0)
                    {
                        result += $"a:{aCount} ";
                    }
                    else if (eCount > 0)
                    {
                        result += $"e:{eCount} ";
                    }
                    else if (iCount > 0)
                    {
                        result += $"i:{iCount} ";
                    }
                    else if (oCount > 0)
                    {
                        result += $"o:{oCount} ";
                    }
                    else if (uCount > 0)
                    {
                        result += $"u:{uCount} ";
                    }

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
