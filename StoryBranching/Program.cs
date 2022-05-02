using System;

namespace StoryBranching
{
    class Program
    {
        /// <summary>
        /// Areas of focus: branching, comparison, parsing
        /// Secondary: interpolation, static classes/methods
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World! How are you?");
                var feeling = Console.ReadLine();
                switch (feeling.ToLower())
                {
                    case "good":
                        Console.WriteLine("That is great to know!");
                        break;
                    case "bad":
                        Console.WriteLine("Aww... I hope you feel better!");
                        break;
                    default:
                        Console.WriteLine("Well... That is interesting.");
                        break;
                }

                Console.WriteLine("Lets see if you are old enough to drive. How old are you?");
                var ageAsString = Console.ReadLine();
                var ageIsValid = int.TryParse(ageAsString, out var age);
                if (ageIsValid)
                {
                    if (age < 16)
                    {
                        Console.WriteLine($"Ah! {age} is too young to start driving.");
                    }
                    else if (age > 70)
                    {
                        Console.WriteLine($"Oh! {age} is too old to be driving!");
                    }
                    else
                    {
                        Console.WriteLine($"You are of driving age.");
                    }
                }
                else
                {
                    Console.WriteLine($"Hmmmm... {ageAsString} isn't an age...");
                }
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
