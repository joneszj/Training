using System;
using System.Threading;
using System.Threading.Tasks;

namespace FishingGame
{
    class Program
    {
        /// <summary>
        /// Areas of focus: arrays, branching, comparison, iteration, parsing, variables
        /// Secondary: interpolation, random number generation, threading, static/instance classes/methods
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string[] lures = { "Yew Rod", "Titanium Rod", "Magic Rod", "Fart Rod", "Weak Rod" };
            string[] fish = { "Tuna", "Whale", "Dolphin", "Stingray", "Seal", "Crab", "of Junk", "Alien from Mars" };
            string[] bait = { "Minnow Bait", "Synthetic Bait", "Magic Bait" };
            var rng = new Random();

            Console.WriteLine("Hello World! Welcome to Z-Mans Fishery!");
            Console.WriteLine("Would you like to start fishing?");
            var startFishing = char.ToLower(Console.ReadKey(true).KeyChar) == 'y';
            if (startFishing)
            {
                Console.WriteLine("\nGreat! To get started, you will need a rod. Please select one of ours.");
                for (int i = 0; i < lures.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {lures[i]}");
                }
                var selectedLure = lures[int.Parse(Console.ReadKey(true).KeyChar.ToString()) - 1];

                Console.WriteLine("\nAwesome! Now, lets select a bait!");
                for (int i = 0; i < bait.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {bait[i]}");
                }
                var selectedBait = bait[int.Parse(Console.ReadKey(true).KeyChar.ToString()) - 1];

                Console.WriteLine($"Perfect! Now we can fish with your {selectedLure} and {selectedBait}.");
                // Console.WriteLine("As we fish, you will see a '.' which means wiat, and a '!' which means press any key to bring in the fish!");
                // Console.WriteLine("Special fish may require you to press a specific char that will also display, such as 'g'.");
                Console.WriteLine("Ready?");
                
                var ready = char.ToLower(Console.ReadKey(true).KeyChar) == 'y';
                if (ready)
                {
                    Console.WriteLine("Start!\n");

                    var continueFishing = true;
                    do
                    {
                        Thread.Sleep(1000);
                        var interval = rng.Next(0, 16);
                        if (interval == 0)
                        {
                            Console.Write("!");
                            continueFishing = false;
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    } while (continueFishing);

                    Console.WriteLine("\nYou caught a fish! Lets check it out!");
                    Thread.Sleep(1000);

                    var pounds = 1;
                    pounds += Array.IndexOf(lures, selectedLure);
                    pounds -= Array.IndexOf(lures, selectedBait);

                    Console.WriteLine($"You caught a {pounds} pound {fish[rng.Next(0, fish.Length)]}! Congradulations!");
                }
            }

            Console.WriteLine("Have a great day!");
        }
    }
}
